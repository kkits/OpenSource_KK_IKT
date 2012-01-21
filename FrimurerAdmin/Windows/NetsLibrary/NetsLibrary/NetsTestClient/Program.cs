using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NetsTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            NetsLibrary.entities.Forsendelse f= new NetsLibrary.entities.Forsendelse(1234, 1,false);
            f.AddBetalingsKrav("18001379239", 999999, "020212","TEST KRAV NR 1", "KARLSEN KJELL","360000","012912012011",1,"KONT 2012");
            f.AddBetalingsKrav("18001379238", 999998, "110212","TEST KRAV NR 2", "HANSEN OLE","360000","012922012011",2,"KONT 2012");
            f.AddBetalingsKrav("18221379238", 999998, "110212", "TEST KRAV NR 3", "IVERSEN NILS", "360000", "012932012011", 3, "KONT 2012");
            f.SluttRecord.AntallTransaksjoner="3";
            f.SluttRecord.AntallRecords="3";
            f.SluttRecord.FørsteDato="020212";
            f.SluttRecord.SumBeløp="1080000";
            TextWriter tw = new StreamWriter("c:\\NETS.txt",false, Encoding.UTF8);
            tw.Write(f.ToString());
            tw.Close();
            System.Diagnostics.Process.Start("c:\\NETS.txt");
        }
    }
}
