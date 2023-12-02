using System;
using System.Drawing;
using System.Windows.Forms;
using static sudokuHM.Result;
namespace sudokuHM
{
    public partial class Form1 : Form
    {

        private Sudoku sudoku;
        private Sudoku answerSudoku;

        public Form1(int difficulty)
        {
            InitializeComponent();
            sudoku = new Sudoku(difficulty);
            sudoku.Mix();
            Random random = new Random();
            answerSudoku = new Sudoku();
            answerSudoku.UpdateGrid(Sudoku.RemoveCells(sudoku.getGrid(), difficulty, random));
            //sudoku.Show();
            //Console.WriteLine();
            //answerSudoku.Show();
            //Console.WriteLine();
            CustomizeDataGridView();

            FillDiagonalValuesInDataGridView();
            dataGridView2.CellPainting += dataGridView2_CellPainting;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void FillDiagonalValuesInDataGridView()
        {
            dataGridView2.ColumnCount = 9;
            dataGridView2.RowCount = 9;
            int[,] grid = answerSudoku.getGrid();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    dataGridView2[i, j].Value = (grid[j, i] != 0) ? grid[j, i].ToString() : string.Empty;
                }
            }
        }
        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            int borderThickness = 5; // Толщина границы
            Color borderColor = Color.Black; // Цвет границы

            if (e.RowIndex % 3 == 0 && e.RowIndex > 0)
            {
                // Рисуем верхнюю границу для каждой третьей строки
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
                using (Pen pen = new Pen(borderColor, borderThickness))
                {
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Right, e.CellBounds.Top);
                }
            }

            if (e.ColumnIndex % 3 == 0 && e.ColumnIndex > 0)
            {
                // Рисуем левую границу для каждой третьей колонки
                e.AdvancedBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
                using (Pen pen = new Pen(borderColor, borderThickness))
                {
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Left, e.CellBounds.Bottom);
                }
            }
        }
        private void CustomizeDataGridView()
        {
            dataGridView2.RowTemplate.Height = 55; // Устанавливаем высоту ячейки

            // Устанавливаем ширину ячеек (может потребоваться изменение в зависимости от вашего дизайна)
            for (int i = 0; i < dataGridView2.ColumnCount; i++)
            {
                dataGridView2.Columns[i].Width = 30; // Устанавливаем ширину столбцов
            }

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[,] grid = answerSudoku.getGrid();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    // Попытка преобразования значения из ячейки в int
                    if (int.TryParse(dataGridView2[i, j].Value?.ToString(), out int cellValue))
                    {
                        // Успешное преобразование, сохраняем значение в судоку
                        grid[j, i] = cellValue;
                    }
                    else
                    {
                        grid[j, i] = 0;
                    }
                }
            }
            bool res = Sudoku.CheckResults(sudoku.getGrid(), grid);

            // Обновляем судоку и выводим
            sudoku.Show();
            Console.WriteLine();
            answerSudoku.setGrid(grid);
            answerSudoku.Show();
            Console.WriteLine();
            Console.WriteLine(res);

            // Создаем экземпляр ResultForm и передаем ему результат
            Result resultForm = new Result(res);
            this.DialogResult = DialogResult.OK;
            resultForm.ShowDialog();
            this.Close();

            // Открываем форму результатов модально
        }
    }
}
