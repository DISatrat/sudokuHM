using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sudokuHM
{
    public partial class Result : Form
    {
        public Result(bool isWinner)
        {
            InitializeComponent();
            label1.Text = isWinner ? "Вы выиграли!" : "Вы проиграли!";

        }

        private void Result_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void ShowResult(bool isWinner)
        {
            // Создаем экземпляр ResultForm и передаем ему результат
            Result resultForm = new Result(isWinner);

            // Открываем форму модально
            resultForm.ShowDialog();
        }
    }
}
