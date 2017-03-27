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
    }

    public interface IMainformPresenter
    {
        PictureBox PictureBox { get; }
        string ResultText { get; set; }

    }
}
