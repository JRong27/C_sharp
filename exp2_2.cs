using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double sum = 0.5, t, t1, t2, t3, p = 0.5 * 0.5;
            int odd = 1, even = 2;
            t = t1 = t2 = 1.0;  t3 = 0.5;
            //初始程序
            while (t > 1e-10)
            {
                t1 = t1 * odd / even;
                odd += 2; even += 2;
                t2 = 1.0 / odd;
                t3 = t3 * p;
                t = t1 * t2 * t3;
                sum += t;
            }
            //Console.WriteLine("\nPI = {0,10:f8}", sum * 6);
            //Console.ReadLine();
            //B1要求
            do
            {
                t1 = t1 * odd / even;
                odd += 2; even += 2;
                t2 = 1.0 / odd;
                t3 = t3 * p;
                t = t1 * t2 * t3;
                sum += t;
            } while (t > 1e-10);
            //Console.WriteLine("\nPI = {0,10:f8}", sum * 6);
            //Console.ReadLine();

            //B2要求
            Console.Write("请输入圆的半径 r：");
            double r = double.Parse(Console.ReadLine());
            Console.WriteLine("半径为 {0} 的圆面积 = {1,10:f8}", r, sum * 6 * Math.Pow(r,2));
            Console.ReadLine();
        }
    }
}
