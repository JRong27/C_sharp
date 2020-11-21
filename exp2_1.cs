using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp2_1
{
    class TestNumSort
    {
        static void Main(string[] args)
        {
            int a, b, c, d;
            for (a = 1; a <= 4; a++)
                for (b = 1; b <= 4; b++)
                    for (c = 1; c <= 4; c++)
                        if (a != b && a != c && b != c)  //注释1
                        // if (
                        {
                            d = 10 - a - b - c;
                            if (c == 1 ^ b == 2 && c == 2 ^ d == 3 && a == 2 ^ d == 4)  //注释2
                            //枚举替代
                            {
                                //Console.Write("红球放在{0}号，黄球放在{1}号，", a, b);
                                //Console.WriteLine("黑球放在{0}号，白球放在{1}号", c, d);
                                Console.Write("红球放在{0}号，黄球放在{1}号，黑球放在{2}号，白球放在{3}号\n", a, b, c, d);
                            }
                        }
            Console.Read();
        }
    }
}
