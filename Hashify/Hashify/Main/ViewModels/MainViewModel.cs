using System;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Hashify.Crypto;
using Hashify.Crypto.HashFunctions;
using Hashify.View.ViewModel;

namespace Hashify.Main.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            HashifyCommand = new RelayCommand(ExecuteHashifyCommand);
            SelectFileCommand = new RelayCommand(ExecuteSelectFileCommand);
            RadioButtons = new HashCipherRadioButtons();
        }

        private void ExecuteHashifyCommand(object o)
        {
            if (FileName == string.Empty)
            {
                MessageBox.Show("Please choose a file to hash!", "Error");
                return;
            }

            _algorithms = RadioButtons.GetSelectedButton();

            switch (_algorithms)
            {
                case HashingAlgorithms.MD5:
                     HashedFile = Md5Toolbox.GetFileHashAsString(FileName, ByteArrayToHex);
                    break;
                case HashingAlgorithms.SHA1:
                    HashedFile = Sha1Toolbox.GetFileHashAsString(FileName, ByteArrayToHex);
                    break;
                case HashingAlgorithms.SHA2:
                    HashedFile = Sha256ToolBox.GetFileHashAsString(FileName, ByteArrayToHex);
                    break;
                case HashingAlgorithms.SHA3:
                    HashedFile = Sha384ToolBox.GetFileHashAsString(FileName, ByteArrayToHex);
                    break;
                case HashingAlgorithms.NONE:
                    {
                        MessageBox.Show("Please choose a hashing algorithm!", "Error");
                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private void ExecuteSelectFileCommand(object o)
        {
            var fileDialog = new Microsoft.Win32.OpenFileDialog();
            var result = fileDialog.ShowDialog();

            if (result == true)
            {
                FileName = fileDialog.FileName;
            }
        }

        public ICommand HashifyCommand { get; set; }
        public ICommand SelectFileCommand { get; set; }

        public HashCipherRadioButtons RadioButtons { get; set; }

        public string FileName
        {
            get => _fileName;
            set
            {
                _fileName = value;
                PropertyIsChanged(nameof(FileName));
            }
        }

        private static string ByteArrayToHex(byte[] bytes)
        {
            var result = new StringBuilder(bytes.Length * 2);

            for (int i = 0; i < bytes.Length; i++)
                result.Append(bytes[i].ToString("X2"));

            return result.ToString();
        }

        public string HashedFile
        {
            get => _hashedFile;
            set
            {
                _hashedFile = value;
                PropertyIsChanged(nameof(HashedFile));
            }
        }
        private string _fileName = string.Empty;
        private string _hashedFile;
        private HashingAlgorithms _algorithms;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void PropertyIsChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
