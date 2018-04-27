using Proje.Helper;
using Proje.Model;
using Proje.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proje.ViewModel
{
    public class NewPersonelViewModel
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
        private int yasi;

        public int Yasi
        {
            get { return yasi; }
            set { yasi = value; }
        }
        private string cinsiyet;

        public string Cinsiyet
        {
            get { return cinsiyet; }
            set { cinsiyet = value; }
        }

        private string  selectPozisyon ;

        public string SelectPozisyon
        {
            get { return selectPozisyon; }
            set { selectPozisyon = value; }
        }
        private ICommand savePersonel;

        public ICommand SavePersonel
        {
            get {
                if (savePersonel == null)
                    savePersonel = new RelayCommand(Save);
                return savePersonel;

            }
            
        }

        private void Save()
        {
            NewPersonelModel person = new NewPersonelModel();
            person.Adi = Adi;
            person.Soyadi = Soyadi;
            person.Yas = Yasi;
            person.Cinsiyet = Cinsiyet;

            //Hata verebilir
            person.PozisyonID = int.Parse(SelectPozisyon);
           PersonelProvider personelProvider = new PersonelProvider();
            personelProvider.personelEkle(person);
            PersonelViewModel personelViewModel = new PersonelViewModel();
           personelViewModel.
           }
      



    }
}
