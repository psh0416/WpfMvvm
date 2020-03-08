using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfMvvm
{
    class Window1ViewModel : Notifier
    {
        public DelegateCommand SaveCommand { get; private set; }

        private Item selectedItem;
        public Item SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");

                Num1 = selectedItem.Int1;
                Check1 = selectedItem.Bool1;
                
            }
        }

        private ObservableCollection<Item> items;
        public ObservableCollection<Item> Items
        {
            get { return items; }
            set
            {
                if (value != this.items)
                {
                    items = value;
                    OnPropertyChanged("Items");
                }
            }
        }
        private int num1;
        public int Num1
        {
            get => num1;
            set { num1 = value; OnPropertyChanged("Num1"); }
        }
        private bool check1;
        public bool Check1
        {
            get => check1;
            set { check1 = value; OnPropertyChanged("Check1"); }
        }
        private bool check2;
        public bool Check2
        { 
            get => check2;
            set { check2 = value; OnPropertyChanged("Check2"); }
        }
        private string text1;
        public string Text1
        {
            get => text1;
            set { text1 = value; OnPropertyChanged("Text1"); }
        }
        
        public Window1ViewModel()
        {
            SaveCommand =
                new DelegateCommand(ButtonCmdExe, CanButtonCmdExe);
            Items = new ObservableCollection<Item>();
            for (int i = 0; i < 10; i++)
            {
                Item iTemp = new Item();
                iTemp.Int1 = i;
                iTemp.Str1 = "str" + i;
                iTemp.Bool1 = i % 2 == 0;
                Items.Add(iTemp);
            }
            
        }

        private void ButtonCmdExe(object param)
        {
            Check1 = !Check1;
            //MessageBox.Show("버튼 클릭");
        }

        private bool CanButtonCmdExe(object param)
        {
            return true;
        }



    }

    public struct Item
    {
        public string Str1 { get; set; }
        public int Int1 { get; set; }
        public bool Bool1 { get; set; }
    }
}
