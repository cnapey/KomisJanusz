using System;
using System.Collections.Generic;
using System.Text;

namespace KomisJanuszDane.Wyjatki
{
    public class PustyLancuchTekstowy : Exception
    {
        public PustyLancuchTekstowy(string NazwaZmiennej) : base($"Nieoczekiwany pusty łańcuch tekstowy w zmiennej <{NazwaZmiennej}!")
        {
        }
    }
}
