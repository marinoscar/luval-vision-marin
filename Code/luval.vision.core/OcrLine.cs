using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class OcrLine : OcrElement
    {

        private string _text;
        public OcrLine()
        {
            Words = new List<OcrWord>();
            Phrases = new List<OcrPhrase>();
            ParentRegion = new OcrRegion();
            Entities = new List<OcrEntity>();
        }

        public OcrRegion ParentRegion { get; set; }
        public List<OcrWord> Words { get; set; }
        public List<OcrPhrase> Phrases { get; set; }

        public List<OcrEntity> Entities { get; set; }

        public override string Text
        {
            get
            {
                if (Words != null && Words.Any())
                {
                    _text = string.Join(" ", Words.Select(i => i.Text));
                    return _text;
                }
                else
                    return _text;
            }
            set
            {
                _text = value;
            }
        }

        public void LoadPhrases()
        {
            var prevWord = default(OcrWord);
            var words = new List<OcrWord>();
            foreach (var word in Words)
            {
                if (prevWord == null)
                {
                    prevWord = word; words.Add(word); continue;
                }
                else
                    words.Add(word);

                var spacing = word.Location.X - prevWord.Location.XBound;
                if (spacing > (word.GetCharSpacing() * 5))
                {
                    AddPhrase(words);
                    words.Clear();
                }
                prevWord = word;
            }
            if(words.Any()) AddPhrase(words);
        }

        private void AddPhrase(List<OcrWord> words)
        {
            var loc = OcrLoaderHelper.GetLocationFromElements(words);
            var phrase = new OcrPhrase()
            {
                ParentLine = this,
                Code = Code,
                Id = Phrases.Count + 1,
                Location = OcrLoaderHelper.GetLocationFromElements(words),
                Text = string.Join(" ", words.Select(i => i.Text)),
                Words = words
            };
            Phrases.Add(phrase);
        }


    }
}
