using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetsLibrary.entities
{
    public class SpesifikasjonsRecord:BaseEntity
    {
        private int transaksjonsnummer = 1;
        private int plasseringKolonne = 1;
        private int plasseringLinje = 1;
        private string meldingsspesifikasjon = "";
        private string filler = "";

        public SpesifikasjonsRecord(int transaksjonsnr, String meldingsspesifikasjon)
        {
            MeldingsSpesifikasjon= meldingsspesifikasjon;
            TransaksjonsNummer=transaksjonsnr.ToString();
        }


        /// <summary>
        /// Alfanumerisk 2 posisjoner, alltid=NY
        /// </summary>
        private String FormatKode
        {
            get
            {
                return "NY";
            }
        }

        

        /// <summary>
        /// Numerisk 2 posisjoner, alltid=21
        /// </summary>
        private String TjenesteKode
        {
            get
            {
                return "21";
            }

        }

        /// <summary>
        /// Numerisk 2 posisjoner, alltid=00
        /// </summary>
        private String OppdragsType
        {
            get
            {
                return "00";
            }

        }

        /// <summary>
        /// Numerisk, 2 posisjoner, alltid=21
        ///</summary>
        private String TransaksjonsType
        {
            get
            {
                return "21";
            }
           
        }

        // Numerisk, 2 posisjoner, alltid=49
        private String RecordType
        {
            get
            {
                return "49";
            }

        }

        // Numerisk, 1 posisjoner, alltid=4
        private String BetalingsVarsel
        {
            get
            {
                return "4";
            }

        }

        private String Filler20
        {
            get
            {
                return filler.PadLeft(20,'0');
            }

        }

        public String MeldingsSpesifikasjon
        {
            get { 
                if(meldingsspesifikasjon.Length > 40)
                    return meldingsspesifikasjon.Substring(0,40);
            else
                return meldingsspesifikasjon.PadRight(40,' ');
                }
            set
            {
                if (value.Length > 40)
                    meldingsspesifikasjon = value.Substring(0, 40);
                else
                    meldingsspesifikasjon=value;
            }
        }

        /// <summary>
        /// Numerisk, 7 posisjoner
        /// Unik nummererering av transaksjonen pr. oppdrag i stigende sekvens.
        /// NB! Det samme transaksjonsnummer må benyttes for hele transaksjonen. Dvs Beløpspost 1 og 2 og spesifikasjonsrecordene.
        /// Transaksjonsnummer må være større enn 0
        /// </summary>
        public String TransaksjonsNummer
        {
            get
            {
                String val = Convert.ToString(transaksjonsnummer);
                val = val.PadLeft(7, '0');
                return val;
            }
            set
            {
                try
                {
                    transaksjonsnummer = Convert.ToInt32(value);
                }
                catch (Exception ex)
                {
                    // ignore   
                }

            }

        }


        /// <summary>
        /// Numerisk, 3 posisjoner
        /// Angir på hvilken linje spesifikasjonen skal skrives ut
        /// Gyldige linjenummer: 001-042
        /// </summary>
        public String PlasseringLinje
        {
            get
            {
                String val = Convert.ToString(plasseringLinje);
                val = val.PadLeft(3, '0');
                return val;
            }
            set
            {
                try
                {
                    plasseringLinje= Convert.ToInt32(value);
                }
                catch (Exception ex)
                {
                    // ignore   
                }

            }

        }

        /// <summary>
        /// Numerisk, 3 posisjoner
        /// Angir på hvilken linje spesifikasjonen skal skrives ut
        /// Gyldige linjenummer: 001-042
        /// </summary>
        public String PlasseringKolonne
        {
            get
            {
                String val = Convert.ToString(plasseringKolonne).PadLeft(3,'0');
                return val;
            }
            set
            {
              if(value =="1" || value=="2")
                  plasseringKolonne= Convert.ToInt32(value);
            }

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Debug + FormatKode+TjenesteKode+TransaksjonsType+RecordType+TransaksjonsNummer+BetalingsVarsel+plasseringLinje+PlasseringKolonne+MeldingsSpesifikasjon+Filler20);
            return sb.ToString();
        }

    }
}
