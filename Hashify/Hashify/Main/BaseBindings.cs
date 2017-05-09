using System.ComponentModel;

namespace Hashify.Main
{
    public class BaseBindings: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void PropertyIsChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
