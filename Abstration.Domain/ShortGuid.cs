using System;
using System.Linq;
using System.Text;

namespace eGP.Abstration.Domain
{
    public struct ShortGuid
    {
        public static readonly ShortGuid Empty = new ShortGuid(Guid.Empty);

        private Guid _guid;
        private string _value;

        public ShortGuid(string value)
        {
            _value = value;
            _guid = Decode(value);
        }

        public ShortGuid(Guid guid)
        {
            _value = Encode(guid);
            _guid = guid;
        }

        public Guid Guid
        {
            get { return _guid; }
            set
            {
                if (value != _guid)
                {
                    _guid = value;
                    _value = Encode(value);
                }
            }
        }


        public string Value
        {
            get { return _value; }
            set
            {
                if (value != _value)
                {
                    _value = value;
                    _guid = Decode(value);
                }
            }
        }

        public override string ToString()
        {
            return _value;
        }


        public override bool Equals(object obj)
        {
            if (obj is ShortGuid guid)
                return _guid.Equals(guid._guid);
            if (obj is Guid guid1)
                return _guid.Equals(guid1);
            if (obj is string)
                return _guid.Equals(g: ((ShortGuid)obj)._guid);
            return false;
        }

        public override int GetHashCode()
        {
            return _guid.GetHashCode();
        }
        public static ShortGuid NewGuid()
        {
            return new ShortGuid(Guid.NewGuid());
        }
        public static string Encode(string value)
        {
            Guid guid = new Guid(value);
            return Encode(guid);
        }

        public static string Encode(Guid guid)
        {
            string encoded = Convert.ToBase64String(guid.ToByteArray());
            encoded = encoded
                .Replace("/", "_")
                .Replace("+", "-");
            return encoded.Substring(0, 22);
        }
        public static Guid Decode(string value)
        {
            value = value
                .Replace("_", "/")
                .Replace("-", "+");
            byte[] buffer = Convert.FromBase64String(value + "==");
            return new Guid(buffer);
        }
        public static bool operator ==(ShortGuid x, ShortGuid y)
        {
            return x._guid == y._guid;
        }


        public static bool operator !=(ShortGuid x, ShortGuid y)
        {
            return !(x == y);
        }


        public static implicit operator string(ShortGuid shortGuid)
        {
            return shortGuid._value;
        }


        public static implicit operator Guid(ShortGuid shortGuid)
        {
            return shortGuid._guid;
        }


        public static implicit operator ShortGuid(string shortGuid)
        {
            return new ShortGuid(shortGuid);
        }

        public static implicit operator ShortGuid(Guid guid)
        {
            return new ShortGuid(guid);
        }

        public static string GenerateCode(int codeLength)
        {
            StringBuilder builder = new StringBuilder();
            Enumerable
                .Range(65, 26)
                .Select(e => ((char)e).ToString())
                .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                .OrderBy(e => Guid.NewGuid())
                .Take(codeLength)
                .ToList().ForEach(e => builder.Append(e));
            return builder.ToString();
        }
    }

}
