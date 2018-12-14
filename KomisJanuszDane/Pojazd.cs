using KomisJanuszDane.Wyjatki;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomisJanuszDane
{
    public abstract class Pojazd
    {
        public const int TYP_NIEZNANY = 0;

        private int iTypPojazdu;
        private int iRokProdukcji;
        private float fCenaZakupu;
        private float fMarza;

        public int      TypPojazdu
        {
            get
            {
                return iTypPojazdu;
            }            
        }

        public int RokProdukcji
        {
            get
            {
                return iRokProdukcji;
            }
        }

        public float CenaZakupu
        {
            get
            {
                return fCenaZakupu;
            }
        }

        public float    Marza
        {
            get
            {
                return fMarza;
            }             
        }

        public float CenaSprzedazy
        {
            get
            {
                return CenaZakupu + (CenaZakupu * (Marza / 100.0f));
            }
        }

        public abstract string Marka { get; }
        public abstract string Model { get; }

        public Pojazd(int TypPojazdu, int RokProdukcji, float CenaZakupu, float Marza)
        {
            if (TypPojazdu < TYP_NIEZNANY)
                throw new ZlaWartoscLiczbowa("TypPojazdu", TypPojazdu, ">=0");

            if (RokProdukcji > DateTime.Now.Year)
                throw new ZlaWartoscLiczbowa("RokProdukcji", RokProdukcji, $"<={DateTime.Now.Year}");

            if (CenaZakupu <= 0.0f)
                throw new ZlaWartoscLiczbowa("CenaZakupu", CenaZakupu, ">0");

            if (Marza < 0.0f)
                throw new ZlaWartoscLiczbowa("Marza", Marza, ">=0");

            this.iTypPojazdu = TypPojazdu;
            this.iRokProdukcji = RokProdukcji;
            this.fCenaZakupu = CenaZakupu;
            this.fMarza = Marza;
        }

        public virtual string NazwaTypuPojazdu
        {
            get
            {
                switch (TypPojazdu)
                {
                    default:
                        return "Nieznany typ";
                }
            }
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Marka))
                throw new PustyLancuchTekstowy("Marka");

            if (string.IsNullOrEmpty(Model))
                throw new PustyLancuchTekstowy("Model");

            return $"{NazwaTypuPojazdu} {Marka} {Model} ({RokProdukcji})";
        }

    }
}
