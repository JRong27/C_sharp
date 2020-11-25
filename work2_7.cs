using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work2_7
{
    class Program
    {
        static void Main(string[] args)
        {
            string sline;
            Console.Write("请输入一个浮点数 x：");
            sline = Console.ReadLine();
            double x = double.Parse(sline);
            //double x = Convert.Double(sline);
            Console.Write("请输入一个整数 n：");
            sline = Console.ReadLine();
            int n = int.Parse(sline);
            //int n = Convert.ToInt32(sline);
            try
            {
                Console.WriteLine("Hermite多项式前{0}项的值为{1}", n, Hermite(x, n));
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception:{0}", e.Message);
                Console.Read();
            }
        }

        static double Hermite(double x,int n)  //递归实现
        {
            try
            {
                if (n == 0)
                {
                    Console.Write("1");
                }
                else if (n == 1)
                {
                    x *= 2;
                    Console.Write("{0}", x);
                }
            }
            catch (StackOverflowException e)
            {
                throw new Exception("Exception: Stack is Overflow!", e);
            }
            return 2 * x * Hermite(x, n - 1) - 2 * (n - 1) * Hermite(x, n - 2);
        }
    }
}
