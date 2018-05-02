﻿using Proje.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Helper
{
    public class ResimProvaider
    {
        

        public List<ResimModel> ResimleriGetir()
        {
            List<ResimModel> resims = new List<ResimModel>();
            string patch = @"C:\Users\asus\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("Data Source=" + patch);
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand("select * from resim", con) ;
            SQLiteDataReader dr = cmd.ExecuteReader();
            ResimModel rs = new ResimModel();
            while (dr.Read())
            {
               
                rs.Resim = dr.GetString(dr.GetOrdinal("Resim"));
                rs.ResimID = dr.GetInt32(dr.GetOrdinal("ResimID"));
                resims.Add(rs);
            }
            con.Close();
            return resims;
        }
        public void ResimSil(ResimModel resim)
        {
            string patch = @"C:\Users\asus\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("Data Source=" + patch);
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand("delete from resim where=@isim");
            cmd.Parameters.AddWithValue("@isim", resim.Resim);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void ResimSil(string resim)
        {
            string patch = @"C:\Users\asus\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("Data Source=" + patch);
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand("delete from resim where=@isim");
            cmd.Parameters.AddWithValue("@isim", resim);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void ResimEkle(ResimModel rs)
        {
            string patch = @"C:\Users\asus\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("Data Source=" + patch);
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand("insert into resim(Resim) values(@resim)",con);
            cmd.Parameters.AddWithValue("@resim", rs.Resim);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void ResimEkle(string rs)
        {
            string patch = @"C:\Users\asus\Desktop\Personel.db";
            SQLiteConnection con = new SQLiteConnection("Data Source=" + patch);
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand("insert into resim(Resim) values(@resim)", con);
            cmd.Parameters.AddWithValue("@resim", rs);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        //Uptade metotları yazılacak
        //bitmap yazılacak

    }
}
