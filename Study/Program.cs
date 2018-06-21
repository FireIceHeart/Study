using System;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

namespace Study
{
    class Program
    {
        private int count;
        //属性访问器，替代get set 方法

        public int Count {
            get => count;
            set => count = value;
        }

       /*public int Count
        {
            get { return count; }
            set { this.count = value; }
        }*/
        static void Main(string[] args)
        {
            /*FileStream fs = new FileStream(@"d:\test.dat",FileMode.OpenOrCreate,FileAccess.ReadWrite);
            for (int i = 1; i <= 20; i++) {
                fs.WriteByte((byte)i);
            }
            fs.Position = 0;
            for (int i = 0; i <= 20; i++) {
                Console.Write(fs.ReadByte()+"");
            }
            fs.Close();*/
            //using 代码块 流对象使用完毕后自动关闭 类似java的 try()
            /*try
            {
                using (StreamReader sr = new StreamReader("d:/test/LOL.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.Write(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("文件读取错误！");
                Console.WriteLine(e.Message);
            }*/
            //写入本地文件，会覆写，和JAVA一样，加true可以实现续写
            /*string[] message = { "i","am","god"};
                using (StreamWriter sw = new StreamWriter(@"d:\c#.txt",true))
                {
                    foreach (string s in message)
                        sw.WriteLine(s);
                }*/
            //反射
            #region
            //相当于JAVA的Class.forName()
            /* MemberInfo info = typeof(DoWork);
             //object[] attributes = info.GetCustomAttributes(true);

             CheckCodeAttribute att = (CheckCodeAttribute)Attribute.GetCustomAttribute(info, typeof(CheckCodeAttribute));
             double score = att.GetScore();
             Console.WriteLine(att.UserName + "::" + att.CheckTime + "得分" + score);
             //反射获取实例
             Type t = Type.GetType("System.String");
             //无参构造
             String str = (String)Activator.CreateInstance(t);
             Type test = Type.GetType("TestSpace.TestClass");
             object[] objs = { "hello",2};
             //有参构造
             //TestClass tc = (TestClass)Activator.CreateInstance(test, objs);
             //获取方法
             Type tm = Type.GetType("System.String");
             MethodInfo method = t.GetMethod("test");
             object[] mparam = { "test"};
             method.Invoke(str,mparam);*/
            #endregion
            //测试索引器
            #region
            /*Index index = new Index();
            index[0] = "zara";
            index[1] = "tom";
            Console.WriteLine(index[0]+"\n"+index[1]+"\n"+index[2]);*/
            #endregion
            //测试委托
            #region
            //实例化委托
            //Number n1 = new Number(TestDelegate.AddNum);
            //Number n2 = new Number(TestDelegate.MultNum);
            //利用委托调用方法
            /*n1(25);
            Console.WriteLine("Num: {0}", TestDelegate.getNum());
            n2(10);
            Console.WriteLine("Num: {0}", TestDelegate.getNum());*/
            //委托多播
            //先执行了n2，然后执行n1，所以结果为 10*5+5=55
            // n2 += n1;
            //先执行了n1，然后执行n2，所以结果为 10+5*5=75
            //n1 += n2;
            //调用多播
            //n1(5);
            //n2(5);
            //也可以直接多播另外一个方法
            //n2 += TestDelegate.AddNum;
            // Console.WriteLine("多播Num: {0}", TestDelegate.getNum());
            #endregion
            //方法重写
            #region
            /*F f = new S();
            f.test();//子类重写虚方法
            f.normal();//这是个普通方法（调用了父类的方法，类似于JAVA的类方法隐藏）
            F.ff();//注意，C#中的静态方法只能通过类名来调用，无法通过实例化对象调用
            S.ff();
            S s = new S();
            s.test();//子类重写虚方法
            s.normal();//子类覆盖父类普通方法（调用了子类方法）
            S s2 = (S)f;//父类强转子类，前提是该父类引用指向一个子类对象，否则报错
            s2.test();//子类重写虚方法
            s2.normal();//子类覆盖父类普通方法（调用了子类方法）
            */
            #endregion
            //集合
            #region
            List<int> list = new List<int>();
            list.Add(1);
            Console.WriteLine(list[0]);
            Console.WriteLine("list的长度为："+list.Count);//获取长度
            HashSet<string> set = new HashSet<string>();
            set.Add("123");
            foreach (var v in set) {
                Console.WriteLine(v);
            }
            Hashtable table = new Hashtable();
            table.Add(1,"hashtable");
            ICollection keys =table.Keys;
            foreach (int k in keys) {
                Console.WriteLine(table[k]);
            }
            #endregion
            B b = new B();
            b.Num = 10;
            b.Count = 20;
            Console.WriteLine(b.Num);
            Console.WriteLine(b.Count);
            string s = "123";
            Console.WriteLine(s.Length);
            //装箱与拆箱
            int i = 1;
            object o = i;
            int j = (int)o;
            //判断类型是否相同
            bool boo = o is Object;
            Console.WriteLine(i.GetType() == o.GetType());
            Console.ReadKey();
        }

    }
    /// <summary>
    /// 特性 Attribute
    /// </summary>
    #region
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class CheckCodeAttribute : System.Attribute
    {
        public string UserName = "";
        public string CheckTime = "";
        public int Score = 0;
        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="name"></param>
        /// <param name="time"></param>
        /// <param name="score"></param>
        public CheckCodeAttribute(string name, string time, int score)
        {
            UserName = name;
            CheckTime = time;
            Score = score;
        }
        /// <summary>
        /// 计算分数方法
        /// </summary>
        /// <returns></returns>
        public double GetScore()
        {
            return Score * 0.8;
        }
    }
    #endregion
    /// <summary>
    /// 特性应用类
    /// </summary>
    #region
    [CheckCode("张三", "2018-01-01", 20)]
    public class DoWork
    {
        public string GetData()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }
    }
    #endregion
    /// <summary>
    /// 索引器
    /// </summary>
    #region
    class Index
    {
        private string[] names = new string[10];
        public Index() {
            for (int i =0; i < 10; i++)
                names[i] = "N.A";
        }
        /// <summary>
        /// 索引器
        /// </summary>
        /// <param name="index">参数是int，可以自定义，例如string</param>
        /// <returns>返回string 可以自定义</returns>
        public string this[int index]
        {
            get
            {
                string tmp;
                if (index >= 0 && index <= 9)
                    tmp = names[index];
                else
                    tmp = "";
                return tmp;
            }
            set
            {
                if (index >= 0 && index <= 9)
                    names[index] = value;
            }
        }
    }
    #endregion
    //委托
    #region
    delegate int Number(int n);
    class TestDelegate
    {
        static int num = 10;
        public static int AddNum(int p)
        {
            num += p;
            return num;
        }
        public static int MultNum(int q)
        {
            num *= q;
            return num;
        }
        public static int getNum()
        {
            return num;
        }
    }
    #endregion
    //虚方法
    #region
    class F
    {
        public readonly int a = 10;//常量可以被实例访问
        public static int b = 10; //静态属性不能被实例访问
        public virtual void test()
        {
            Console.WriteLine("这是虚方法");
        }
        public void normal()
        {
            Console.WriteLine("这是个普通方法");
        }
        public static void ff()
        {
            Console.WriteLine("这是父类静态方法");
        }
    }
    class S : F
    {
        public override void test()
        {
            Console.WriteLine("子类重写虚方法");
        }
        public new void normal()//相对于子类屏蔽了父类的这个方法
        {
            Console.WriteLine("子类覆盖父类普通方法");
        }
        public static void ff()
        {
            Console.WriteLine("这是子类静态方法");
        }
    }
    #endregion
    //抽象属性、虚属性
    #region
    public abstract class A
    {
        private int num;
        public abstract string Name
        {
            set;
            get;
        }
        public virtual int Num
        {
            get { return 1; }
            set { num = value; }
        }
    }
    public class B : A
    {
        private int num;
        public override string Name
        {
            get => Name;
            set => Name = value;
        }
        public override int Num
        {
            get { return 5; }
            set { num = value; }
        }
        public int Count { get; set; }
    }
    #endregion
}
