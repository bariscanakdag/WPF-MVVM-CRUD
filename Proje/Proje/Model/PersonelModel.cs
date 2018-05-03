using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Model
{
    public class PersonelModel
    {


        /// <summary>
        /// Personel nesnesinin tüm özellikleri tutulur.
        /// </summary>
        #region Constructor Musteri
        private string adi;
        private string soyadi;
        private int yas;
        private string cinsiyet;
        private int personelID;
        public string Adi
        {

            get { return adi; }
            set
            {
                adi = value;
            }
        }
        public int Yas
        {
            get { return yas; }
            set
            {
                yas = value;
            }
        }
        public int PersonelID
        {
            get { return personelID; }
            set
            {
                personelID = value;
            }
        }
        public string Soyadi
        {
            get { return soyadi; }
            set
            {
                soyadi = value;
            }
        }
        public string Cinsiyet
        {
            get { return cinsiyet; }
            set
            {
                cinsiyet = value;
            }
        }
        private int pozisyonID;

        public int PozisyonID
        {
            get { return pozisyonID; }
            set { pozisyonID = value; }
        }

        #endregion


    }
}
