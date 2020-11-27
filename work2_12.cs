using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 输入一个字符串，串内有数字和非数字字符，例如，abe2345 345fdf678 jdhfg945。
/// 将其中连续的数字作为一个整数，依次存放到另一个整型数组b中。
/// 如将2345存放到b[0],345放入b[1]，678放入b[2],……统计出字符串中的整数个数，并输出这些整数。
/// </summary>
namespace Work2_12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个字符串：");
            string s = Console.ReadLine();
            char[] arr = s.ToCharArray();
            
            int k = 0;
            int len = arr.Length;

            Console.WriteLine("字符串中的整数：");
            while (k < len -1)
            {
                string num = " ";  //每次更新 num
                for (; k < len && arr[k] >= 'a' && arr[k] <= 'z'; k++) ;
                for (; k < len && arr[k] >= '0' && arr[k] <= '9'; k++)
                {
                    num += arr[k];
                }
                Console.Write("{0}  ", num);
            }
            Console.Read();
        }
    }
}
