using Hashify.Crypto;

namespace Hashify.Main
{
    public class HashCipherRadioButtons : BaseBindings
    {
        public HashCipherRadioButtons()
        {
            Md5Button = false;
            Sha1Button = false;
            Sha2Button = false;
        }

        private bool _md5Button;
        private bool _sha1Button;
        private bool _sha2Button1;

        public bool Md5Button
        {
            get => _md5Button;
            set
            {
                _md5Button = value;
                PropertyIsChanged(nameof(Md5Button));
            }
        }

        public bool Sha1Button
        {
            get => _sha1Button;
            set
            {
                _sha1Button = value;
                PropertyIsChanged(nameof(Sha1Button));
            }
        }

        public bool Sha2Button
        {
            get => _sha2Button1;
            set
            {
                _sha2Button1 = value;
                PropertyIsChanged(nameof(Sha2Button));
            }
        }

        public HashingAlgorithms GetSelectedButton()
        {
            if (Md5Button)
            {
                return HashingAlgorithms.MD5;
            }

            if (Sha1Button)
            {
                return HashingAlgorithms.SHA1;
            }

            return Sha2Button ? HashingAlgorithms.SHA2 : HashingAlgorithms.NONE;
        }
    }
}
