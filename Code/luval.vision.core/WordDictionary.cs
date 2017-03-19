using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class WordDictionary
    {
        public WordDictionary()
        {
            Words = new List<Word>();
            Load();
        }

        public List<Word> Words { get; private set; }

        private void Load()
        {
            using (var stream = new StreamReader(@"\Resources\en-words.txt"))
            {
                while (!stream.EndOfStream)
                {
                    Words.Add(new Word()
                    {
                        Text = stream.ReadLine().ToLowerInvariant(),
                        Language = "en"
                    });
                }
                stream.Close();
            }
        }
    }

    public class Word
    {
        public string Language { get; set; }
        public string Text { get; set; }
    }
}
