using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proje.View;

namespace Proje.Model
{
    public    class NewPersonelModel
    {
        private string adi;

        public string Adi
        {
            get { return adi; }
            set { adi = value; }
        }

        private string soyadi;

        public string Soyadi
        {
            get { return soyadi; }
            set { soyadi = value; }
        }
        private int yas;

        public int Yas
        {
            get { return yas; }
            set { yas = value; }
        }

        private string cinsiyet;

        public string Cinsiyet
        {
            get { return cinsiyet; }
            set { cinsiyet = value; }
        }
        private int pozisyonID;

        public int PozisyonID
        {
            get { return pozisyonID; }
            set { pozisyonID = value; }
        }

    }
}
