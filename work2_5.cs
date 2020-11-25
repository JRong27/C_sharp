using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 求PI/2的近似值的公式为:
/// 其中，n=1,2,3,…。设计一个程序，求当n = 1000时PI的近似值。
/// </summary>
namespace Work2_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1000;
            double m = 1;
            double fz, fm1, fm2;
            for (int i = 1; i <= n; i++)
            {
                fz = 2.0 * i;
                fm1 = fz - 1;
                fm2 = fz + 1;
                m *= (fz / fm1) * (fz / fm2);
            }//不对！！
            Console.Write("{0}", 2 * m);
            Console.ReadKey();
        }
    }
}
