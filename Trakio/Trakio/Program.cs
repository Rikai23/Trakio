using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Trakio
{
    static class Program
    {
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        /// <summary>
        /// Исп. для контроля запуска одного экземп. приложения
        /// </summary>
        private static Mutex _mutex;

        /// <summary>
        /// Уникальное имя Mutex
        /// </summary>
        private const string MutexName = "Trakio";

        /// <summary>
        /// Флаг ShowWindow для восстановления из свернутого или скрытого состояния
        /// </summary>
        private const int SW_RESTORE = 9;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (EnsureSingleInstance())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }

        /// <summary>
        /// Метод проверяет запущено ли приложение
        /// </summary>
        /// <returns>
        /// true - если это первый экземпляр приложения
        /// false - если приложение уже запущено
        /// </returns>
        private static bool EnsureSingleInstance()
        {
            bool createdNew = false;

            _mutex = new Mutex(true, MutexName, out createdNew);

            if (!createdNew)
            {
                ActivateRunningInstance();
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Метод находит запущенное окно приложения, при необходимости разворачивает его и делает на нем фокус
        /// </summary>
        private static void ActivateRunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process existingProcess = Process.GetProcessesByName(current.ProcessName).FirstOrDefault(p => p.Id != current.Id);

            if (existingProcess == null)
                return;
            else
            {
                IntPtr hWnd = existingProcess.MainWindowHandle;

                if (hWnd == IntPtr.Zero)
                    return;
                else
                {
                    ShowWindow(hWnd, SW_RESTORE);
                    SetForegroundWindow(hWnd);
                }
            }
        }
    }
}
