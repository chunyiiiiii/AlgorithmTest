using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // 读取输入
        int n = int.Parse(Console.ReadLine());
        int[] tianji = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] qiwang = Console.ReadLine().Split().Select(int.Parse).ToArray();

        // 排序
        Array.Sort(tianji);
        Array.Sort(qiwang);

        int tianjiWins = 0;
        int qiwangWins = 0;

        //用 tianjiStart 和 tianjiEnd 表示田忌的最慢和最快马匹。
        int tianjiStart = 0, tianjiEnd = n - 1;
        //用 qiwangStart 和 qiwangEnd 表示齐王的最慢和最快马匹。
        int qiwangStart = 0, qiwangEnd = n - 1;

        while (tianjiStart <= tianjiEnd)
        {
            // 优先让田忌的最快马匹对抗齐王的最快马匹：
            if (tianji[tianjiEnd] > qiwang[qiwangEnd])
            {
                tianjiWins++;
                tianjiEnd--;
                qiwangEnd--;
            }

            //其次让田忌的最慢马匹对抗齐王的最慢马匹：
            else if (tianji[tianjiStart] > qiwang[qiwangStart])
            {
                tianjiWins++;
                tianjiStart++;
                qiwangStart++;
            }

            //最后让田忌的最慢马匹对抗齐王的最快马匹：
            else
            {
                qiwangWins++;
                tianjiStart++;
                qiwangEnd--;
            }
        }

        int result = (tianjiWins - qiwangWins) * 200;
        Console.WriteLine(result);
        Console.ReadKey();
    }
}