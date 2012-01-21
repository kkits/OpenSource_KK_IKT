using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetsLibrary.entities
{
    public abstract class BaseEntity
    {
        private string debug = "";
        private string tjenestekode = "";
        private string transaksjonstype="21";
        private string recordtype="00";
        private int transaksjonsnummer=1;
        public String Debug
        {
            get
            {
                return debug;
            }
            set
            {
                debug = value;
            }
        }

        public String Filler(int antTegn, char FillerTegn, bool RightAlignText)
        {
            String s = "";
            if(!RightAlignText)
                return s.PadLeft(antTegn,FillerTegn);
            else
                return s.PadRight(antTegn, FillerTegn);
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

      
        /// <summary>
        /// Numerisk, 2 posisjoner, alltid=30
        /// </summary>
        public String RecordType
        {
            get
            {
                return recordtype.PadLeft(2,'0');
            }
            set
            {
                if (value.Length==2)
                    recordtype= value;
            }

        }

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
                return tjenestekode.PadLeft(2, '0');
            }
             set
            {
                 if(value.Length ==2)
                    tjenestekode= value;
            }

        }

    }
}
