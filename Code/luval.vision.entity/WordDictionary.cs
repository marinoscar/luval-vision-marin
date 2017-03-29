using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.entity
{
    public class WordDictionary
    {
        public WordDictionary()
        {
            Words = new List<Word>();
            Load();
        }

        private static WordDictionary _i;

        public static WordDictionary I
        {
            get
            {
                if (_i == null) _i = new WordDictionary();
                return _i;
            }
        }

        public List<Word> Words { get; private set; }

        public bool IsInDictionary(Language lang, string word)
        {
            return Words.Any(i => i.Language == lang && i.Text.ToLowerInvariant().Equals(word.ToLowerInvariant()));
        }

        private void Load()
        {
            using (var stream = new StreamReader(@"Resources\en-words.txt"))
            {
                while (!stream.EndOfStream)
                {
                    Words.Add(new Word()
                    {
                        Text = stream.ReadLine().ToLowerInvariant(),
                        Language = Language.English
                    });
                }
                stream.Close();
            }
        }
    }

    public class Word
    {
        public Language Language { get; set; }
        public string Text { get; set; }
    }
}
