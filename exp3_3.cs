using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp3_3
{
    enum MonthName
    {
        January, Fabruary, March, Apirl, May, June, July, August, September, Octobor, November, December
    }
    class WhatDay
    {
        static System.Collections.ICollection DaysInMonth= new int[12]
        { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        static System.Collections.ICollection DaysInMonth1 = new int[12]
        { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Please input year：");
                string sline = Console.ReadLine();
                int yearNum = int.Parse(sline);
                bool isLeapYear = (yearNum % 4 == 0 && yearNum % 100 != 0 || yearNum % 400 == 0);
                int maxDayNum = isLeapYear ? 366 : 365;
                Console.Write("Please input a day number bettween 1 and {0}； ",maxDayNum);
                sline = Console.ReadLine();
                int dayNum = int.Parse(sline);
                if(dayNum < 1 || dayNum > maxDayNum)
                {
                    throw new ArgumentOutOfRangeException("Day out of Range!");
                }
                int monthNum = 0;
                if (maxDayNum == 365)
                {
                    foreach (int daysInMonth in DaysInMonth)
                    {
                        if (dayNum <= daysInMonth)
                        {
                            break;
                        }
                        else
                        {
                            dayNum -= daysInMonth;
                            monthNum++;
                        }
                    }
                }else {
                    foreach (int daysInMonth in DaysInMonth1)
                    {
                        if (dayNum <= daysInMonth)
                        {
                            break;
                        }
                        else
                        {
                            dayNum -= daysInMonth;
                            monthNum++;
                        }
                    }
                }
                
                MonthName temp = (MonthName)monthNum;
                string monthNanme = Enum.Format(typeof(MonthName), temp, "g");
                Console.WriteLine("{0},{1}",dayNum,monthNanme);
                Console.Read();
            }
            catch(Exception caught)
            {
               Console.WriteLine("caudht");
            }
        }
    }
}
