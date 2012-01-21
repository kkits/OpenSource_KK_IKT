using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetsLibrary.entities
{
  /// <summary>
  /// Første record for ethvert nytt oppdrag i forsendelsen
  /// Dersom recorden mangler vil oppdraget  bli avvist ved innlesing i nets
  /// Recorden må kun forekomme en gang pr oppdrag
  /// </summary>
    public class StartRecordOppdragBetalingskrav:BaseEntity
    {

        private int oppdragsnummer = 0;
        private int forsendelsesNr = 0;
        private String filler = "0";
        private String bankkto = "0";
     
        /// <summary>
        /// Alfanumerisk 2 posisjoner, alltid=NY
        /// </summary>
        public String FormatKode
        {
            get
            {
                return "NY";
            }
        }

        /// <summary>
        /// Numerisk 2 posisjoner, alltid=21
        /// </summary>
        public String TjenesteKode
        {
            get
            {
                return "21";
            }
            
        }

        /// <summary>
        /// Numerisk, 2 posisjoenr, alltid=00
        /// </summary>
        public String OppdragsType
        {
            get
            {
                return "00";
            }

        }

        // Numerisk, 2 posisjoner, alltid=20
        public String RecordType
        {
            get
            {
                return "20";
            }

        }

        /// <summary>
        /// numerisk, 11 posisjoner, betalingsmottakers (avtalens) bankgiro
        /// Skal være den konto hvor avtale om Avtalegiro og OCR giroer registrert
        /// </summary>
        public String OppdragsKonto
        {
            get
            {
                return bankkto.PadLeft(11,'0');
            }
            set 
            {
                bankkto = value.PadLeft(11,'0');
            }
        }


        private String Filler45
        {
            get
            {
                return filler.PadLeft(45, '0');
            }
        }


        private String Filler9
        {
            get
            {
                return filler.PadLeft(9, '0');
            }
        }

        /// <summary>
        /// Numerisk 7 posisjoner
        /// Må være en unik nummerering av oppdrag pr betalingsmottakers mottakeravtale 12 mnd + en dag fram i tid.  
        /// (F.eks DDMM+ løpenr e.l)
        /// </summary>
        public String OppdragsNummer
        {
            get
            {
                String val = Convert.ToString(oppdragsnummer);
                val = val.PadLeft(7, '0');
                return val;
            }
            set
            {
                try
                {
                    oppdragsnummer = Convert.ToInt32(value);
                }
                catch (Exception ex)
                {
                    // ignore   
                }

            }

        }
    
        public StartRecordOppdragBetalingskrav(String kontonummer, int oppdragsnummer)
        {
            OppdragsKonto= kontonummer;
            OppdragsNummer= Convert.ToString(oppdragsnummer);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Debug + FormatKode+TjenesteKode+OppdragsType+RecordType+Filler9+ OppdragsNummer+ OppdragsKonto+ Filler45);
            return sb.ToString();
        }
    }
}
