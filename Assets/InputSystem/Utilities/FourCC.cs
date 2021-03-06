using UnityEngine;

namespace ISX.Utilities
{
    public struct FourCC
    {
        int m_Code;

        public FourCC(char a, char b = ' ', char c = ' ', char d = ' ')
        {
            m_Code = (a << 24) | (b << 16) | (c << 8) | d;
        }

        public FourCC(string str)
            : this()
        {
            var length = str.Length;
            Debug.Assert(length >= 1 && length <= 4, "FourCC string must be one to four characters long!");

            var a = str[0];
            var b = length > 1 ? str[1] : ' ';
            var c = length > 2 ? str[2] : ' ';
            var d = length > 3 ? str[3] : ' ';

            m_Code = (a << 24) | (b << 16) | (c << 8) | d;
        }

        public static implicit operator int(FourCC fourCC)
        {
            return fourCC.m_Code;
        }

        public static implicit operator FourCC(int i)
        {
            var fourCC = new FourCC {m_Code = i};
            return fourCC;
        }

        public override string ToString()
        {
            return
                string.Format("{0}{1}{2}{3}", (char)(m_Code >> 24), (char)((m_Code & 0xff0000) >> 16),
                (char)((m_Code & 0xff00) >> 8), (char)(m_Code & 0xff));
        }
    }
}
