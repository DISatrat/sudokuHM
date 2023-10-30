using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sudokuHM
{
    public partial class DifficultyForm : Form
    {
        public int SelectedDifficulty { get; private set; }

        public DifficultyForm()
        {
            InitializeComponent();
        }

        private void DifficultyForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectedDifficulty = 1;
            this.DialogResult = DialogResult.OK; 
            this.Close(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectedDifficulty = 2;
            this.DialogResult = DialogResult.OK; 
            this.Close(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SelectedDifficulty = 3;
            this.DialogResult = DialogResult.OK; 
            this.Close();
        }
    }
}
