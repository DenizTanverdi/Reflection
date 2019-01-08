using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Ogrenci
    {

        [ZorunluAlan]
        public string Adi;
        public string Soyadi;
        public string Bolum;
        private int not;
        public Ogrenci()
        {
            //not = 0;

            //Adi = "";
            //Soyadi = "";
            //Bolum = "";
        }
        public override string ToString()
        {
            return $"Adi Soyadi {Adi } {Soyadi} Boulumu {Bolum}";
        }
    }
    [AttributeUsage(
    AttributeTargets.Field,
    AllowMultiple = false,
    Inherited = true)]
    public class ZorunluAlanAttribute : Attribute { }


    public static class ZorunlulukKontrolu
    {
        public static bool Dogrula(object dogrulanacakOrnek)
        {
            Type dogrulamacakTur = dogrulanacakOrnek.GetType();

            FieldInfo[] dogrulanacakTurAlanlari = dogrulamacakTur.GetFields(
                                                    BindingFlags.Public |
                                                    BindingFlags.Instance);


            foreach (FieldInfo dogrulanacakTurAlani in dogrulanacakTurAlanlari)
            {
                object[] zorunluAlanOznitelikleri = dogrulanacakTurAlani.GetCustomAttributes(typeof(ZorunluAlanAttribute), true);

                if (zorunluAlanOznitelikleri.Length != 0)
                {
                    string alanDegeri = dogrulanacakTurAlani.GetValue(dogrulanacakOrnek) as string;

                    if (string.IsNullOrEmpty(alanDegeri))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
    

