using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {

            //stringBilgileriniVer();
            /*
             Ogrenci sinifinin public field'larina erişim
             
             */

            Type ogrenciTuru = typeof(Ogrenci);
            FieldInfo[] ogrencialanlari = ogrenciTuru.GetFields(
                                                         BindingFlags.Public |
                                                         BindingFlags.Instance);


           /* foreach (FieldInfo ogrenciAlani in ogrencialanlari)
            {
                Console.WriteLine("Alan :" + ogrenciAlani.Name);
            }*/





            /*
             2. Yeni ögrenci Nesnesi
             */

            Ogrenci ogrenci = new Ogrenci
            {
                Adi = "",
                Soyadi = "ozturk",
                Bolum = "Matematik"

            };

            if (!ZorunlulukKontrolu.Dogrula(ogrenci))
            {
                Console.WriteLine("Öğrenci bilgileri doğrulamadan geçemedi!");
            }
         
            else{
                foreach (FieldInfo ogrenciAlani in ogrencialanlari)
                {
                    Console.WriteLine("Alan :" + ogrenciAlani.Name);
                    Console.WriteLine("Değer :" + ogrenciAlani.GetValue(ogrenci));
                    Console.WriteLine("******************");
                }
            }
            Console.ReadKey();

           
        }

        public static void stringBilgileriniVer()
        {

            Type tip = typeof(String);
            MethodInfo[] metotlar = tip.GetMethods(
                                                         BindingFlags.Public |
                                                         BindingFlags.Instance);


            foreach (MethodInfo metot in metotlar)
            {

                if (metot.MemberType == MemberTypes.Method)
                    Console.WriteLine("Metot Adi:" + metot.Name);
                Console.WriteLine("Metot return type:" + metot.ReturnType);

            }

        }
    }


}
