using System;
using System.Collections.Generic;

public class Knapsack
{
    private int[] weights;
    private int[] values;
    private int W;
    private int n;
    private int maxValue;
    private List<int> bestSolution;

    public Knapsack(int[] weights, int[] values, int W)
    {
        this.weights = weights;
        this.values = values;
        this.W = W;
        this.n = weights.Length;
        this.maxValue = 0;
        this.bestSolution = new List<int>();
    }

    public void Solve()
    {
        Backtrack(0, 0, 0, new List<int>());
        Console.WriteLine($"背包最大承重: {W}");
        Console.WriteLine("物品列表 (格式: 重量, 价值):");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"物品{i + 1}: {weights[i]}, {values[i]}");
        }
        Console.WriteLine("=================================");
        Console.WriteLine("最大价值: " + maxValue);
        Console.WriteLine("最佳选择方案: ");
        foreach (int i in bestSolution)
        {
            Console.WriteLine($"物品{i + 1} - 重量: {weights[i]}, 价值: {values[i]}");
        }
    }

    private void Backtrack(int i, int currentWeight, int currentValue, List<int> currentSolution)
    {
        if (i >= n)
        {
            if (currentValue > maxValue)
            {
                maxValue = currentValue;
                bestSolution = new List<int>(currentSolution);
            }
            return;
        }

        // 检查是否可以选择当前物品
        if (currentWeight + weights[i] <= W)
        {
            currentSolution.Add(i);
            Backtrack(i + 1, currentWeight + weights[i], currentValue + values[i], currentSolution);
            currentSolution.RemoveAt(currentSolution.Count - 1);
        }

        // 不选择当前物品
        Backtrack(i + 1, currentWeight, currentValue, currentSolution);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // 预定义的数据集
        int[] weights = { 2, 3, 4, 5 };
        int[] values = { 3, 4, 5, 6 };
        int W = 5;

        Knapsack knapsack = new Knapsack(weights, values, W);
        knapsack.Solve();
        Console.ReadKey();
    }
}