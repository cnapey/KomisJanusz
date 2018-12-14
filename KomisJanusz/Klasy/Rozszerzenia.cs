using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomisJanusz.Klasy
{
    public static class Rozszerzenia
    {
        public static List<Type> TypyDziedziczace(this Type ZTegoTypu)
        {
            List<Type> ListaTypow = new List<Type>();

            foreach (var Assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var AssemblyType in Assembly.GetTypes())
                {
                    if (ZTegoTypu.Equals(AssemblyType.BaseType))
                    {
                        ListaTypow.Add(AssemblyType);
                    }

                }
            }

            return ListaTypow;
        }
    }
}
