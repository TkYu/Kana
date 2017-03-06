using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kana.Models;
using Xamarin.Forms;

namespace Kana
{
    public static class Kanas
    {
        public static KanaChar[,] Seion { get; } =
        {
            {new KanaChar("あ", "ア", "a", "[ä]"), new KanaChar("い", "イ", "i", "[i]"), new KanaChar("う", "ウ", "u", "[ɯ̹]"), new KanaChar("え", "エ", "e", "[e̞]"), new KanaChar("お", "オ", "o", "[o̞]")},
            {new KanaChar("か", "カ", "ka", "[kä]"), new KanaChar("き", "キ", "ki", "[kʲi]"), new KanaChar("く", "ク", "ku", "[kɯ̹]"), new KanaChar("け", "ケ", "ke", "[ke̞]"), new KanaChar("こ", "コ", "ko", "[ko̞]")},
            {new KanaChar("さ", "サ", "sa", "[sä]"), new KanaChar("し", "シ", "si", "[ɕi]"), new KanaChar("す", "ス", "su", "[sɯ̹̈]"), new KanaChar("せ", "セ", "se", "[se̞]"), new KanaChar("そ", "ソ", "so", "[so̞]")},
            {new KanaChar("た", "タ", "ta", "[tä]"), new KanaChar("ち", "チ", "ci", "[t͡ɕi]"), new KanaChar("つ", "ツ", "cu", "[t͡sɯ̹̈]"), new KanaChar("て", "テ", "te", "[te̞]"), new KanaChar("と", "ト", "to", "[to̞]")},
            {new KanaChar("な", "ナ", "na", "[nä]"), new KanaChar("に", "ニ", "ni", "[nʲi]"), new KanaChar("ぬ", "ヌ", "nu", "[nɯ̹]"), new KanaChar("ね", "ネ", "ne", "[ne̞]"), new KanaChar("の", "ノ", "no", "[no̞]")},
            {new KanaChar("は", "ハ", "ha", "[hä]"), new KanaChar("ひ", "ヒ", "hi", "[çi]"), new KanaChar("ふ", "フ", "hu", "[Φɯ̹]"), new KanaChar("へ", "ヘ", "he", "[he̞]"), new KanaChar("ほ", "ホ", "ho", "[ho̞]")},
            {new KanaChar("ま", "マ", "ma", "[mä]"), new KanaChar("み", "ミ", "mi", "[mʲi]"), new KanaChar("む", "ム", "mu", "[mɯ̹]"), new KanaChar("め", "メ", "me", "[me̞]"), new KanaChar("も", "モ", "mo", "[mo̞]")},
            {new KanaChar("や", "ヤ", "ya", "[jä]"), new KanaChar("い", "イ", "i", "[i]",true), new KanaChar("ゆ", "ユ", "yu", "[jɯ̹]"), new KanaChar("え", "エ", "e", "[e̞]",true), new KanaChar("よ", "ヨ", "yo", "[jo̞]")},
            {new KanaChar("ら", "ラ", "ra", "[ɺä]"), new KanaChar("り", "リ", "ri", "[ɺʲi]"), new KanaChar("る", "ル", "ru", "[ɺɯ̹]"), new KanaChar("れ", "レ", "re", "[ɺe̞]"), new KanaChar("ろ", "ロ", "ro", "[ɺo̞]")},
            {new KanaChar("わ", "ワ", "wa", "[β̞ä]"), new KanaChar("い", "イ", "i", "ゐ、ヰ",true), new KanaChar("う", "ウ", "u", "[ɯ̹]",true), new KanaChar("え", "エ", "e", "ゑ、ヱ",true), new KanaChar("を", "ヲ", "o", "[o̞]")},
            {new KanaChar("ん", "ン", "n/nn", "[n]"), null, null, null, null}
        };

        public static KanaChar[,] Dakuon { get; } =
        {
            {new KanaChar("が", "ガ", "ga", null), new KanaChar("ぎ", "ギ", "gi", null), new KanaChar("ぐ", "グ", "gu", null), new KanaChar("げ", "ゲ", "ge", null), new KanaChar("ご", "ゴ", "go", null)},
            {new KanaChar("ざ", "ザ", "za", null), new KanaChar("じ", "ジ", "ji", null), new KanaChar("ず", "ズ", "zu", null), new KanaChar("ぜ", "ゼ", "ze", null), new KanaChar("ぞ", "ゾ", "zo", null)},
            {new KanaChar("だ", "ダ", "da", null), new KanaChar("ぢ", "ヂ", "ji", null), new KanaChar("づ", "ヅ", "zu", null), new KanaChar("で", "デ", "de", null), new KanaChar("ど", "ド", "do", null)},
            {new KanaChar("ば", "バ", "ba", null), new KanaChar("び", "ビ", "bi", null), new KanaChar("ぶ", "ブ", "bu", null), new KanaChar("べ", "ベ", "be", null), new KanaChar("ぼ", "ボ", "bo", null)},
            {new KanaChar("ぱ", "パ", "pa", null), new KanaChar("ぴ", "ピ", "pi", null), new KanaChar("ぷ", "プ", "pu", null), new KanaChar("ぺ", "ペ", "pe", null), new KanaChar("ぽ", "ポ", "po", null)}

        };

        public static KanaChar[,] Youon { get; } =
        {
            {new KanaChar("きゃ", "キャ", "kya", null), new KanaChar("きゅ", "キュ", "kyu", null), new KanaChar("きょ", "キョ", "kyo", null),},
            {new KanaChar("しゃ", "シャ", "sha", null), new KanaChar("しゅ", "シュ", "shu", null), new KanaChar("しょ", "ショ", "sho", null)},
            {new KanaChar("ちゃ", "チャ", "cha", null), new KanaChar("ちゅ", "チュ", "chu", null), new KanaChar("ちょ", "チョ", "cho", null)},
            {new KanaChar("にゃ", "ニャ", "nya", null), new KanaChar("にゅ", "ニュ", "nyu", null), new KanaChar("にょ", "ニョ", "nyo", null)},
            {new KanaChar("ひゃ", "ヒャ", "hya", null), new KanaChar("ひゅ", "ヒュ", "hyu", null), new KanaChar("ひょ", "ヒョ", "hyo", null)},
            {new KanaChar("みゃ", "ミャ", "mya", null), new KanaChar("みゅ", "ミュ", "myu", null), new KanaChar("みょ", "ミョ", "myo", null)},
            {new KanaChar("りゃ", "リャ", "rya", null), new KanaChar("りゅ", "リュ", "ryu", null), new KanaChar("りょ", "リョ", "ryo", null)},
            {new KanaChar("ぎゃ", "ギャ", "gya", null), new KanaChar("ぎゅ", "ギュ", "gyu", null), new KanaChar("ぎょ", "ギョ", "gyo", null)},
            {new KanaChar("じゃ", "ジャ", "ja", null), new KanaChar("じゅ", "ジュ", "ju", null), new KanaChar("じょ", "ジョ", "jo", null)},
            {new KanaChar("びゃ", "ビャ", "bya", null), new KanaChar("びゅ", "ビュ", "byu", null), new KanaChar("びょ", "ビョ", "byo", null)},
            {new KanaChar("ぴゃ", "ピャ", "pya", null), new KanaChar("ぴゅ", "ピュ", "pyu", null), new KanaChar("ぴょ", "ピョ", "pyo", null)}
        };


        public static KanaSquare[] ToKanaSquares(this KanaChar[,] items)
        {
            var lst = new List<KanaSquare>();
            for (var i = 0; i < items.GetLength(0); i++)
            {
                for (var j = 0; j < items.GetLength(1); j++)
                {
                    if(items[i, j] == null)continue;
                    lst.Add(new KanaSquare(items[i, j], i,j));
                }
            }
            return lst.ToArray();
        }
    }
}
