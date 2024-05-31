using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test4
{
    class ChessboardCover
    {
        // 定义棋盘大小
        private static int size;
        // 定义棋盘数组
        private static int[,] board;
        // 定义骨牌编号
        private static int tile = 0;

        static void Main(string[] args)
        {
            Console.Write("请输入k值(棋盘大小为2^k x 2^k): ");
            int k = int.Parse(Console.ReadLine());
            size = (int)Math.Pow(2, k);
            board = new int[size, size];

            Console.Write("请输入缺失方格的X坐标(0到" + (size - 1) + "): ");
            int missingX = int.Parse(Console.ReadLine());

            Console.Write("请输入缺失方格的Y坐标(0到" + (size - 1) + "): ");
            int missingY = int.Parse(Console.ReadLine());

            // 初始化棋盘，缺失位置设为-1
            board[missingX, missingY] = -1;

            // 开始覆盖
            CoverBoard(0, 0, missingX, missingY, size);

            // 打印覆盖结果
            PrintBoard();
        }

        // 覆盖棋盘的递归函数
        private static void CoverBoard(int startX, int startY, int missingX, int missingY, int size)
        {
            if (size == 1)
                return;

            int t = ++tile;
            int s = size / 2;

            // 覆盖左上角子棋盘
            if (missingX < startX + s && missingY < startY + s)
            {
                CoverBoard(startX, startY, missingX, missingY, s);
            }
            else
            {
                board[startX + s - 1, startY + s - 1] = t;
                CoverBoard(startX, startY, startX + s - 1, startY + s - 1, s);
            }

            // 覆盖右上角子棋盘
            if (missingX < startX + s && missingY >= startY + s)
            {
                CoverBoard(startX, startY + s, missingX, missingY, s);
            }
            else
            {
                board[startX + s - 1, startY + s] = t;
                CoverBoard(startX, startY + s, startX + s - 1, startY + s, s);
            }

            // 覆盖左下角子棋盘
            if (missingX >= startX + s && missingY < startY + s)
            {
                CoverBoard(startX + s, startY, missingX, missingY, s);
            }
            else
            {
                board[startX + s, startY + s - 1] = t;
                CoverBoard(startX + s, startY, startX + s, startY + s - 1, s);
            }

            // 覆盖右下角子棋盘
            if (missingX >= startX + s && missingY >= startY + s)
            {
                CoverBoard(startX + s, startY + s, missingX, missingY, s);
            }
            else
            {
                board[startX + s, startY + s] = t;
                CoverBoard(startX + s, startY + s, startX + s, startY + s, s);
            }
        }

        // 打印棋盘
        private static void PrintBoard()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(board[i, j].ToString().PadLeft(4));
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
