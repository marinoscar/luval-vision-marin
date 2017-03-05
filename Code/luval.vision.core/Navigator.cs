using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class Navigator
    {

        private const double ErrorMargin = 0.05d;

        public Navigator(IEnumerable<OcrWord> words)
        {
            Words = new List<OcrWord>(words);
        }
        public List<OcrWord> Words { get; set; }

        public IEnumerable<OcrWord> FindByText(string text)
        {
            return Words.Where(i => i.Text == text);
        }

        public IEnumerable<OcrWord> FindNeighbors(OcrWord word, Direction direction)
        {
            var searchArea = GetBasedOnDirection(word.Location, direction);
            switch (direction)
            {
                case Direction.Top:
                    return SearchDown(word, searchArea);
                case Direction.Down:
                    return SearchDown(word, searchArea);
                case Direction.Left:
                    return SearchDown(word, searchArea);
                case Direction.Right:
                    return SearchDown(word, searchArea);
                default:
                    return new OcrWord[] { };
            }
        }

        private IEnumerable<OcrWord> SearchDown(OcrWord reference, OcrLocation searchArea)
        {
            return Words.Where(i => i != reference && i.Location.X >= searchArea.X && (i.Location.X < (searchArea.X + searchArea.Width)))
                .OrderBy(i => i.Location.Y).ToList();
        }

        private OcrLocation GetBasedOnDirection(OcrLocation original, Direction direction)
        {
            var result = new OcrLocation() { X = original.X, Y = original.Y, Width = original.Width, Height = original.Height };
            switch (direction)
            {
                case Direction.Top:
                    result.X = original.X - (int)Math.Floor((original.X * ErrorMargin));
                    result.Width = original.Width + (int)Math.Ceiling((original.Width * ErrorMargin));
                    break;
                case Direction.Down:
                    result.X = original.X - (int)Math.Floor((original.X * ErrorMargin));
                    result.Width = original.Width + (int)Math.Ceiling((original.Width * ErrorMargin));
                    break;
                case Direction.Left:
                    result.Y = original.Y - (int)Math.Floor((original.Y * ErrorMargin));
                    result.Height = original.Height + (int)Math.Ceiling((original.Height * ErrorMargin));
                    break;
                case Direction.Right:
                    result.Y = original.Y - (int)Math.Floor((original.Y * ErrorMargin));
                    result.Height = original.Height + (int)Math.Ceiling((original.Height * ErrorMargin));
                    break;
            }
            return result;
        }
    }
}
