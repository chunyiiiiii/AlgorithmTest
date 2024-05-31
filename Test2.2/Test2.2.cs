using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2._2
{
    class Permutations
    {
        // 生成整数的全排列（固定元素法）
        public static void GeneratePermutations(int[] arr, int n)
        {
            if (n == 1)
            {
                //  n 等于 1 时，表示只剩下一个元素未确定位置，此时打印当前排列
                PrintArray(arr);
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    GeneratePermutations(arr, n - 1);

                    //根据当前排列的奇偶性来确定交换的位置，保证生成不重复的排列
                    if (n % 2 == 0)
                    {
                        // 交换第i个元素与第n-1个元素的位置
                        Swap(arr, i, n - 1);
                    }
                    else
                    {
                        // 交换第0个元素与第n-1个元素的位置
                        Swap(arr, 0, n - 1);
                    }
                }
            }
        }

        // 交换数组中两个位置的元素
        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        // 打印数组
        private static void PrintArray(int[] arr)
        {
            foreach (var num in arr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        static void Main()
        {
            // 定义整数数组
            int[] nums = { 1, 2, 3, 4 };
            // 生成排列
            GeneratePermutations(nums, nums.Length);

            Console.ReadKey();
        }
    }
}
