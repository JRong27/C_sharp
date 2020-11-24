using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 从键盘上输入一个整数n的值，按下式求出y,并输出n和y的值(y用浮点数表示):
/// y=1!+2!+3!+ ... + n!
/// </summary>
namespace Work2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("请输入一个整数n：");
            string sline = Console.ReadLine();
            int n = int.Parse(sline);
            Console.WriteLine("n = {0}\ny = {1}",n, Factorial(n));
            Console.ReadKey();
        }

        public static double Factorial(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }
            int k = 1;
            for(int i = 2; i <= n; i++)
            {
                k *= i;
            }
            return k;
        }
    }
}
