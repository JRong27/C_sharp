using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 设计一个程序，输入一个四位整数，1234则输出4321。
/// 要求必须用循环语句实现。将各位数字分开，并按其反序输出。
/// </summary>
namespace Work2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个四位数：");
            string sline = Console.ReadLine();
            int n = int.Parse(sline);
            while(n != 0)
            {
                Console.Write("{0}", n % 10);
                n = n / 10;
            }
            Console.ReadKey();
        }
    }
}
