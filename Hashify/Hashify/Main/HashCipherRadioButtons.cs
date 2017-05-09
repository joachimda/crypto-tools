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
            Sha3Button = false;
        }

        private bool _md5Button;
        private bool _sha1Button;
        private bool _sha2Button;
        private bool _sha3Button;

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
            get => _sha2Button;
            set
            {
                _sha2Button = value;
                PropertyIsChanged(nameof(Sha2Button));
            }
        }

        public bool Sha3Button
        {
            get => _sha3Button;
            set
            {
                _sha3Button = value;
                PropertyIsChanged(nameof(Sha3Button));
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
            if (Sha2Button)
            {
                return HashingAlgorithms.SHA2;
            }
            if (Sha3Button)
            {
                return HashingAlgorithms.SHA3;
            }

            return Sha2Button ? HashingAlgorithms.SHA2 : HashingAlgorithms.NONE;
        }
    }
}
