using System;

class Program
{
    static void Main()
    {
        int[] arr = { -2, 11, -4, 13, -5, -2 };
        int maxSum = MaxSubArraySum(arr);
        Console.WriteLine("最大子段和为: " + maxSum);
        Console.ReadKey();
    }
    static int MaxSubArraySum(int[] arr)
    {
        int n = arr.Length;
        int[] dp = new int[n];
        dp[0] = Math.Max(0, arr[0]);
        int maxSum = dp[0];
        // 输出初始值
        Console.WriteLine($"dp[0]: {dp[0]}");
        for (int i = 1; i < n; i++)
        {
            dp[i] = Math.Max(0, dp[i - 1] + arr[i]);
            maxSum = Math.Max(maxSum, dp[i]);

            // 输出每一步的中间结果
            Console.WriteLine($"dp[{i}]: {dp[i]}");
        }
        return maxSum;
    }
}