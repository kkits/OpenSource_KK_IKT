using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetsLibrary.entities
{
    public class BetalingsKrav:BaseEntity
    {
        public StartRecordOppdragBetalingskrav StartOppdragBetalingsKrav = null;
        public SluttRecordOppdragBetalingskrav SluttOppdragBetalingsKrav = null;
        public BeløpsPost1 Beløp1 = null;
        public BeløpsPost2 Beløp2 = null;
        public SpesifikasjonsRecord SpecRecord = null;
        public int Transaksjonsnummer
        {
            get;
            set;
        }


        public BetalingsKrav(String kontoNummer, int oppdragsnummer, String transaksjonstype, int transaksjonsnr, 
            String ØreBeløp, String Forfallsdato, String KID, 
            String MeldingTilMottaker,String KortNavn, String FremmedRef, bool forProduksjon)
        {
            StartOppdragBetalingsKrav= new StartRecordOppdragBetalingskrav(kontoNummer, oppdragsnummer);
            SluttOppdragBetalingsKrav= new SluttRecordOppdragBetalingskrav();
            Beløp1= new BeløpsPost1(transaksjonstype, transaksjonsnr,Forfallsdato,ØreBeløp,KID);
            Beløp2 = new BeløpsPost2(transaksjonstype, transaksjonsnr, KortNavn, FremmedRef);
            Transaksjonsnummer=transaksjonsnr;
            SpecRecord= new SpesifikasjonsRecord(Transaksjonsnummer,MeldingTilMottaker);
            SluttOppdragBetalingsKrav.FørsteDato="010112";
            SluttOppdragBetalingsKrav.SisteDato="010212";
            if (!forProduksjon)
            {
                StartOppdragBetalingsKrav.Debug="StartOppd.BetalingsKrav:".PadRight(25, ' ');
                SluttOppdragBetalingsKrav.Debug="SluttOppd.BetalingsKrav:".PadRight(25, ' ');
                Beløp1.Debug="Beløp1:".PadRight(25, ' ');
                Beløp2.Debug="Beløp2:".PadRight(25, ' ');
                SpecRecord.Debug="Spesifikasjon:".PadRight(25, ' ');
            }
        }

      
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(StartOppdragBetalingsKrav.ToString());
            sb.Append(Beløp1.ToString());
            sb.Append(Beløp2.ToString());
            sb.Append(SpecRecord.ToString());
            sb.Append(SluttOppdragBetalingsKrav.ToString());
            return sb.ToString();
        }
    }
}
