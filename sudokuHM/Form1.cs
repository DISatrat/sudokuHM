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
    public partial class Form1 : Form
    { 

        private Sudoku sudoku;

        public Form1(int difficulty)
        {
            InitializeComponent();

            sudoku=new Sudoku(9,difficulty);

            sudoku.FillDiagonal();

            FillDiagonalValuesInDataGridView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
              
        }
        private void FillDiagonalValuesInDataGridView()
        {
            dataGridView2.ColumnCount = sudoku.AnswerGrid.GetLength(1);
            dataGridView2.RowCount = sudoku.AnswerGrid.GetLength(0);

            for (int i = 0; i < sudoku.AnswerGrid.GetLength(0); i++)
            {
                for (int j = 0; j < sudoku.AnswerGrid.GetLength(1); j++)
                {
                    dataGridView2[i,j].Value = sudoku.AnswerGrid[i,j].ToString();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
