using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetsLibrary.entities
{

    public class Forsendelse
    {
       public StartRecordForsendelse StartRecord = null;
       public SluttRecordForsendelse SluttRecord = null;
       public String TransaksjonsType= "21";
       public Boolean ForProduksjon = false;

       public SortedList<String,BetalingsKrav> BetalingskravListe = new SortedList<String,BetalingsKrav>();
       
        public void AddBetalingsKrav(String KontoNummer, int OppdragsNummer, String ForfallsDato, String MeldingsTekst, String KundeNavn, String ØreBeløp, String KID, int TransaksjonsNummer, String FremmedRef)
       {
           if (!BetalingskravListe.ContainsKey(TransaksjonsNummer.ToString().PadLeft(7,'0')))
           {
               BetalingsKrav krav = new BetalingsKrav(KontoNummer, OppdragsNummer,TransaksjonsType,TransaksjonsNummer,ØreBeløp,ForfallsDato,KID, MeldingsTekst,KundeNavn,FremmedRef, ForProduksjon);
               BetalingskravListe.Add(TransaksjonsNummer.ToString().PadLeft(7,'0'), krav);
           }
       }

       public Forsendelse(int KundeID, int ForsendelsesNr, bool prod)
       {
           ForProduksjon=prod;
           StartRecord= new StartRecordForsendelse(KundeID, ForsendelsesNr);
           SluttRecord= new SluttRecordForsendelse();
           SluttRecord.AntallRecords = "4";
           SluttRecord.AntallTransaksjoner="2";
           SluttRecord.SumBeløp="1000";
           if (!prod)
           {
               StartRecord.Debug="StartRecord:".PadRight(25, ' ');
               SluttRecord.Debug="SluttRecord:".PadRight(25, ' ');
           }
       }

       
      
       public override string ToString()
       {
           StringBuilder sb = new StringBuilder();
           sb.Append(StartRecord.ToString());
           foreach (BetalingsKrav b in BetalingskravListe.Values)
           {
               sb.Append(b.ToString());
           }
           sb.Append(SluttRecord.ToString());
           return sb.ToString();
       }
    }
}
