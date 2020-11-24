using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 设计一个程序，输出所有的水仙花数。
/// 所谓水仙花数是一个三位整数，其各位数字的立方和等于该数的本身。
/// 例如，153=1^3+5^3+3^3。
/// </summary>
namespace Work2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Narcissus();
            Console.ReadKey();
        }
        public static void Narcissus()
        {
            int x, y, z;
            for(int i = 100; i < 999; i++)
            {   //百，十，个
                x = i / 100;
                y = (i / 10) % 10;
                z = i % 10;
                if(Math.Pow(x,3) + Math.Pow(y,3) + Math.Pow(z,3) == i)
                {
                    Console.WriteLine("{0}", i);
                }
            }
        }
    }
}
