using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 输入一组非0整数(以0作为结束标志)到一维数组中，求出这一 组数的平均值，并统计出正数和负数的个数。
/// </summary>
namespace Work2_10
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[30];
            Console.WriteLine("请输入一维数组长度（<=30）:");
            string sline = Console.ReadLine();
            int len = int.Parse(sline);
            int i;
            Console.WriteLine("请输入一维数组的元素:");
            for (i = 0; i < len; i++)
            {
                sline = Console.ReadLine();
                arr[i] = int.Parse(sline);
            }
            double sum = 0;
            int plus = 0;
            int minus = 0;
            for(i = 0; i < len; i++)
            {
                sum += arr[i];
                if (arr[i] > 0)
                {
                    plus++;
                }
                else if (arr[i] < 0)
                {
                    minus++;
                }
            }
            Console.WriteLine("平均数为：{0}\n正数个数：{1}\t负数个数：{2}",sum/len, plus, minus);
            Console.ReadLine();
        }
    }
}
