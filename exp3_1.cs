using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp3_1
{
    class Card
    {
        private string title, author;
        private int total;

        public Card()
        {
            title = ""; author = ""; total = 0;
        }
        public Card(string title, string author, int total)
        {
            this.title = title;
            this.author = author;
            this.total = total;
        }

        public void store(ref Card card)  //ref有必要吗？？
        {
            title = card.title;
            author = card.author;
            total = card.total;
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public int Total
        {
            get { return total; }
            set { total = value; }
        }

        internal void show()
        {
            Console.WriteLine("Title:{0}, Author:{1}, Total:{2}", title, author, total);
        }
    }

    class test3_1
    {
        static void Main(string[] args)
        {
            Card card = new Card();
            string sline;
            int num;
            int i, k;  //在前面提前定义循环所用的变量i，多次开辟、销毁存储空间的减少开销

            Console.Write("请输入需要入库图书的总数：");  //此处的图书总数指的是图书种类数，即Card[]类型books的元素个数
            sline = Console.ReadLine();
            num = int.Parse(sline);  //读入的长度是字符串，要转化为数值型

            Card[] books = new Card[num];  //books[]的元素都是Card类型，每个元素具有3个属性
            for (i = 0; i < num; i++)
            {
                books[i] = new Card();  //为books[]的元素初始化
            }

            int[] index = new int[num];  //建立图书的下标数组，按输入次序为录入的书编号
            for (i = 0; i < num; i++)
            {
                Console.Write("请输入书名：");
                card.Title = Console.ReadLine();  //调用Card类的set访问器
                Console.Write("请输入制作者：");
                card.Author = Console.ReadLine();
                Console.Write("请输入入库数量：");
                sline = Console.ReadLine();  //Total访问器的类型是int
                card.Total = int.Parse(sline);  //传值前,需要将读入的数字字符串转型成相同类型or可兼容类型
                books[i].store(ref card);  //单个图书入库
                index[i] = i;  //为入库的图书编号
            }

            test3_1 T = new test3_1();
            while (true)
            {
                Console.WriteLine("请选择按什么关键字排序(1.书名  2.作者  3.入库量)");
                sline = Console.ReadLine();
                int choice = int.Parse(sline);
                //switch (choice)
                //{
                //    case 1:
                //        T.sortTtile(books, index);
                //        break;
                //    case 2:
                //        T.sortAuthor(books, index);
                //        break;
                //    case 3:
                //        T.sortTotal(books, index);
                //        break;
                //}
                T.sort(books,index,choice);
                for (i = 0; i < num; i++)   //遍历输出排序后的图书信息列表
                {
                    k = index[i];
                    (books[k]).show();
                }
            }
            Console.Read();
        }


        //三种排序换汤不换药，代码结构思路完全相同
        //按书名排序
        void sortTtile(Card[] book, int[] index)  //交换类排序之冒泡排序
        {
            int m, n, i, j, temp;
            for (m = 0; m < index.Length - 1; m++)
            {
                for (n = 0; n < index.Length - m - 1; n++)
                {
                    i = index[n];
                    j = index[n + 1];
                    //字母ASCII码顺序比较排序，
                    //右在前,则<0; 左右同位置,则==0; 左在前,则>0.
                    if (string.Compare(book[i].Title, book[j].Title) > 0)
                    {   //左>右则互换，实现小的向上冒泡
                        temp = index[n];
                        index[n] = index[n + 1];
                        index[n + 1] = temp;
                    }
                }
            }
        }
        //按作者名排序
        void sortAuthor(Card[] book, int[] index)
        {
            int m, n, i, j, temp;
            for (m = 0; m < index.Length - 1; m++)
            {
                for (n = 0; n < index.Length - m - 1; n++)
                {
                    i = index[n];
                    j = index[n + 1];
                    if (string.Compare(book[i].Author, book[j].Author) > 0)
                    {
                        temp = index[n];
                        index[n] = index[n + 1];
                        index[n + 1] = temp;
                    }
                }
            }
        }
        //按书的数量排序
        void sortTotal(Card[] book, int[] index)
        {
            int m, n, i, j, temp;
            for (m = 0; m < index.Length - 1; m++)
            {
                for (n = 0; n < index.Length - m - 1; n++)
                {
                    i = index[n];
                    j = index[n + 1];
                    if (book[i].Total > book[j].Total)  //Total是整型类型，直接比较大小即可
                    {
                        temp = index[n];
                        index[n] = index[n + 1];
                        index[n + 1] = temp;
                    }
                }
            }
        }

        //B思考改写
        void sort(Card[] book, int[] index, int method)
        {
            int m, n, i, j, temp;
            for (m = 0; m < index.Length - 1; m++)
            {
                for (n = 0; n < index.Length - m - 1; n++)
                {
                    i = index[n];
                    j = index[n + 1];
                    switch (method)
                    {
                        case 1:
                            if (string.Compare(book[i].Title, book[j].Title) > 0)
                            {   //左>右则互换，实现小的向上冒泡
                                temp = index[n];
                                index[n] = index[n + 1];
                                index[n + 1] = temp;
                            }
                            break;
                        case 2:
                            if (string.Compare(book[i].Author, book[j].Author) > 0)
                            {
                                temp = index[n];
                                index[n] = index[n + 1];
                                index[n + 1] = temp;
                            }
                            break;
                        case 3:
                            if (book[i].Total > book[j].Total)
                            {
                                temp = index[n];
                                index[n] = index[n + 1];
                                index[n + 1] = temp;
                            }
                            break;
                    }
                }
            }
        }
    }
}
