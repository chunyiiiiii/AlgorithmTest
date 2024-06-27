using System;

class MatrixChainMultiplication
{
    // 函数用于查找计算给定矩阵链所需的最少标量乘法次数
    public static int MatrixChainOrder(int[] p, int n, out int[,] s)
    {
        int[,] m = new int[n, n];
        s = new int[n, n];
        int i, j, k, L, q;

        // m[i, j] = 计算矩阵Ai...j的最少标量乘法次数，其中Ai Ai+1...Aj
        // 当只计算一个矩阵时，乘法次数为0
        for (i = 1; i < n; i++)
            m[i, i] = 0;
        // L表示链的长度。
        for (L = 2; L < n; L++)
        {
            for (i = 1; i < n - L + 1; i++)
            {
                j = i + L - 1;
                m[i, j] = int.MaxValue;
                for (k = i; k <= j - 1; k++)
                {
                    // q = 成本/标量乘法次数
                    q = m[i, k] + m[k + 1, j] + p[i - 1] * p[k] * p[j];
                    if (q < m[i, j])
                    {
                        m[i, j] = q;
                        s[i, j] = k; // 记录最优分割点
                    }
                }
            }
        }
        return m[1, n - 1];
    }

    // 打印最优矩阵链的组合
    public static void PrintOptimalParens(int[,] s, int i, int j)
    {
        if (i == j)
        {
            Console.Write($"A{i}");
        }
        else
        {
            Console.Write("(");
            PrintOptimalParens(s, i, s[i, j]);
            PrintOptimalParens(s, s[i, j] + 1, j);
            Console.Write(")");
        }
    }

    public static void Main()
    {
        Console.WriteLine("请输入矩阵的个数：");
        int numMatrices = int.Parse(Console.ReadLine());

        int[] dimensions = new int[numMatrices + 1];

        for (int i = 0; i < numMatrices; i++)
        {
            Console.WriteLine($"请输入矩阵 A{i + 1} 的行数和列数：");
            Console.Write("行数：");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("列数：");
            int cols = int.Parse(Console.ReadLine());

            dimensions[i] = rows; // 保存行数
            if (i == numMatrices - 1)
            {
                dimensions[i + 1] = cols; // 保存最后一个矩阵的列数
            }
        }

        int size = dimensions.Length;
        int[,] s;

        int minMultiplications = MatrixChainOrder(dimensions, size, out s);

        Console.WriteLine("最少的乘法次数是 " + minMultiplications);
        Console.Write("最优矩阵乘法顺序是：");
        PrintOptimalParens(s, 1, size - 1);
        Console.WriteLine();
        Console.ReadKey();
    }
}