using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trakio
{
    
    public class CheckEthernet : IDisposable
    {
        /// <summary>
        /// Таймер для периодической проверки интеренет подклюбчения
        /// </summary>
        private readonly Timer timer;
        /// <summary>
        /// Период проверки интернет соединения в секундах
        /// При наличии интернета проверка каждые 30с
        /// При отсутствии интернета и при после запуска приложения проверка каждые 5с
        /// </summary>
        private int period = 5;
        /// <summary>
        /// Последние состояние интернет соединения
        /// </summary>
        private bool _lastStatus = false;
        /// <summary>
        /// Событие которое происходит при изменениинашего статуса интернет соединния
        /// </summary>
        public event Action<bool> EthernetStatusChanged;

        public CheckEthernet()
        {
            timer = new Timer();
            timer.Tick += async (s, e) => await HandleTimerCheckEthernet();

            timer.Interval = period * 1000;
            timer.Start();
        }

        /// <summary>
        /// Метод проверяющий интернет соединение через HTTP-запрос
        /// </summary>
        /// <returns></returns>
        private async Task HandleTimerCheckEthernet()
        {
            bool currentStatus = await HTTP_request();

            if(currentStatus != _lastStatus)
            {
                period = currentStatus ? 30 : 5;
                timer.Interval = period * 1000;
                _lastStatus = currentStatus;
                EthernetStatusChanged?.Invoke(currentStatus);
            }

            
        }

        /// <summary>
        /// Отправка HTTP запроса для проверки интернет соединения
        /// </summary>
        /// <returns></returns>
        private async Task<bool> HTTP_request()
        {
            try
            {
                using(HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(3);
                    var response = await client.GetAsync("https://www.yandex.ru");
                    return response.IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Останавливает таймер и освобождает ресурсы.
        /// </summary>
        public void Dispose()
        {
            timer?.Stop();
            timer?.Dispose();
        }
    }
}
