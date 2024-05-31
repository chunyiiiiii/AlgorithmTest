using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CausalStudy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = 0;
            bool isCheck = true;
            while (isCheck)
            {
                Console.WriteLine("请输入你的年龄");
                string str = Console.ReadLine();

                try
                {
                    age = int.Parse(str);
                    isCheck = false;
                }
                catch
                {
                    Console.WriteLine("请输入一个正确的年龄！");
                }
            }
            age = age + 10;
            Console.WriteLine("你十年后的年龄是："+age.ToString());
            Console.ReadKey();
        }
    }
}
