using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3._2
{
    class MergeSort
    {
        // 归并排序算法入口
        public static void MergeSortAlgorithm(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                // 分割数组为两个子数组
                MergeSortAlgorithm(arr, left, mid);
                MergeSortAlgorithm(arr, mid + 1, right);
                // 合并两个有序子数组
                Merge(arr, left, mid, right);
            }
        }

        // 合并函数，将两个有序数组合并为一个有序数组
        public static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            // 创建临时数组来存储两个子数组
            int[] L = new int[n1];
            int[] R = new int[n2];

            // 将数据复制到临时数组中
            for (int i = 0; i < n1; i++)
            {
                L[i] = arr[left + i];
            }

            for (int j = 0; j < n2; j++)
            {
                R[j] = arr[mid + 1 + j];
            }

            int k = left;
            int i1 = 0;
            int i2 = 0;
           
            // 合并两个子数组
            while (i1 < n1 && i2 < n2)
            {
                if (L[i1] <= R[i2])
                {
                    arr[k] = L[i1];
                    i1++;
                }
                else
                {
                    arr[k] = R[i2];
                    i2++;
                }
                k++;
            }

            //如果其中一个子数组还有剩余元素未处理，为了保持合并后的数组的有序性，需要将剩余元素依次复制到原始数组的相应位置。
            // 复制剩余元素
            while (i1 < n1)
            {
                arr[k] = L[i1];
                i1++;
                k++;
            }

            while (i2 < n2)
            {
                arr[k] = R[i2];
                i2++;
                k++;
            }
        }

        // 主函数，用于测试归并排序算法
        public static void Main()
        {
            int[] arr = { 12, 4, 5, 6, 7, 3, 1, 15, 10, 9 };
            Console.WriteLine("排序前数组:");
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            MergeSortAlgorithm(arr, 0, arr.Length - 1);

            Console.WriteLine("归并排序后数组:");
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
            Console.ReadKey();
        }
    }
}
