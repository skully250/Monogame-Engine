using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace FaeForest.Utility
{
    class MathUtility
    {
        public static float PixelPercentage(int startpx, int finishpx)
        {
            double scaled = (100 * finishpx) / startpx;
            return (float)scaled / 100;
        }
    }
}