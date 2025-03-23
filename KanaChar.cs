using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kana
{
    public class KanaChar(string hiragana, string katakana, string romaji, string phoneticSymbol, bool oldCharObsoleted = false)
    {
        public bool OldCharObsoleted { get; } = oldCharObsoleted;
        public string Hiragana { get; } = hiragana;
        public string Katakana { get; } = katakana;
        public string Romaji { get; } = romaji;
        public string PhoneticSymbol { get; } = phoneticSymbol;

        public static KanaChar Null { get; } = new("", "", "", "");
    }
}
