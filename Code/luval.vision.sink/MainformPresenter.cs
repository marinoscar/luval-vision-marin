using luval.vision.core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace luval.vision.sink
{
    public class MainformPresenter
    {

        public MainformPresenter(IMainformPresenter presenter)
        {
            Presenter = presenter;
        }

        public IMainformPresenter Presenter { get; private set; }

        public void DoLoadImage(string fileName)
        {
            if (Presenter.PictureBox.Image != null) Presenter.PictureBox.Image.Dispose();
            Presenter.PictureBox.Image = null;
            var img = default(Image);
            using (var stream = new StreamReader(fileName))
            {
                img = Image.FromStream(stream.BaseStream);
                stream.Close();
            }
            Presenter.PictureBox.Image = img;
            Presenter.PictureBox.Refresh();
        }

        public OcrResult ProcessFromFile(string fileName)
        {
            var provider = new OcrProvider(new MicrosoftOcrEngine(), new MicrosoftVisionLoader());
            var result = provider.DoOcr(fileName);
            ProcessImage(result);
            return result;
        }

        public void ProcessImage(OcrResult ocrResult)
        {
            var bmp = new ImageManager().Process(ocrResult, Presenter.PictureBox.Image);
            Presenter.PictureBox.Image = bmp;
        }

        public void ProcessImage(OcrResult ocrResult, IEnumerable<LineItem> lines)
        {
            var imgManager = new ImageManager();
            var bmp = imgManager.Process(ocrResult, Presenter.PictureBox.Image);
            if (lines != null && lines.Any())
                bmp = imgManager.ProcessLines(lines, bmp);
            Presenter.PictureBox.Image = bmp;

        }

        public void DoFullProcess(OcrResult ocrResult)
        {
            var provider = new OcrProvider(new MicrosoftOcrEngine(), new MicrosoftVisionLoader());
            var imgManager = new ImageManager();
            var bmp = imgManager.Process(ocrResult, Presenter.PictureBox.Image);
            Presenter.PictureBox.Image = bmp;
            Presenter.ResultText = ocrResult.ToString();
        }
    }

    public interface IMainformPresenter
    {
        PictureBox PictureBox { get; }
        PropertyGrid PropertyGrid { get; }
        string ResultText { get; set; }

    }
}
