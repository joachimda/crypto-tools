using System.ComponentModel;
using System.Windows.Controls;

namespace Hashify.Main.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel() { }


        public RadioButton SelectedButton { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
