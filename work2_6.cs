using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 设计一个程序，输入一个十进制数输出相应的十六进制数。
/// 包括整数和小数？
/// </summary>
namespace Work2_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("请输入一个十进制整数：");
            string sline = Console.ReadLine();
            int n = Convert.ToInt32(sline);
            DtoH(n);
            Console.Read();
        }

        public static void DtoH(int n)
        {
            int temp = n;
            ArrayList list = new ArrayList();  //List无法隐式转换？
            int r;  //余数
            while (n != 0)  //循环执行短除法
            {
                r = n % 16;
                if (r > 9)
                {
                    char c = (char)('A' + (r - 10));
                    list.Insert(0, c);  //插入A~F
                }
                else
                {
                    list.Insert(0, r);  //插入0~9
                }
                n /= 16;  //得到新的商
            }
            Console.Write("{0} 的十六进制数：",temp);
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i]);
            }
        }
    }
}
