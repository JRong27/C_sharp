using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("请输入一个4位整数");
            string s = Console.ReadLine();

            //B1 判断输入字符串是否都为数字
            int len = s.Length;
            char[] str = s.ToCharArray(); //B2 把四个数字直接保存到数组中
            for (int k = 0; k < len; k++)
            {
                if (str[k] >= 48 && str[k] <= 57)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("输入的字符串符非法！");
                    return;
                }
            }

            //把字符串转化为整型数字（未超出范围），并存入数组each[]
            int num = Convert.ToInt32(s);
            int[] each = new int[4];
            int i, j, min, max, temp;
            //循环执行题目要求的运算
            while (num != 6174 && num != 0)
            {
                i = 0;
                //分离数字
                while (num != 0)
                {
                    each[i++] = num % 10;
                    num = num / 10;
                }
                //传统的冒泡排序，从小到大
                for (i = 0; i < 3; i++)
                {
                    for (j = 0; j < 3-i; j++)
                    {
                        if (each[j] > each[j + 1])
                        {
                            temp = each[j];
                            each[j] = each[j + 1];
                            each[j + 1] = temp;
                        }
                    }
                }
                min = each[0] * 1000 + each[1] * 100 + each[2] * 10 + each[3];
                max = each[3] * 1000 + each[2] * 100 + each[1] * 10 + each[0];
                num = max - min;
                Console.WriteLine("{0}-{1}={2}", max, min, num);
            }
            Console.Read();
        }
    }
}
