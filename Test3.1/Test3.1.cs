using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3._1
{
    class QuickSort
    {
        // 快速排序算法入口
        public static void QuickSortRandom(int[] arr, int left, int right)
        {
            if (left < right)
            {
                // 获取分割点索引
                int pivotIndex = Partition(arr, left, right);
                // 递归排序左侧和右侧子数组
                QuickSortRandom(arr, left, pivotIndex - 1);
                QuickSortRandom(arr, pivotIndex + 1, right);
            }
        }

        // 分割函数，选择随机基准元素
        public static int Partition(int[] arr, int left, int right)
        {
            // 生成随机索引
            Random random = new Random();
            int randomIndex = random.Next(left, right + 1);
            // 将随机索引处元素与最右侧元素交换
            Swap(arr, randomIndex, right);

            // 设定基准元素
            int pivot = arr[right];
            int i = left - 1;

            // 遍历数组，将小于等于基准的元素放在左侧，大于基准的元素放在右侧
            for (int j = left; j < right; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            // 将基准元素放置在正确的位置
            Swap(arr, i + 1, right);
            return i + 1; // 返回基准元素索引
        }

        // 交换数组中两个元素的位置
        public static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        // 主函数，用于测试快速排序算法
        public static void Main()
        {
            int[] arr = { 12, 4, 5, 6, 7, 3, 1, 15, 10, 9 };
            Console.WriteLine("排序前数组:");
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
            QuickSortRandom(arr, 0, arr.Length - 1);

            Console.WriteLine("快速排序后数组:");
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
            Console.ReadKey();
        }
    }
}
