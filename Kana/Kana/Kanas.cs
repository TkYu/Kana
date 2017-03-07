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
            {new KanaChar("さ", "サ", "sa", "[sä]"), new KanaChar("し", "シ", "shi", "[ɕi]"), new KanaChar("す", "ス", "su", "[sɯ̹̈]"), new KanaChar("せ", "セ", "se", "[se̞]"), new KanaChar("そ", "ソ", "so", "[so̞]")},
            {new KanaChar("た", "タ", "ta", "[tä]"), new KanaChar("ち", "チ", "chi", "[t͡ɕi]"), new KanaChar("つ", "ツ", "tsu", "[t͡sɯ̹̈]"), new KanaChar("て", "テ", "te", "[te̞]"), new KanaChar("と", "ト", "to", "[to̞]")},
            {new KanaChar("な", "ナ", "na", "[nä]"), new KanaChar("に", "ニ", "ni", "[nʲi]"), new KanaChar("ぬ", "ヌ", "nu", "[nɯ̹]"), new KanaChar("ね", "ネ", "ne", "[ne̞]"), new KanaChar("の", "ノ", "no", "[no̞]")},
            {new KanaChar("は", "ハ", "ha", "[hä]"), new KanaChar("ひ", "ヒ", "hi", "[çi]"), new KanaChar("ふ", "フ", "fu", "[Φɯ̹]"), new KanaChar("へ", "ヘ", "he", "[he̞]"), new KanaChar("ほ", "ホ", "ho", "[ho̞]")},
            {new KanaChar("ま", "マ", "ma", "[mä]"), new KanaChar("み", "ミ", "mi", "[mʲi]"), new KanaChar("む", "ム", "mu", "[mɯ̹]"), new KanaChar("め", "メ", "me", "[me̞]"), new KanaChar("も", "モ", "mo", "[mo̞]")},
            {new KanaChar("や", "ヤ", "ya", "[jä]"), new KanaChar("い", "イ", "i", "[i]",true), new KanaChar("ゆ", "ユ", "yu", "[jɯ̹]"), new KanaChar("え", "エ", "e", "[e̞]",true), new KanaChar("よ", "ヨ", "yo", "[jo̞]")},
            {new KanaChar("ら", "ラ", "ra", "[ɺä]"), new KanaChar("り", "リ", "ri", "[ɺʲi]"), new KanaChar("る", "ル", "ru", "[ɺɯ̹]"), new KanaChar("れ", "レ", "re", "[ɺe̞]"), new KanaChar("ろ", "ロ", "ro", "[ɺo̞]")},
            {new KanaChar("わ", "ワ", "wa", "[β̞ä]"), new KanaChar("い", "イ", "i", "ゐ ヰ",true), new KanaChar("う", "ウ", "u", "[ɯ̹]",true), new KanaChar("え", "エ", "e", "ゑ ヱ",true), new KanaChar("を", "ヲ", "o", "[o̞]")},
            {new KanaChar("ん", "ン", "n", "[n]"), null, null, null, null}
        };

        public static KanaChar[,] Dakuon { get; } =
        {
            {new KanaChar("が", "ガ", "ga", "[ɡa]"), new KanaChar("ぎ", "ギ", "gi", "[ɡi]"), new KanaChar("ぐ", "グ", "gu", "[ɡu͍]"), new KanaChar("げ", "ゲ", "ge", "[ɡe]"), new KanaChar("ご", "ゴ", "go", "[ɡo]")},
            {new KanaChar("ざ", "ザ", "za", "[za]"), new KanaChar("じ", "ジ", "ji", "[d͡ʑi]"), new KanaChar("ず", "ズ", "zu", "[zu͍]"), new KanaChar("ぜ", "ゼ", "ze", "[ze]"), new KanaChar("ぞ", "ゾ", "zo", "[zo]")},
            {new KanaChar("だ", "ダ", "da", "[da]"), new KanaChar("ぢ", "ヂ", "ji", "[d͡ʑi]"), new KanaChar("づ", "ヅ", "zu", "[zu͍]"), new KanaChar("で", "デ", "de", "[de]"), new KanaChar("ど", "ド", "do", "[do]")},
            {new KanaChar("ば", "バ", "ba", "[ba]"), new KanaChar("び", "ビ", "bi", "[bi]"), new KanaChar("ぶ", "ブ", "bu", "[bu͍]"), new KanaChar("べ", "ベ", "be", "[be]"), new KanaChar("ぼ", "ボ", "bo", "[bo]")},
            {new KanaChar("ぱ", "パ", "pa", "[pa]"), new KanaChar("ぴ", "ピ", "pi", "[pi]"), new KanaChar("ぷ", "プ", "pu", "[pu͍]"), new KanaChar("ぺ", "ペ", "pe", "[pe]"), new KanaChar("ぽ", "ポ", "po", "[po]")}

        };

        public static KanaChar[,] Youon { get; } =
        {
            {new KanaChar("きゃ", "キャ", "kya", "[kʲa]"), new KanaChar("きゅ", "キュ", "kyu", "[kʲu͍]"), new KanaChar("きょ", "キョ", "kyo", "[kʲo]")},
            {new KanaChar("しゃ", "シャ", "sha", "[ɕa]"), new KanaChar("しゅ", "シュ", "shu", "[ɕu͍]"), new KanaChar("しょ", "ショ", "sho", "[ɕo]")},
            {new KanaChar("ちゃ", "チャ", "cha", "[ t͡ɕa]"), new KanaChar("ちゅ", "チュ", "chu", "[ t͡ɕu͍]"), new KanaChar("ちょ", "チョ", "cho", "[ t͡ɕo]")},
            {new KanaChar("にゃ", "ニャ", "nya", "[nʲa]"), new KanaChar("にゅ", "ニュ", "nyu", "[nʲu͍]"), new KanaChar("にょ", "ニョ", "nyo", "[nʲo]")},
            {new KanaChar("ひゃ", "ヒャ", "hya", "[ça]"), new KanaChar("ひゅ", "ヒュ", "hyu", "[çu͍]"), new KanaChar("ひょ", "ヒョ", "hyo", "[ço]")},
            {new KanaChar("みゃ", "ミャ", "mya", "[mʲa]"), new KanaChar("みゅ", "ミュ", "myu", "[mʲu͍]"), new KanaChar("みょ", "ミョ", "myo", "[mʲo]")},
            {new KanaChar("りゃ", "リャ", "rya", "[ɽʲa]"), new KanaChar("りゅ", "リュ", "ryu", "[ɽʲu͍]"), new KanaChar("りょ", "リョ", "ryo", "[ɽʲo]")},
            {new KanaChar("ぎゃ", "ギャ", "gya", "[ɡʲa]"), new KanaChar("ぎゅ", "ギュ", "gyu", "[ɡʲu͍]"), new KanaChar("ぎょ", "ギョ", "gyo", "[ɡʲo]")},
            {new KanaChar("じゃ", "ジャ", "ja", "[d͡ʑa]"), new KanaChar("じゅ", "ジュ", "ju", "[d͡ʑu͍]"), new KanaChar("じょ", "ジョ", "jo", "[d͡ʑo]")},
            {new KanaChar("びゃ", "ビャ", "bya", "[bʲa]"), new KanaChar("びゅ", "ビュ", "byu", "[bʲu͍]"), new KanaChar("びょ", "ビョ", "byo", "[bʲo]")},
            {new KanaChar("ぴゃ", "ピャ", "pya", "[pʲa]"), new KanaChar("ぴゅ", "ピュ", "pyu", "[pʲu͍]"), new KanaChar("ぴょ", "ピョ", "pyo", "[pʲo]")}
        };

        public static string[] Yojijukugo { get; } = {
            //"百戦錬磨","海千山千","三日天下","唯我独尊","一騎当千","臥薪嘗胆","唯一無二","不撓不屈","百花繚乱","因果応報","一期一会","風林火山"
            "因果応報","一期一会","風林火山","海千山千","三日天下","朝三暮四","一刀両断","悪事千里","悪口雑言","異口同音","以心伝心","一意専心","一石二鳥","一挙両得"
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
