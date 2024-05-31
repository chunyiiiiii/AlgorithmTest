using System;

class Program
{
    static void Main()
    {
        Console.Write("请输入一个正整数 n：");
        int n = Convert.ToInt32(Console.ReadLine());

        int[,] matrix = GenerateSpiralMatrix(n);

        Console.WriteLine("生成的内螺旋方阵为：");
        PrintMatrix(matrix);
        Console.ReadKey();
    }

    static int[,] GenerateSpiralMatrix(int n)
    {
        //创建一个大小为 n x n 的二维整数数组 matrix，用于存储生成的螺旋方阵。
        int[,] matrix = new int[n, n];
        int value = n * n;
        //初始化四个边界变量 top、bottom、left、right，分别表示当前填充的区域的上边界、下边界、左边界和右边界。
        int top = 0, bottom = n - 1, left = 0, right = n - 1;

        while (value >= 1)
        {
            //从左到右填充当前上边界，填充数字为 value，并将 value 减一。
            for (int i = left; i <= right; i++)
            {
                matrix[top, i] = value--;
            }
            //更新上边界 top。
            top++;

            for (int i = top; i <= bottom; i++)
            {
                matrix[i, right] = value--;
            }
            right--;

            for (int i = right; i >= left; i--)
            {
                matrix[bottom, i] = value--;
            }
            bottom--;

            for (int i = bottom; i >= top; i--)
            {
                matrix[i, left] = value--;
            }
            left++;
        }

        return matrix;
    }

    static void PrintMatrix(int[,] matrix)
    {
        int n = (int)Math.Sqrt(matrix.Length);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}