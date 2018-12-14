using System;
using System.Collections.Generic;
using System.Text;

namespace KomisJanuszDane.Pojazdy.Samochody
{
    public abstract class Fiat : Samochod
    {
        public Fiat(int RokProdukcji, float CenaZakupu, float Marza) :
            base(RokProdukcji, CenaZakupu, Marza)
        {
        }

        public override string Marka => "Fiat";
    }
}
