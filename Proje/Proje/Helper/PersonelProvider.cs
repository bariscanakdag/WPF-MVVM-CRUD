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
       

        public List<PersonelModel> personelGetir()
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
        public void musteriEkle(PersonelModel m)
        {
            //Gelen musteriyi veritabanına ekle
            string patch = @"C:\Users\asus\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("Data Source=" + patch);
            SQLiteCommand cmd = new SQLiteCommand("insert into personel(Adi,Soyadi,Yas,Cinsiyet,PozisyonID) " +
                "values (@ad,@soyad,@yas,@cinsiyet,@personel)", con);
            cmd.Parameters.AddWithValue("@ad", m.Adi);
            cmd.Parameters.AddWithValue("@soyad", m.Soyadi);
            cmd.Parameters.AddWithValue("@yas", m.Yas);
            cmd.Parameters.AddWithValue("@cinsiyet", m.Cinsiyet);
            cmd.Parameters.AddWithValue("@pozisyon", m.PozisyonID);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void personelEkle(NewPersonelModel m)
        {
            //Gelen musteriyi veritabanına ekle
            string patch = @"C:\Users\asus\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("Data Source=" + patch);
            SQLiteCommand cmd = new SQLiteCommand("insert into personel(Adi,Soyadi,Yas,Cinsiyet,PozisyonID) " +
                "values (@ad,@soyad,@yas,@cinsiyet,@personel)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@ad", m.Adi);
            cmd.Parameters.AddWithValue("@soyad", m.Soyadi);
            cmd.Parameters.AddWithValue("@yas", m.Yas);
            cmd.Parameters.AddWithValue("@cinsiyet", m.Cinsiyet);
            cmd.Parameters.AddWithValue("@personel", m.PozisyonID);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        internal void musteriEkle(NewPersonelModel person)
        {
            throw new NotImplementedException();
        }

        public void musteriSil(PersonelModel musteri)
        {
            if(musteri != null)
            {
                string patch = @"C:\Users\asus\Desktop\Personel.db";
                SQLiteConnection con = new SQLiteConnection("Data Source=" + patch);
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand("delete from personel where PersonelID=@id", con);
                cmd.Parameters.AddWithValue("@id", musteri.PersonelID);
                cmd.ExecuteNonQuery();
                con.Close();
            }
          
        }
    
    
        //Güncelleme metodu yaz...
    }
}
