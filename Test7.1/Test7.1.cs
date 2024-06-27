using System;
using System.Linq;

class Program
{
    // 定义物品类
    public class Item
    {
        public int Id { get; set; } // 物品编号
        public double Weight { get; set; }
        public double Value { get; set; }
        public double ValuePerWeight => Value / Weight;
        public double Fraction { get; set; } // 用于记录装入的比例
    }

    static void Main(string[] args)
    {
        // 定义物品和背包最大重量
        int n = 3; // 物品数量
        double[] weights = { 10, 20, 30 }; // 每个物品的重量
        double[] values = { 60, 100, 120 }; // 每个物品的价值
        double W = 50; // 背包的最大重量

        // 创建物品列表
        Item[] items = new Item[n];
        for (int i = 0; i < n; i++)
        {
            items[i] = new Item { Id = i + 1, Weight = weights[i], Value = values[i], Fraction = 0 };
        }

        // 输出初始物品信息和背包最大容量
        Console.WriteLine("初始物品信息:");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"物品{items[i].Id} - 重量: {weights[i]}, 价值: {values[i]}");
        }
        Console.WriteLine($"背包最大容量: {W}");
        Console.WriteLine();

        // 按单位重量价值比排序
        var sortedItems = items.OrderByDescending(item => item.ValuePerWeight).ToArray();

        double totalValue = 0;
        double currentWeight = 0;

        // 遍历物品，选择尽可能多的物品装入背包
        foreach (var item in sortedItems)
        {
            if (currentWeight + item.Weight <= W)
            {
                // 完全装入
                currentWeight += item.Weight;
                totalValue += item.Value;
                item.Fraction = 1;
            }
            else
            {
                // 部分装入
                double remainingWeight = W - currentWeight;
                totalValue += item.ValuePerWeight * remainingWeight;
                item.Fraction = remainingWeight / item.Weight;
                break;
            }
        }

        // 输出结果
        Console.WriteLine($"最大价值: {totalValue}");
        Console.WriteLine("选择的物品:");
        foreach (var item in items)
        {
            if (item.Fraction > 0)
            {
                Console.WriteLine($"物品{item.Id} - 重量: {item.Weight}, 价值: {item.Value}, 装入比例: {item.Fraction:P}");
            }
        }
        Console.ReadKey();
    }
}