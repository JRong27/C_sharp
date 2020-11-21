using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exp2_5
{
    //定义IEnglishDimensions和IMetricDimensions接口
    interface IEnglishDimensions
    {
        float Length(); float Width();
    }
    interface IMetricDimensions
    {
        float Length(); float Width();
        //【方法二】同时使用隐式接口实现的前提声明
        float Length_1();  float Width_1();
    }



    //从IEnglishDimensions和IMetricDimensions接口派生类Box
    class Box : IEnglishDimensions, IMetricDimensions
    {
        float lengthInches;
        float widthInches;

        public Box(float length, float width)
        {
            lengthInches = length;
            widthInches = width;
        }
        ////显式接口实现方法
        //float IEnglishDimensions.Length()
        //{
        //    return lengthInches;
        //}
        //float IEnglishDimensions.Width()
        //{
        //    return widthInches;
        //}
        //float IMetricDimensions.Length()
        //{
        //    return lengthInches * 2.54f;
        //}
        //float IMetricDimensions.Width()
        //{
        //    return widthInches * 2.54f;
        //}
        //隐式接口实现
        public float Length()
        {
            return lengthInches;
        }
        public float Width()
        {
            return widthInches;
        }
        //因为有同名方法,所以
        //【方法一】用显示和隐式分别实现不同接口的同名方法
        float IMetricDimensions.Length()
        {
            return lengthInches * 2.54f;
        }
        float IMetricDimensions.Width()
        {
            return widthInches * 2.54f;
        }
        //【方法二】更改方法名,同时使用隐式接口实现
        public float Length_1()
        {
            return lengthInches * 2.54f;
        }
        public float Width_1()
        {
            return widthInches * 2.54f;
        }
       
        //主程序
        static void Main(string[] args)
        {
            //定义一个实类对象"myBox":
            Box myBox = new Box(30.0f, 20.0f);

            //定义一个接口"eDimensions"
            IEnglishDimensions eDimensions = myBox;
            //定义一个接口"'mDimensions"
            IMetricDimensions mDimensions = (IMetricDimensions)myBox;
            //输出
            Console.WriteLine("同时隐式、显式接口实现");
            Console.WriteLine(" Length(in): {0}", eDimensions.Length());
            Console.WriteLine(" Width (in): {0}", eDimensions.Width());
            Console.WriteLine(" Length(cm): {0}", mDimensions.Length());
            Console.WriteLine(" Width (cm): {0}", mDimensions.Width());
            Console.WriteLine("同时隐式接口实现");
            Console.WriteLine(" Length(in): {0}", eDimensions.Length());
            Console.WriteLine(" Width (in): {0}", eDimensions.Width());
            Console.WriteLine(" Length(cm): {0}", mDimensions.Length_1());
            Console.WriteLine(" Width (cm): {0}", mDimensions.Width_1());
            Console.Read();

        }
    }
}
