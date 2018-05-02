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
        /// <summary>
        /// Pozisyon bilgilerine bu provider'dan ulaşırız
        /// </summary>
        /// <returns>Pozisyon ve PozisyonID döner</returns>
        #region PozisyonGetir Provider
        public List<PozisyonModel> PozisyonGetir()
        {
            List<PozisyonModel> pozisyonList = new List<PozisyonModel>();
            string patch = @"C:\Users\asus\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("Data Source="+patch);
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand("select * from pozisyon", con);
            SQLiteDataReader dr = cmd.ExecuteReader();
            PozisyonModel pozisyons;
            while (dr.Read())
            {
                pozisyons = new PozisyonModel();
                pozisyons.Pozisyon = dr.GetString(dr.GetOrdinal("Pozisyon"));
                pozisyons.PozisyonID = dr.GetInt32(dr.GetOrdinal("PozisyonID"));
                
                pozisyonList.Add(pozisyons);
            }
            con.Close();
            return pozisyonList;
        }
        #endregion

        /// <summary>
        /// Pozisyon Ekleme,silme,düzenleme kullanılmıyor
        /// </summary>
        /// <param name="p"></param>
        #region Kullanılmayan Provaiderler
        public void PozisyonSil(PozisyonModel p)
        {
            string patch = @"C:\Users\asus\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("Data Source=" + patch);
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand("delete from Pozisyon where=@pozisyon");
            cmd.Parameters.AddWithValue("@pozisyon", p.Pozisyon);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void PozisyonSil(string p)
        {
            string patch = @"C:\Users\asus\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("Data Source=" + patch);
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand("delete from Pozisyon where=@pozisyon");
            cmd.Parameters.AddWithValue("@pozisyon", p);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void  PozisyonEkle(PozisyonModel pozisyon)
        {

            string patch = @"C:\Users\asus\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("Data Source=" + patch);
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand("insert into personel(Pozisyon) values (@pozisyon)", con);
            cmd.Parameters.AddWithValue("@pozisyon", pozisyon.Pozisyon);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        #endregion

    }
}
