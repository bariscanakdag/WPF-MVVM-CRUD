using Proje.Helper;
using Proje.Model;
using Proje.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Proje.ViewModel
{
    public class PersonelViewModel : INotifyPropertyChanged
    {
        PersonelProvider personelProvider = new PersonelProvider();
        PozisyonProvider pozisyonProvider = new PozisyonProvider();
        #region Constructor musterList
        private ObservableCollection<PersonelModel> personelList;
        public ObservableCollection<PersonelModel> PersonelList 
        {
            get { return personelList; }
            set
            {
                personelList = value;
            }

        }

       
      
        private string title;
        #endregion

        #region Personel Silme
        private void DeletePersonel()
        {
            personelProvider.PersonelSil(selecItem);
            PersonelList.Remove(selecItem);
        }
        private ICommand deletePersonelCommand;

        public ICommand DeletePersonelCommand
        {
            get
            {
                if (deletePersonelCommand == null)
                    deletePersonelCommand = new RelayCommand(DeletePersonel);
                return deletePersonelCommand;
            }
        }


        #endregion

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        #region Constructor MusteriViewModel
        public PersonelViewModel()
        {
            personelList = new ObservableCollection<PersonelModel>( personelProvider.personelGetir());
            pozisyonList = pozisyonProvider.pozisyonGetir();
            
            Title = "test";
        }
        #endregion

        #region Constructor pozisyonList
        private List<PozisyonModel> pozisyonList;

        public List<PozisyonModel> PozisyonList
        {
            get { return pozisyonList; }
            set { pozisyonList = value;
                OnPropertyChanged("PozisyonList");
            }
        }
        #endregion

        
        private ICommand addPersonelCommand;

        public ICommand AddPersonelCommand
        {
            get
            {
                if (addPersonelCommand == null)
                    addPersonelCommand = new RelayCommand(AddPersonel);
                return addPersonelCommand;
            }
        }
        private ICommand upListCommand;

        public ICommand UpListCommand
        {
            get {
                if (upListCommand == null)
                {
                    upListCommand = new RelayCommand(UpList);
                }
                return upListCommand;

            }
           
        }
        private PersonelModel selecItem;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public PersonelModel SelecItem       {
            get { return selecItem; }
            set { selecItem = value;
                OnPropertyChanged(nameof(SelecItem));
            }
        }

        private ICommand downListCommand;

        public ICommand DownListCommand
        {
            get {if (downListCommand == null)
                    downListCommand = new RelayCommand(DownList);
                return downListCommand; }
            
        }

        private void DownList()
        {
            if (PersonelList.IndexOf(selecItem) != PersonelList.Count-1 && PersonelList.IndexOf(SelecItem) != -1)
            {
                var Index = PersonelList.IndexOf(SelecItem);
                var temp = PersonelList[Index];
                PersonelList[Index] = personelList[Index + 1];
                PersonelList[Index + 1] = temp;
                SelecItem=PersonelList[Index + 1];
            }
        }

        private void UpList()
        {
            
          
           if(PersonelList.IndexOf(SelecItem) !=0 && PersonelList.IndexOf(SelecItem) != -1){
                var Index = PersonelList.IndexOf(SelecItem);
                var temp = PersonelList[Index];
                PersonelList[Index] = PersonelList[Index - 1];
                PersonelList[Index - 1] = temp;
                SelecItem = PersonelList[Index - 1];
            }
          
            


        }
        NewPersonWindow window;
        private void AddPersonel()
        {

            if (window == null)
            {
                
                window = new NewPersonWindow();
                window.NewPersonelViewModel.PersonelSave += NewPersonelViewModelPersonelSaved;
                window.Closing += NewPersonWindowClosing;
                window.Show();
            }
            else
            {
                window.Focus();
            }
               
            
                  
        }

        private void NewPersonelViewModelPersonelSaved(object sender, EventArgs e)
        {
            window.Close();
            
            //PersonelID Değeri otomatik olarak sıfır geliyor listeye sıfır diye kayıt
            //ediliyor. Veritabanından verileri çekmek lazım
            PersonelList.Add((PersonelModel)sender);
            
        }

        private void NewPersonWindowClosing(object sender, CancelEventArgs e)

        {
            window.Dispose();
            window = null;
        }
    }
}
