using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp2_4
{
    class CRect
    {
        private int left, top, right, bottom;
        public static int total_rects;
        public static long total_rect_area;

        
        public CRect()
        {
            left = top = right = bottom = 0;
            total_rects++;
            total_rect_area += getHeight() * getWidth();
            Console.WriteLine("CRect() Construct rectangle number is: {0}", total_rects);
            Console.WriteLine("Total rectangle area is: {0}", total_rect_area);
        }
        public CRect(int x1, int y1, int x2, int y2)
        {
            left = x1; top = y1;  right = x2; bottom = y2;
            total_rects++;
            total_rect_area += getHeight() * getWidth();
            Console.WriteLine("CRect(int int int int) Construct rectangle number is: {0}", total_rects);
            Console.WriteLine("Total rectangle area is: {0}", total_rect_area);
        }
        public CRect(CRect r)
        {
            left = r.left;  right = r.right;  top = r.top;  bottom = r.bottom;
            total_rects++;
            total_rect_area += getHeight() * getWidth();
            Console.WriteLine("CRect(CRect&) Construct rectangle number is: {0}", total_rects);
            Console.WriteLine("Total rectangle area is: {0}", total_rect_area);
        }
        public int getHeight()
        {
            return top > bottom ? top - bottom : bottom - top;
        }
        public int getWidth()
        {
            return left > right ? left - right : right - left;
        }

        public static int getTotalRects()
        {
            return total_rects;
        }
        public static long getTotalRectArea()
        {
            return total_rect_area;
        }

        //静态代码块
        static void Main(string[] args)
        {
            CRect rect1 = new CRect(1, 3, 6, 4), rect2 = new CRect(rect1);
            Console.Write("Rectangle 2: Height = {0}", rect2.getHeight());
            Console.WriteLine(", Width = {0}", rect2.getWidth());
            //构造代码块
            {
                CRect rect3 = new CRect();
                Console.Write("Rectangle 3: Height = {0}", rect3.getHeight());
                Console.WriteLine(", Width = {0}", rect3.getWidth());
            }
            Console.Write("total_rects={0},", CRect.total_rects);
            Console.WriteLine("total_rect_area={0}", CRect.total_rect_area);
            Console.Read();
        }
    }
}
