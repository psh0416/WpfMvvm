using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvm
{
    class Window2ViewModel : Notifier
    {
        public DelegateCommand SaveCommand { get; private set; }
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


        public Window2ViewModel()
        {
            SaveCommand =
                new DelegateCommand(ButtonCmdExe, CanButtonCmdExe);
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
}
