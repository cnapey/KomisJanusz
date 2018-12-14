using System;
using System.Collections.Generic;
using System.Text;

namespace KomisJanuszDane.Pojazdy.Samochody.Fordy
{
    public class Ranger : Ford
    {
        public Ranger(int RokProdukcji, float CenaZakupu, float Marza) :
            base(RokProdukcji, CenaZakupu, Marza)
        {
        }

        public override string Model => "Ranger";
    }
}
