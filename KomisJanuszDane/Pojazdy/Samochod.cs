using System;
using System.Collections.Generic;
using System.Text;

namespace KomisJanuszDane.Pojazdy
{
    public abstract class Samochod : Pojazd
    {
        public const int TYP_SAMOCHOD = 1;

        public Samochod(int RokProdukcji, float CenaZakupu, float Marza) : 
            base(TYP_SAMOCHOD,RokProdukcji,CenaZakupu,Marza)
        {
        }

        public override string NazwaTypuPojazdu
        {
            get
            {
                switch (TypPojazdu)
                {
                    case TYP_SAMOCHOD:
                        return "Samochod";
                }

                return base.NazwaTypuPojazdu;
            }
        }

        

    }
}
