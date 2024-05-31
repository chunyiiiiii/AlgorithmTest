using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2._1
{
    class Permutations
    {
        // 生成整数的全排列
        public static void GeneratePermutations(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                // 打印当前排列
                PrintArray(arr);
            }
            else
            {
                for (int i = index; i < arr.Length; i++)
                {
                    // 交换当前位置和下一个位置的元素
                    Swap(arr, i, index);
                    // 递归生成剩余元素的排列
                    GeneratePermutations(arr, index + 1);
                    // 恢复交换前的状态，以便进行下一次交换
                    Swap(arr, i, index);
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
            GeneratePermutations(nums, 0);

            Console.ReadKey();
        }
    }
}
