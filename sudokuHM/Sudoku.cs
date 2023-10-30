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
        private int[,] answerGrid;
        private int[,] playerGrid;
        private int difficult;
        private Random random = new Random();

        //n=9
        public Sudoku(int number, int difficult)
        {

            this.difficult = difficult;

            answerGrid = new int[number, number];
            playerGrid = new int[number, number];



            //for (int i = 0; i < number; i++)
            //{
            //    for (int j = 0; j < number; j++)
            //    {
            //        answerGrid[i, j] = 0;
            //    }
            //}

            GenerateGrid();
        }


        public int[,] AnswerGrid
        {
            get { return answerGrid; }
            set { answerGrid = value; }
        }

        public int Difficulty
        {
            get { return difficult; }
            set { difficult = value; }
        }

        //-------------------------------
        //|{1}{2}{3}|{4}{ }{ }|{ }{ }{ }|
        //|{9}{8}{4}|{ }{ }{ }|{ }{ }{ }|
        //|{6}{7}{5}|{ }{ }{ }|{ }{ }{ }|
        //|---------|---------|---------|
        //|{ }{ }{ }|{2}{3}{1}|{ }{ }{ }|
        //|{ }{ }{ }|{9}{4}{6}|{ }{ }{ }|
        //|{ }{ }{ }|{7}{5}{8}|{ }{ }{ }|
        //|---------|---------|---------|
        //|{ }{ }{ }|{ }{ }{ }|{5}{6}{9}|
        //|{ }{ }{ }|{ }{ }{ }|{7}{1}{2}|
        //|{ }{ }{ }|{ }{ }{ }|{4}{3}{8}|
        //-------------------------------

        //sumOneGrid=45

        public void FillOther()
        {
            for (int i = 0; i < answerGrid.GetLength(0); i++)
            {
                for (int j = 0; j < answerGrid.GetLength(1); j ++)
                {
                    if (answerGrid[i, j] == 0)
                    {
                        FillCell(i, j);
                    }
                }
            }
        }


        // нет свободных чисел в строке и колонке 
        public void FillCell(int row, int col)
        {
            int a = 0;
            for (int i = 1; i <= 9; i++)
            {
                a = i;
                if(CheckNumberByCol(a,col,row) && CheckNumberByRow(a, row, col))
                {
                    break;
                }
            }
            answerGrid[row, col] = a;
        }

        //public void FillCell(int row, int col)
        //{

        //    List<int> cells = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        //    for (int i = row; i < row + 3; i++)
        //    {
        //        for (int j = col; j < col + 3; j++)
        //        {
        //            for (int k = 0; k < cells.Count; k++)
        //            {
        //                if (CheckNumberByRow(k, i, j) && CheckNumberByCol(k, j, i))
        //                {
        //                    answerGrid[i, j] = k;
        //                    cells.Remove(k);
        //                    break;
        //                }
        //                if (k == cells.Count - 1)
        //                {
        //                    List<int> available = new List<int>();

        //                    for (int t = 1; t <= 9; t++)
        //                    {
        //                        if (CheckNumberByRow(k, i, j) && CheckNumberByCol(k, j, i))
        //                        {
        //                            available.Add(t);
        //                        }
        //                    }
        //                    for (int e = row; e < row + 3; e++)
        //                    {
        //                        for (int b = col; b < col + 3; b++)
        //                        {
        //                            for (int ati = 0; ati < cells.Count; ati++)
        //                            {
        //                                if (available.Contains(answerGrid[e, b]) && CheckNumberByRow(cells[ati], e, b) && CheckNumberByCol(cells[ati], b, e))
        //                                {
        //                                    answerGrid[i, j] = answerGrid[e, b];
        //                                    answerGrid[e, b] = cells[ati];
        //                                    cells.RemoveAt(0);
        //                                    e = row + 3;
        //                                    break;
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }

        //}



        //-------------------------------
        //|{1}{2}{3}|{4}{6}{5}|{ }{ }{ }|
        //|{9}{8}{4}|{1}{2}{3}|{ }{ }{ }|
        //|{6}{7}{5}|{8}{9}{}|{ }{ }{ }|
        //|---------|---------|---------|
        //|{ }{ }{ }|{2}{3}{1}|{ }{ }{ }|
        //|{ }{ }{ }|{9}{4}{6}|{ }{ }{ }|
        //|{ }{ }{ }|{7}{5}{8}|{ }{ }{ }|
        //|---------|---------|---------|
        //|{ }{ }{ }|{ }{ }{ }|{5}{6}{9}|
        //|{ }{ }{ }|{ }{ }{ }|{7}{1}{2}|
        //|{ }{ }{ }|{ }{ }{ }|{4}{3}{8}|
        //-------------------------------


        public bool CheckNumberByRow(int number, int row, int exeptId)
        {
            for (int i = 0; i < answerGrid.GetLength(1); i++)
            {
                if (answerGrid[row, i] == number)
                {
                    return false;
                }
                else if (i == exeptId)
                {
                    continue;
                }

            }
            return true;
        }

        public bool CheckNumberByCol(int number, int col, int exeptId)
        {
            for (int i = 0; i < answerGrid.GetLength(0); i++)
            {
                if (answerGrid[i, col] == number)
                {
                    return false;
                }
                else if (i == exeptId)
                {
                    continue;
                }
            }
            return true;
        }

        public void FillDiagonal()
        {

            for (int block = 0; block < 3; block++)
            {
                int row = block * 3;
                int col = block * 3;

                List<int> numbers = GenerateNumbers(1, 9);

                for (int i = 0; i < 9; i++)
                {
                    answerGrid[row, col] = numbers[i];
                    col++;

                    if (col % 3 == 0)
                    {
                        col = block * 3;
                        row++;
                    }
                }
            }

        }

        private List<int> GenerateNumbers(int min, int max)
        {
            List<int> numbers = new List<int>();

            for (int i = min; i <= max; i++)
            {
                numbers.Add(i);
            }

            int n = numbers.Count;
            for (int i = n - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                int temp = numbers[i];
                numbers[i] = numbers[j];
                numbers[j] = temp;
            }

            return numbers;
        }

        public void GenerateGrid()
        {
            FillDiagonal();
            FillOther();
        }

    }
}
