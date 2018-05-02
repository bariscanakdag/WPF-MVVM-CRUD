using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Model
{
    public class PozisyonModel
    {
        private int pozisyonID;
        private string pozisyon;
        /// <summary>
        /// Pozisyon bilgilerini tutan yapıcımız
        /// </summary>
        #region PozisyonModel Contractor
        public int PozisyonID
        {
            get { return pozisyonID; }
            set { pozisyonID = value; }
        }

        public string Pozisyon
        {
            get { return pozisyon; }
            set { pozisyon = value; }
        }

    }
    #endregion


}

