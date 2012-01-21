using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetsLibrary.entities
{
    public class SluttRecordOppdragBetalingskrav:BaseEntity
    {

        private String filler = "0";
        private int antallTransaksjoner =0;
        private int antallRecords = 0;
        private long sumbelop = 0;
        private String førsteDato = "010112";
        private String sisteDato = "010112";


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

        // Numerisk, 2 posisjoner, alltid=89
        public String RecordType
        {
            get
            {
                return "88";
            }

        }

   
        /// <summary>
        /// Numerisk, 8 posisjoner, antall transaksjoner i filen
        /// Feltet skal inneholde oppgitt antall transaksjonsrecords i forsendelsen
        /// (betalingskrav: Beløpspost 1+ Beløpspost 2 + evt. spesifikasjoner = 1 transaksjoner)
        /// (Slettinger: Post1 + evt. Post2 + evt. spesifikasjoner = 1 transaksjoner)
        /// </summary>
        public String AntallTransaksjoner
        {
            get
            {
                String val = Convert.ToString(antallTransaksjoner);
                val = val.PadLeft(8, '0');
                return val;
            }
            set
            {
                try
                {
                    antallTransaksjoner = Convert.ToInt32(value);
                }
                catch (Exception ex)
                {
                  // ignore   
                }
                
            }

        }

         /// <summary>
        /// Numerisk, 8 posisjoner, antall records i filen
        /// Feltet skal inneholde oppgitt antall oppgitte poster/records i forsendelsen, inklusive startrecord og sluttrecord for oppdrag
        /// og startrecord og sluttrecord for forsendelsen
        /// </summary>
        public String AntallRecords
        {
            get
            {
                String val = Convert.ToString(antallRecords);
                val = val.PadLeft(8, '0');
                return val;
            }
            set
            {
                try
                {
                    antallRecords = Convert.ToInt32(value);
                }
                catch (Exception ex)
                {
                  // ignore   
                }
                
            }

        }

         /// <summary>
        /// Numerisk, 7 posisjoner, sum beløp for alle transaksjonsrecords i forsendelsen, eventuelt sum beløp av alle sluttrecords for oppdrag i forsendelsen.
        /// Beløpet oppgis i øre
        /// </summary>
        public String SumBeløp
        {
            get
            {
                String val = Convert.ToString(sumbelop);
                val = val.PadLeft(17, '0');
                return val;
            }
            set
            {
                try
                {
                    sumbelop = Convert.ToInt64(value);
                }
                catch (Exception ex)
                {
                  // ignore   
                }
                
            }

        }

        /// <summary>
        /// Numerisk 6 posisjoner , DDMMÅÅ.  
        /// Feltet skal inneholde tidligste oppgitte forfallsdato i forsendelsen.
        /// </summary>
        public String FørsteDato
        {
            get
            {
                return førsteDato;
            }

            set
            {
                førsteDato=value.PadLeft(6,'0');
            }
        }

        /// <summary>
        /// Numerisk 6 posisjoner , DDMMÅÅ.  
        /// Feltet skal inneholde tidligste oppgitte forfallsdato i forsendelsen.
        /// </summary>
        public String SisteDato
        {
            get
            {
                return sisteDato;
            }

            set
            {
                sisteDato=value.PadLeft(6,'0');
            }
        }

        private String Filler
        {
            get
            {
                return filler.PadLeft(27, '0');
            }
        }

   

        public SluttRecordOppdragBetalingskrav()
        {
           
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Debug +FormatKode+TjenesteKode+OppdragsType+RecordType+AntallTransaksjoner+ AntallRecords+ SumBeløp+ FørsteDato+SisteDato +Filler);
            return sb.ToString();
          
        }
    }
}
