using Proje.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Helper
{
    public class PersonelProvider
    {
        /// <summary>
        /// Personelleri liste olarak geri döndürür
        /// </summary>
        /// <returns>PersonelList Geri Döndürür</returns>
        #region PersonelGetir Provider
        public List<PersonelModel> PersonelGetir()
        {

            //Personel tablosundan verileri çeker MusteriProvaider tipindeki listeye atar ve geri döner
            List<PersonelModel> personeller = new List<PersonelModel>();
            string patch = @"C:\Users\asus\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("Data Source=" + patch);
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand("select * from personel", con);
            SQLiteDataReader dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                PersonelModel m = new PersonelModel();
                m.Adi = dr.GetString(dr.GetOrdinal("Adi"));
                m.Soyadi = dr.GetString(dr.GetOrdinal("Soyadi"));
                m.Yas = dr.GetInt32(dr.GetOrdinal("Yas"));
                m.Cinsiyet = dr.GetString(dr.GetOrdinal("Cinsiyet"));
                m.PersonelID = dr.GetInt32(dr.GetOrdinal("PersonelID"));
                m.PozisyonID = dr.GetInt32(dr.GetOrdinal("PozisyonID"));
                personeller.Add(m);
            }
            con.Close();
            return personeller;
        }


        #endregion

        /// <summary>
        /// Parametre olarak personel nesnesini veritabanına ekler
        /// </summary>
        /// <param name="personel"></param>
        #region PersonelEkle Provider
        public void PersonelEkle(PersonelModel personel)
        {
            //Gelen musteriyi veritabanına ekle
            string patch = @"C:\Users\asus\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("Data Source=" + patch);
            SQLiteCommand cmd = new SQLiteCommand("insert into personel(Adi,Soyadi,Yas,Cinsiyet,PozisyonID) " +
                "values (@ad,@soyad,@yas,@cinsiyet,@personel)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@ad", personel.Adi);
            cmd.Parameters.AddWithValue("@soyad", personel.Soyadi);
            cmd.Parameters.AddWithValue("@yas", personel.Yas);
            cmd.Parameters.AddWithValue("@cinsiyet", personel.Cinsiyet);
            cmd.Parameters.AddWithValue("@personel", personel.PozisyonID);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        #endregion

        /// <summary>
        /// Gelen personel'i günceller
        /// </summary>
        /// <param name="personel"></param>
        #region PersonelEdit Provider
        public void PersonelEdit(PersonelModel personel)
        {
            string patch = @"C:\Users\asus\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("Data Source=" + patch);
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand("update personel set Adi=@adi,Soyadi=@soyadi,Yas=@yasi,Cinsiyet=@cinsiyet,PozisyonID=@pozisyonid where PersonelID=@id",con);
            cmd.Parameters.AddWithValue("@id", personel.PersonelID);
            cmd.Parameters.AddWithValue("@adi", personel.Adi);

            cmd.Parameters.AddWithValue("@soyadi", personel.Soyadi);
            cmd.Parameters.AddWithValue("@yasi", personel.Yas);
            cmd.Parameters.AddWithValue("@cinsiyet", personel.Cinsiyet);
            cmd.Parameters.AddWithValue("@pozisyonid", personel.PozisyonID);

            cmd.ExecuteNonQuery();
            con.Close();

        }
        #endregion

        /// <summary>
        /// Son eklenen personeli geri döndürür
        /// </summary>
        /// <returns>En son eklenen kayıt</returns>
        #region TekPersonelGetir Provider
        public PersonelModel TekPersonelGetir()
        {
            string patch = @"C:\Users\asus\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("Data Source=" + patch);
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM personel ORDER BY PersonelID DESC LIMIT 1 ", con);
            
            SQLiteDataReader dr = cmd.ExecuteReader();
            PersonelModel model = new PersonelModel();

            while (dr.Read())
            {
                model.Adi = dr.GetString(dr.GetOrdinal("Adi"));
                model.Soyadi = dr.GetString(dr.GetOrdinal("Soyadi"));
                model.Yas = dr.GetInt32(dr.GetOrdinal("Yas"));
                model.Cinsiyet = dr.GetString(dr.GetOrdinal("Cinsiyet"));
                model.PersonelID = dr.GetInt32(dr.GetOrdinal("PersonelID"));
                model.PozisyonID = dr.GetInt32(dr.GetOrdinal("PozisyonID"));
                
            }
            return model;
                
        }
        #endregion

        /// <summary>
        /// Gelen personel nesnesinin id'sine göre veritabanından bulup siler
        /// </summary>
        /// <param name="personel"></param>
        #region PersonelSil Provider
        public void PersonelSil(PersonelModel personel)
        {
            if(personel != null)
            {
                string patch = @"C:\Users\asus\Desktop\Personel.db";
                SQLiteConnection con = new SQLiteConnection("Data Source=" + patch);
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand("delete from personel where PersonelID=@id", con);
                cmd.Parameters.AddWithValue("@id", personel.PersonelID);
                cmd.ExecuteNonQuery();
                con.Close();
            }
          
        }
        #endregion

    }
}
