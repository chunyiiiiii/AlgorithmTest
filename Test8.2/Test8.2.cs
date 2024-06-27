using System;
using System.Collections.Generic;

public class Loading
{
    private int[] weights;
    private int W;
    private int n;
    private int maxWeight;
    private List<int> bestSolution;

    public Loading(int[] weights, int W)
    {
        this.weights = weights;
        this.W = W;
        this.n = weights.Length;
        this.maxWeight = 0;
        this.bestSolution = new List<int>();
    }

    public void Solve()
    {
        Backtrack(0, 0, new List<int>());
        Console.WriteLine($"最大承载重量: {W}");
        Console.WriteLine("物品列表 (格式: 重量):");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"物品{i + 1}: {weights[i]}");
        }
        Console.WriteLine("=================================");
        Console.WriteLine("最大重量: " + maxWeight);
        Console.WriteLine("最佳选择方案: ");
        foreach (int i in bestSolution)
        {
            Console.WriteLine($"物品{i + 1} - 重量: {weights[i]}");
        }
    }

    private void Backtrack(int i, int currentWeight, List<int> currentSolution)
    {
        if (i >= n)
        {
            if (currentWeight > maxWeight)
            {
                maxWeight = currentWeight;
                bestSolution = new List<int>(currentSolution);
            }
            return;
        }

        // 检查是否可以选择当前物品
        if (currentWeight + weights[i] <= W)
        {
            currentSolution.Add(i);
            Backtrack(i + 1, currentWeight + weights[i], currentSolution);
            currentSolution.RemoveAt(currentSolution.Count - 1);
        }

        // 不选择当前物品
        Backtrack(i + 1, currentWeight, currentSolution);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // 预定义的数据集
        int[] weights = { 2, 3, 4, 5 };
        int W = 5;

        Loading loading = new Loading(weights, W);
        loading.Solve();
        Console.ReadKey();
    }
}