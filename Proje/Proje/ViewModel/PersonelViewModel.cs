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

                OnPropertyChanged(nameof(PersonelList));
            }

        }



        private string title;
        #endregion

        /// <summary>
        /// ListView'den seçili olan personeli siler
        /// </summary>
        #region Personel Silme

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
        private void DeletePersonel()
        {
            personelProvider.PersonelSil(selecItem);
            PersonelList.Remove(selecItem);
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
            personelList = new ObservableCollection<PersonelModel>(personelProvider.PersonelGetir());
            pozisyonList = pozisyonProvider.PozisyonGetir();

            Title = "test";
        }
        #endregion

        #region Constructor pozisyonList
        private List<PozisyonModel> pozisyonList;

        public List<PozisyonModel> PozisyonList
        {
            get { return pozisyonList; }
            set
            {
                pozisyonList = value;
                OnPropertyChanged("PozisyonList");
            }
        }
        #endregion



        #region UpList Listede Yukarı Çıkma
        private ICommand upListCommand;

        public ICommand UpListCommand
        {
            get
            {
                if (upListCommand == null)
                {
                    upListCommand = new RelayCommand(UpList);
                }
                return upListCommand;

            }

        }
        private void UpList()
        {


            if (PersonelList.IndexOf(SelecItem) != 0 && PersonelList.IndexOf(SelecItem) != -1)
            {
                var Index = PersonelList.IndexOf(SelecItem);
                var temp = PersonelList[Index];
                PersonelList[Index] = PersonelList[Index - 1];
                PersonelList[Index - 1] = temp;
                SelecItem = PersonelList[Index - 1];
            }

        }
        #endregion



        #region SelecItem Contractor
        private PersonelModel selecItem;
        public PersonelModel SelecItem
        {
            get { return selecItem; }
            set
            {
                selecItem = value;
                OnPropertyChanged(nameof(SelecItem));
            }
        }
        #endregion



        #region DownList ListViewde Aşağı Gitme


        private ICommand downListCommand;

        public ICommand DownListCommand
        {
            get
            {
                if (downListCommand == null)
                    downListCommand = new RelayCommand(DownList);
                return downListCommand;
            }

        }

        private void DownList()
        {
            if (PersonelList.IndexOf(selecItem) != PersonelList.Count - 1 && PersonelList.IndexOf(SelecItem) != -1)
            {
                var Index = PersonelList.IndexOf(SelecItem);
                var temp = PersonelList[Index];
                PersonelList[Index] = personelList[Index + 1];
                PersonelList[Index + 1] = temp;
                SelecItem = PersonelList[Index + 1];
            }
        }

        #endregion

        /// <summary>
        /// Yeni kişi ekle butonuna basıldığında NewPersonWindow açılır
        /// NewPersonWindow pencerisinde kayıt'a basıldığında.
        /// Kayıt yapılır ve pencere kapatılır.
        /// </summary>
        #region AddPersonel PersonelEkleme

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
        NewPersonWindow window;
        private void AddPersonel()
        {
           
            if (window == null)
            {
                PersonelModel personel = new PersonelModel();
               
                window = new NewPersonWindow(personel);
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
            PersonelList.Add((PersonelModel)sender);

        }
        private void NewPersonWindowClosing(object sender, CancelEventArgs e)

        {
            window.Dispose();
            window = null;
        }
        #endregion


        /// <summary>
        /// Düzenleye basıldığında EditPersonelWindow pencere açılır.
        /// EditPersonelWindow penceresinde kayıta basıldığında
        /// EditPersonelWindow kapanır.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region EditPersonelCommand 

        private ICommand editPersonelCommand;

        public ICommand EditPersonelCommand
        {
            get
            {
                if (editPersonelCommand == null)
                    editPersonelCommand = new RelayCommand(Edit);
                return editPersonelCommand;

            }

        }
        EditPersonelWindow EditWindow;


        private void Edit()
        {
            if (EditWindow == null)
            {
                EditWindow = new EditPersonelWindow(SelecItem);
                EditWindow.Show();
                EditWindow.EditPersonelViewModel.PersonelEdit += EditPersonelViewModelPersonelEdit;
                EditWindow.Closing += EditPersonWindowClosing;

            }


        }

        private void EditPersonelViewModelPersonelEdit(object sender, EventArgs e)
        {
            EditWindow.Close();
            sender = null;

        }

        private void EditPersonWindowClosing(object sender, CancelEventArgs e)
        {
            EditWindow.Dispose();
            EditWindow = null;
        }
        #endregion



        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
}
