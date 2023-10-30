using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sudokuHM
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (DifficultyForm difficultyForm = new DifficultyForm())
            {
                if (difficultyForm.ShowDialog() == DialogResult.OK)
                {
                    int selectedDifficulty = difficultyForm.SelectedDifficulty;

                    // Создайте экземпляр основной формы (Form1) и передайте в него выбранную сложность.
                    Form1 mainForm = new Form1(selectedDifficulty);
                    Application.Run(mainForm);
                }
            }
            //Application.Run(new Form1());
        }
    }
}
