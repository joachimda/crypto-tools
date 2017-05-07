using System.IO;
using System.Text;
using System.Windows;

namespace Hashify
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _fileName = string.Empty;
        private byte[] _hashBytes;
        private string _hashString = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();
            var result = fileDialog.ShowDialog();

            if (result == true)
            {
                txtBoxFile.Text = fileDialog.FileName;
                _fileName = fileDialog.FileName;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(_fileName == string.Empty)
            {
                MessageBox.Show("Please choose a file to hash!", "Error");
                return;
            }
            
                using (var md5 = System.Security.Cryptography.MD5.Create())
                {
                    using (var stream = File.OpenRead(_fileName))
                    {
                        _hashBytes = md5.ComputeHash(stream);

                        txtBoxHash.Text = ByteArrayToHex(_hashBytes);
                    }
                }
        }

        private string ByteArrayToHex(byte[] bytes)
        {
            StringBuilder result = new StringBuilder(bytes.Length * 2);

            for (int i = 0; i < bytes.Length; i++)
                result.Append(bytes[i].ToString("X2"));

            return result.ToString();
        }



    }
}

