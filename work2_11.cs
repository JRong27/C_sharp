using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 设计一个程序，求一个4x4矩阵两对角线元素之和。
/// </summary>
namespace Work2_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请依次输入矩阵元素，先行后列：");
            int[,] arr = new int[4, 4];
            int i, j, sum = 0;
            for(i = 0; i < 4; i++)
            {
                for(j = 0; j <4; j++)
                {
                    string n = Console.ReadLine();
                    arr[i,j] = int.Parse(n);
                }
            } 
            for(i = 0; i <4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    if(i == j || i +j == 3)
                    {
                        sum += arr[i, j];
                    }
                }
            }
            Console.WriteLine("两条对角线元素之和为{0}", sum);
            Console.Read();
        }
    }
}
