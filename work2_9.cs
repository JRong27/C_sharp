using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work2_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个字符串：");
            string s = Console.ReadLine();
            char[] arr = s.ToCharArray();

            IsPalindrome(arr);
            Console.Read();
        }

        static public void IsPalindrome(char[] arr)
        {
            //方法一：
            int len = arr.Length;
            int head = 0, tail = len - 1;
            int flag = len / 2; ;
            while (head < tail)
            {
                if (arr[head] == arr[tail])
                {
                    head++;
                    tail--;
                }
                else
                {
                    Console.WriteLine("不是回文！");
                    break;
                }
            }
            if (flag == head)
            {
                Console.WriteLine("是回文！");
            }
        }
    }
}
//方法二：
//    int len = arr.Length;
//    char[] opp = new char[len];
//    foreach(char x in arr)  //将原数组arr[]字符元素反向存入新数组opp[]
//    {
//        opp[len - 1] = x;
//        len--;
//    }

//    int i;
//    for (i = 0; i < len; i++)
//    {
//        if (opp[i] == arr[i])
//        {
//            continue;
//        }
//        else
//        {
//            Console.WriteLine("不是回文！");
//            break;
//        }
//    }
//    if (i == len - 1)
//    {
//        Console.WriteLine("是回文！");
//    }
//}
