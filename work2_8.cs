using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work2_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入数组元素个数：");
            int k = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("请输入数组元素：");
            int[] str = new int[k];
            for(int i = 0; i < k; i++)
            {
                str[i] = Convert.ToInt32(Console.ReadLine());
            }

            int e, max;
            maxElement(str, out e, out max);
            
            Console.WriteLine("最大值下标为[{0}],最大值为{1}", max, e);
            Console.Read();
        }

        static public void maxElement(int[] str, out int elem, out int max)
        {
            elem = 0;
            max = 0;
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] > str[max])
                {
                    max = i;
                }
            }
            elem = str[max];
        }
    }
}
