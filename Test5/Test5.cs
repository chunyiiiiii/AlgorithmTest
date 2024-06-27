using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 示例数塔
        int[][] tower = new int[][]
        {
            new int[] { 9 },
            new int[] { 12, 15 },
            new int[] { 10, 6, 8 },
            new int[] { 2, 18, 9, 5 },
            new int[] { 19, 7, 10, 4, 16 }
        };

        // 输出数塔
        Console.WriteLine("数塔:");
        PrintTower(tower);

        // 输出最大路径和
        Console.WriteLine("\n最大路径和:");
        int maxSum = MaxPathSum(tower, out List<int> path, out int[][] pathChoice);
        Console.WriteLine(maxSum);  // 输出 30

        // 输出最大路径
        Console.WriteLine("\n最大路径:");
        foreach (var node in path)
        {
            Console.Write(node + " ");
        }
        Console.WriteLine();

        // 输出 pathChoice 矩阵
        Console.WriteLine("\n路径选择矩阵 (pathChoice):");
        PrintPathChoice(pathChoice);

        Console.ReadKey();
    }

    static int MaxPathSum(int[][] tower, out List<int> path, out int[][] pathChoice)
    {
        if (tower == null || tower.Length == 0)
        {
            path = new List<int>();
            pathChoice = new int[0][];
            return 0;
        }

        int n = tower.Length;
        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[tower[i].Length];
            Array.Copy(tower[i], dp[i], tower[i].Length);
        }

        // 记录路径选择
        pathChoice = new int[n][];
        for (int i = 0; i < n; i++)
        {
            pathChoice[i] = new int[tower[i].Length];
        }

        for (int i = n - 2; i >= 0; i--)
        {
            for (int j = 0; j < tower[i].Length; j++)
            {
                if (dp[i + 1][j] > dp[i + 1][j + 1])
                {
                    dp[i][j] += dp[i + 1][j];
                    pathChoice[i][j] = j; // 选择左边
                }
                else
                {
                    dp[i][j] += dp[i + 1][j + 1];
                    pathChoice[i][j] = j + 1; // 选择右边
                }
            }
        }

        // 重建路径
        path = new List<int>();
        int col = 0;
        for (int row = 0; row < n; row++)
        {
            path.Add(tower[row][col]);
            col = pathChoice[row][col];
        }

        return dp[0][0];
    }

    static void PrintTower(int[][] tower)
    {
        int n = tower.Length;
        int maxWidth = n * 2 - 1;

        for (int i = 0; i < n; i++)
        {
            int numElements = tower[i].Length;
            int spacesBefore = (maxWidth - (numElements * 2 - 1)) / 2;

            Console.Write(new string(' ', spacesBefore));
            for (int j = 0; j < numElements; j++)
            {
                Console.Write(tower[i][j]);
                if (j < numElements - 1)
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }

    static void PrintPathChoice(int[][] pathChoice)
    {
        for (int i = 0; i < pathChoice.Length; i++)
        {
            for (int j = 0; j < pathChoice[i].Length; j++)
            {
                Console.Write(pathChoice[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
}