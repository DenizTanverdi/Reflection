using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            datasetMetotlari();
            Console.ReadLine();
        }
        public static void datasetMetotlari()
        {
            Type tip = typeof(DataSet);
            MethodInfo[] methods = tip.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            foreach  (MethodInfo m in methods)
            {
                Console.WriteLine("Name :"+m.Name);
                MethodBody mBody = m.GetMethodBody();
                IList<LocalVariableInfo> lv = mBody.LocalVariables;
                foreach (var item in lv)
                {
                    Console.WriteLine("Type Value" + item.LocalType);
                }
               
            }
        }
    }
}
