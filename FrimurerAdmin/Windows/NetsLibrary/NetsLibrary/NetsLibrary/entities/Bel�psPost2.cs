using System;
using System.Linq;
using System.Text;

namespace NetsLibrary.entities
{
    public class BeløpsPost2:BaseEntity
    {
        private string transaksjonstype="21";  // std. varsling fra bank 
        private int transaksjonsnummer = 1;
        private string fremmedref = "";
        private String filler = "";
        private String kortnavn = "";

        public BeløpsPost2(String transaksjonstype, int transNummer, String kortNavn, String fremmedRef)
        {
            TransaksjonsType= transaksjonstype;
            TransaksjonsNummer=transNummer.ToString();
            ForkortetNavn=kortNavn;
            FremmedRef=fremmedRef;
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
        /// Numerisk, 2 posisjoner, gyldie verdier = 02-Ingen varsling fra bank, eller 21-varsling fra bank
        /// Hvis kode 02 angis og det sendes med spesifikasjonsrecords formidles ikke spesifikasjonene til betaler
        ///</summary>
        public String TransaksjonsType
        {
            get
            {
                return transaksjonstype;
            }
            set
            {
                if (value== "21" || value=="02")
                    transaksjonstype=value;
            }
        }

        // Numerisk, 2 posisjoner, alltid=31
        private String RecordType
        {
            get
            {
                return "32";
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
        /// Alfanumerisk, 25 posisjoner
        /// Feltet kan benyttes som et opplysningsfelt om betalingskravet overfor betaler.
        /// Fremmedreferansen overføres til betalers kontoutskrift og AvtaleGiro info.
        /// Dersom fremmedreferansen ikke benyttes skal feltet blankes.
        /// Fremmedreferansen overstyrer fast tekst på betalers faste betalingsoppdrag.
        /// 
        public String FremmedRef
        {
            get
            {
                return fremmedref.PadRight(25, ' ');
            }
            set
            {
               fremmedref = value.PadRight(25,' ');
            }

        }

        /// <summary>
        /// Alfanumerisk, 10 posisjoner
        /// Fylles ut med forkortet navn for betaler
        /// Feltet bør fylles ut for å lette identifikasjon av evt. avviste betalingskrav
        /// </summary>
        public String ForkortetNavn
        {
            get
            {
                return kortnavn.PadRight(10, ' ');
            }
            set
            {
                if (value.Length >10)
                {
                    kortnavn= value.Substring(0, 10).PadRight(10, ' ');
                }
                else
                {
                    kortnavn = value.PadRight(10, ' ');
                }
            }

        }
        private String Filler25
        {
            get
            {
                return filler.PadLeft(25, ' ');
            }
        }
        private String Filler5
        {
            get
            {
                return filler.PadLeft(5, '0');
            }
        }

     
       

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Debug + FormatKode+TjenesteKode+TransaksjonsType+RecordType+TransaksjonsNummer+ ForkortetNavn+ Filler25+ FremmedRef+Filler5);
            return sb.ToString();

        }
    }
}
