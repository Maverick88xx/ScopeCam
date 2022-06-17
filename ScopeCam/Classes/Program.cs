using System;
using System.Windows.Forms;           

namespace ScopeCam
{
    static class Program
    {
        /// <summary>
        /// Головна точка входу програмного додатку
        /// </summary>
        // Стандартне підключення форми програми до головного файлу
        [STAThread]
        static void Main()
        {
            // Включення візуальних ефектів Windows XP до 
            // створення будь-яких елементів управління
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Створення головного вікна і його запуск
            Application.Run(new MainForm());
        }
    }
}
