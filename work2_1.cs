using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 斐波那契数列中的前两个数是1和1,从第三个数开始，每个数等于前两个数的和。
/// 编程计算此数列的前30个数，且每行输出5个数。
/// </summary>
namespace Work2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("需要计算的前多少个斐波那契？ ");
            string sline = Console.ReadLine();
            int n = int.Parse(sline);
            Fib(n);
            Console.ReadKey();
        }
        
        private static void Fib(int n)
        {
            int a = 1, b = 1, c = 0, i;
            Console.Write("{0}\t{1}\t", a, b);
            for (i = 3; i <= n; i++)
            {
                c = a + b;
                Console.Write("{0}\t", c);
                if (i % 5 == 0)
                {
                    Console.WriteLine();
                }
                a = b; b = c;
            }
        }
    }
}
