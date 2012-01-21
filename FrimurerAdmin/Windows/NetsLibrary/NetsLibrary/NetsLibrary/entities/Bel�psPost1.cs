using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetsLibrary.entities
{
    public class BeløpsPost1:BaseEntity
    {
        private string forfallsdato = "010112";
        private string beløp = "0";
        private string kid = "";
        private string filler = "";
        private double valBeløp = 0;
       

        public BeløpsPost1(String transaksjonstype, int transNummer, String forfallsdto, String ØreBeløp, String KID)
        {
            TransaksjonsType= transaksjonstype;
            TransaksjonsNummer=transNummer.ToString();
            ForfallsDato=forfallsdto;
            KID=kid;
            Beløp=ØreBeløp;
            TjenesteKode="21";
            RecordType="30";
           
        }

        /// <summary>
        /// Numerisk, 6 posisjoner, Fylles ut med DDMMÅÅ
        /// Må være en gyldig dato
        /// Må ikke være mer enn 12 måneder fram i tid.
        /// </summary>
        public String ForfallsDato
        {
            get
            {
                String val = Convert.ToString(forfallsdato);
                val = val.PadLeft(6, '0');
                return val;
            }
            set
            {
                try
                {
                    forfallsdato = value.PadLeft(6,'0');
                }
                catch (Exception ex)
                {
                    // ignore   
                }

            }

        }
      
        public String Beløp
        {
            get
            {
                return beløp.PadLeft(17, '0');
            }
            set
            {
                beløp = value.PadLeft(17, '0');
                valBeløp=Convert.ToInt64(beløp) / 100;
            }
        }

        public double BeløpIKr
        {
            get
            {
                return valBeløp;
            }
        }


        public String KID
        {
            get
            {
                return kid.PadLeft(25, ' ');
            }
            set
            {
                kid = value.PadLeft(25, ' ');
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Debug+FormatKode+TjenesteKode+TransaksjonsType+RecordType+TransaksjonsNummer+ ForfallsDato+ Filler11+ Beløp+KID +Filler6);
            return sb.ToString();

        }
    }
}
