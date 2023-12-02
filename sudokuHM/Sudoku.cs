using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudokuHM
{
    internal class Sudoku
    {

        private int[,] grid;
        private int difficult;
        private Random random = new Random();

        //n=9
        public Sudoku(int difficult)
        {

            this.difficult = difficult;

            grid = new int[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    grid[j, i] = ((i * 3 + i / 3 + j) % (9) + 1);
                }
            }


            //GenerateGrid();
        }
        public void Show()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public Sudoku(int[,] grid)
        {
            this.grid = grid;

        }
        public Sudoku() { }

        public int[,] getGrid() { return grid; }
        public void setGrid(int[,] grid)
        {
            this.grid = grid;
        }

        private void Transposing()
        {
            grid = TransposeMatrix(grid);
        }

        private void SwapRowsSmall()
        {
            int area = random.Next(0, 3);
            int line1 = random.Next(0, 3);
            int N1 = area * 3 + line1;

            int line2 = random.Next(0, 3);
            while (line1 == line2)
            {
                line2 = random.Next(0, 3);
            }

            int N2 = area * 3 + line2;

            SwapRows(N1, N2);
        }

        private void SwapRows(int row1, int row2)
        {
            for (int j = 0; j < 9; j++)
            {
                int temp = grid[row1, j];
                grid[row1, j] = grid[row2, j];
                grid[row2, j] = temp;
            }
        }

        private void SwapColumnsSmall()
        {
            Transposing();
            SwapRowsSmall();
            Transposing();
        }

        private void SwapRowsArea()
        {
            int area1 = random.Next(0, 3);

            int area2 = random.Next(0, 3);
            while (area1 == area2)
            {
                area2 = random.Next(0, 3);
            }

            for (int i = 0; i < 3; i++)
            {
                int N1 = area1 * 3 + i;
                int N2 = area2 * 3 + i;
                SwapRows(N1, N2);
            }
        }

        private void SwapColumnsArea()
        {
            Transposing();
            SwapRowsArea();
            Transposing();
        }

        public void Mix(int amt = 10)
        {
            Action[] mixFunc = { Transposing, SwapRowsSmall, SwapColumnsSmall, SwapRowsArea, SwapColumnsArea };

            for (int i = 1; i < amt; i++)
            {
                int idFunc = random.Next(0, mixFunc.Length);
                mixFunc[idFunc].Invoke();
            }
        }

        // Метод для транспонирования матрицы
        private int[,] TransposeMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[,] result = new int[cols, rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }

            return result;
        }
        //удаление чисел
        public static int[,] RemoveCells(int[,] originalGrid, int difficulty, Random random)
        {
            int N = 9;
            var flook = new int[N * N];
            int iterator = 0;

            int[,] grid = new int[N, N];
            Array.Copy(originalGrid, grid, N * N);

            while (iterator < difficulty)
            {
                int i = random.Next(0, N);
                int j = random.Next(0, N);

                if (flook[i * N + j] == 0)
                {
                    iterator++;
                    flook[i * N + j] = 1;

                    grid[i, j] = 0;
                }
            }
            return grid;
        }
        public void UpdateGrid(int[,] newGrid)
        {
            this.grid = newGrid;
        }
        // проверка
        public static bool CheckResults(int[,] originalMatrix, int[,] answerMatrix)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (originalMatrix[i, j] != answerMatrix[i, j])
                    {
                        // Если хотя бы один элемент не совпадает, возвращаем false
                        return false;
                    }
                }
            }
            // Если все элементы совпадают, возвращаем true
            return true;
        }
    }
}

