using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp3_2
{
    class Card
    {
        long cardNo;
        decimal balance;
        int currentNum;     //发生业务时进行更新，初始值默认为0
        static int number;  //number的值由set访问器获得
        decimal[] currentMoney;  //存放当日存取款金额

        decimal getMoney;   //当日取款金额之和
        long passwrd;   //卡的密码

        public Card()
        {
            currentMoney = new decimal[number];
        }
        public Card(long No, decimal Balance, long Password)
        {
            cardNo = No;
            balance = Balance;
            passwrd = Password;
            currentMoney = new decimal[number];
        }

        public void store(decimal Money, out int status)  //后续需要用status作为相应用户输入业务的响应，要能被带出
        {
            if (Money < 0)  //记录取款金额之和
            {
                getMoney += Money;
                if (getMoney < -5000)
                {
                    getMoney -= Money;
                    status = 2;
                    return;
                }
            }
            if (currentNum == number)  
            {
                status = 0;
                return;  //因为三种状态互斥，所以必须要有return结束
            }
            if(balance + Money < 0)
            {
                status = -1;
                return;
            }
            //以上 2 种情况均不符合，则可正常处理业务
            //记录当日存取金额，更新当前余额，业务次数+1，带出卡的状态
            currentMoney[currentNum] = Money;
            balance += Money;
            currentNum++;
            status = 1;
        }

        //定义访问器，设置当日存取款总次数
        static public int Number
        {
            set
            {
                number = value;
            }
        }
        //定义访问器，得到cardNo,用于后期查看卡号
        public long CardNo
        {
            get
            {
                return cardNo;
            }
        }
        public long CardPassword
        {
            set
            {
                passwrd = value;
            }
            get
            {
                return passwrd;
            }
        }
        //定义显示界面，反馈业务办理结果
        public void show()
        {
            Console.WriteLine("卡号：{0}, 当前余额：{1}, 当日业务发生次数 {2} ", cardNo, balance, currentNum);
        }
    }

    class Test3_2
    {
        static void Main(string[] args)
        {
            Test3_2 T = new Test3_2();
            Card[] person;  //因还不知发行卡数，所以先不new对象
            int Num, k, status, h;
            long CardNo, Password;
            decimal Balance, Money;
            string sline;  //被重复赋值使用

            Console.Write("请输入允许当日存款or取款的总次数：");
            sline = Console.ReadLine();
            Card.Number = int.Parse(sline);  //可能会引发格式异常，若输入回车会导致异常中断。后续应加上捕获异常的语句！！

            Console.Write("请输入某银行发出储蓄卡的总数：");
            sline = Console.ReadLine();
            Num = int.Parse(sline);
            person = new Card[Num];  //一人一卡，有两个固有属性  //增加了密码属性
            for(int i = 0; i < Num; i++)
            {
                Console.Write("请输入卡号：");
                sline = Console.ReadLine();
                CardNo = long.Parse(sline);  //此代码存在不足，输入相同卡号不会报错，有待修改添加判断语句！！
                Console.Write("请输入卡 {0} 的密码（6位）：", CardNo);
                sline = Console.ReadLine();
                Password = long.Parse(sline);
                Console.Write("请输入 {0} 账户余额：",CardNo);
                sline = Console.ReadLine();
                Balance = decimal.Parse(sline);
                person[i] = new Card(CardNo, Balance, Password);
            }
            //业务处理逻辑
            while (true)
            {
                Console.WriteLine("Tip：现在进行存款/取款业务处理，若输入卡号小于0，则业务处理结束");

                Console.Write("请输入卡号：");
                sline = Console.ReadLine();
                CardNo = long.Parse(sline);
                if (CardNo < 0)
                {
                    break;
                }
                k = T.Locate(person, CardNo);  //返回卡号下标
                if (k == -1)
                {
                    Console.WriteLine("对不起，不存在 {0} 号的储蓄卡！", CardNo);
                    continue;
                }

                Console.Write("请输入密码：");
                //sline = Console.ReadLine();
                //Password = long.Parse(sline);
                string pw = string.Empty;
                ConsoleKeyInfo info;  //以下实现代码实现密码遮掩
                do
                {
                    //获取用户按下的下一个字符或功能，且按下的键选择显示在控制台窗口中
                    info = Console.ReadKey(true); 
                    //判断键入内容是否为可打印字符号
                    if (info.Key != ConsoleKey.Enter && info.Key != ConsoleKey.Backspace
                        && info.Key != ConsoleKey.Escape && info.Key != ConsoleKey.Tab
                        && info.KeyChar != '\0')
                    {
                        pw += info.KeyChar;  //这样保存的密码在输入时不可回退重输入
                        Console.Write('*');
                    }
                } while (info.Key != ConsoleKey.Enter);
                Console.WriteLine();

                Password = long.Parse(pw);
                h = T.ComparePaswrd(person, Password);
                if (h != k)
                {
                    Console.WriteLine("对不起，{0} 号的储蓄卡的密码不正确，请重新输入！", CardNo);
                    continue;
                }

                Console.WriteLine("请输入金额（正代表存款，负代表取款）：");
                sline = Console.ReadLine();
                Money = decimal.Parse(sline);
                person[k].store(Money, out status);  //账户的当日状态需在业务处理后更新带出
                switch (status)
                {
                    case -1:
                        Console.WriteLine("本卡余额不足，不能完成本次取款业务！");
                        break;
                    case 0:
                        Console.WriteLine("本卡已达当日允许业务次数！");
                        break;
                    case 1:
                        Console.WriteLine("当前业务已成功处理！");
                        person[k].show();
                        break;
                    case 2:
                        Console.WriteLine("取款失败！（注：此卡本次取款会导致今日取款金额超出上限，请尝试更改取款金额或明日再取！）");
                        person[k].show();
                        break;
                }
            }
            Console.WriteLine("感谢您的使用！");
            Console.Read();
        }

        int Locate(Card[] person, long cardNo)
        {
            int i;
            for(i = 0; i < person.Length; i++)
            {
                if(person[i].CardNo == cardNo)
                {
                    return i;
                }
                continue;
            }
            return -1;
        }
        int ComparePaswrd(Card[] person, long passwrd)
        {
            int i;
            for (i = 0; i < person.Length; i++)
            {
                if (person[i].CardPassword == passwrd)
                {
                    return i;
                }
                continue;
            }
            return -1;
        }
    }
    
}
