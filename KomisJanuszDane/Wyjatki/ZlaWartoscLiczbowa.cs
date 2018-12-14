using System;
using System.Collections.Generic;
using System.Text;

namespace KomisJanuszDane.Wyjatki
{
    public class ZlaWartoscLiczbowa : Exception
    {
        public ZlaWartoscLiczbowa(string NazwaZmiennej,object Aktualna, object Spodziewana) : 
            base($"Błędna wartość liczbowa zmiennej <{NazwaZmiennej}>! Aktualna = <{Aktualna}>, Spodziewana = <{Spodziewana}>")
        {
        }
    }
}
