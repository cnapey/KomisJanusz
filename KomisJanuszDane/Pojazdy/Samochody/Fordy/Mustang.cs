using System;
using System.Collections.Generic;
using System.Text;

namespace KomisJanuszDane.Pojazdy.Samochody.Fordy
{
    public class Mustang : Ford
    {
        public Mustang(int RokProdukcji, float CenaZakupu, float Marza) : 
            base(RokProdukcji, CenaZakupu, Marza)
        {
        }

        public override string Model => "Mustang";
    }
}
