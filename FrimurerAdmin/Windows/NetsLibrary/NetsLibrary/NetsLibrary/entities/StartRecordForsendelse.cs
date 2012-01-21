using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetsLibrary.entities
{
  /// <summary>
  /// Første record i enhver forsendelse til Nets
  /// Dersom recorden mangler vil forsendelsen bli avvist
  /// Recorden må kun forekomme en gang pr forsendelse
  /// </summary>
    public class StartRecordForsendelse:BaseEntity
    {

        private int dataAvsender = 0;
        private int forsendelsesNr = 0;
        private String filler = "0";

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
        /// Numerisk 2 posisjoner, alltid=00
        /// </summary>
        public String TjenesteKode
        {
            get
            {
                return "00";
            }
            
        }

        /// <summary>
        /// Numerisk, 2 posisjoenr, alltid=00
        /// </summary>
        public String ForsendelsesType
        {
            get
            {
                return "00";
            }

        }

        // Numerisk, 2 posisjoner, alltid=10
        public String RecordType
        {
            get
            {
                return "10";
            }

        }

        // numerisk, 8 posisjoner, alltid 00008080 for Nest's ID
        public String DataMottaker
        {
            get
            {
                return "00008080";
            }
        }


        // Numerisk, 8 posisjoner, kundens Nets Avtale nr og fylles ut av dataavsenders KUNDEENHET-ID
        public String DataAvsender
        {
            get
            {
                String val = Convert.ToString(dataAvsender);
                val = val.PadLeft(8, '0');
                return val;
            }
            set
            {
                try
                {
                    dataAvsender = Convert.ToInt32(value);
                }
                catch (Exception ex)
                {
                  // ignore   
                }
                
            }

        }
        public String Filler
        {
            get
            {
                return filler.PadLeft(49, '0');
            }
        }

        // Numerisk, 7 posisjoner, kundens unike nummerering av forsendelsen, eks DD + MM + løpenr
        public String ForsendelsesNr
        {
            get
            {
                String val = Convert.ToString(forsendelsesNr);
                val = val.PadRight(7, '0');
                return val;
            }
            set
            {
                try
                {
                    forsendelsesNr = Convert.ToInt32(value);
                }
                catch (Exception ex)
                {
                    // ignore   
                }

            }

        }

        public StartRecordForsendelse(int KundeEnhetsID, int ForsendelsesID)
        {
            DataAvsender= Convert.ToString(KundeEnhetsID);
            ForsendelsesNr = Convert.ToString(ForsendelsesID);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Debug + FormatKode+TjenesteKode+ForsendelsesType+RecordType+DataAvsender+ ForsendelsesNr+ DataMottaker+ Filler);
            return sb.ToString();
        }
    }
}
