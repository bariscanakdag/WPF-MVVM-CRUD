using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Model
{
    public class ResimModel
    {
        private int resimID;

        public  int ResimID
        {
            get { return resimID; }
            set { resimID = value; }
        }
        private string resim;

        public string Resim
        {
            get { return resim; }
            set { resim = value; }
        }
        private int personelID;

        public int PersonelID
        {
            get { return personelID; }
            set { personelID = value; }
        }

    }
}
