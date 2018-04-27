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
        private string _adi;
        private string _soyadi;
        private int _yas;
        private string _cinsiyet;
        private int _personelID;
        #region Constructor Musteri
        public string Adi
        {
            get { return _adi; }
            set
            {
                _adi = value;
            }
        }
        public int Yas
        {
            get { return _yas; }
            set
            {
                _yas = value;
            }
        }
        public int PersonelID
        {
            get { return _personelID; }
            set
            {
                _personelID = value;
            }
        }
        public string Soyadi
        {
            get { return _soyadi; }
            set
            {
                _soyadi = value;
            }
        }
        public string Cinsiyet
        {
            get { return _cinsiyet; }
            set
            {
                _cinsiyet = value;
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
