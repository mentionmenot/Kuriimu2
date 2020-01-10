﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontract.Kanvas.Quantization
{
    public interface IQuantizer
    {
        (IEnumerable<int>, IList<Color>) Process(IEnumerable<Color> colors);

        Image ProcessImage(Bitmap image);
    }
}
