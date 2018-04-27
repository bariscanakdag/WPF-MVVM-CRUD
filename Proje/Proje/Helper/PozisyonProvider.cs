using Proje.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Helper
{
    public class PozisyonProvider
    {
   

        public List<PozisyonModel> pozisyonGetir()
        {
            List<PozisyonModel> pozisyonList = new List<PozisyonModel>();
            string patch = @"C:\Users\asus\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("Data Source="+patch);
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand("select * from pozisyon", con);
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                PozisyonModel pozisyons = new PozisyonModel();
                pozisyons.Pozisyon = dr.GetString(dr.GetOrdinal("Pozisyon"));
                pozisyons.PozisyonID = dr.GetInt32(dr.GetOrdinal("PozisyonID"));
                
                pozisyonList.Add(pozisyons);
            }
            con.Close();
            return pozisyonList;
        }

        public void pozisyonSil(PozisyonModel p)
        {
            string patch = @"C:\Users\asus\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("Data Source=" + patch);
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand("delete from Pozisyon where=@pozisyon");
            cmd.Parameters.AddWithValue("@pozisyon", p.Pozisyon);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void pozisyonSil(string p)
        {
            string patch = @"C:\Users\asus\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("Data Source=" + patch);
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand("delete from Pozisyon where=@pozisyon");
            cmd.Parameters.AddWithValue("@pozisyon", p);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void  pozisyonEkle(PozisyonModel pozisyon)
        {

            string patch = @"C:\Users\asus\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("Data Source=" + patch);
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand("insert into personel(Pozisyon) values (@pozisyon)", con);
            cmd.Parameters.AddWithValue("@pozisyon", pozisyon.Pozisyon);
            cmd.ExecuteNonQuery();
            con.Close();
        }


    }
}
