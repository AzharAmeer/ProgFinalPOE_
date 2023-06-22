using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prog7312_task1
{
    //------------------------------ START OF CODE --------------------------------------------------------------------------------------------------------------//
    //------------------------------ REFERENCE: https://laptrinhvb.net/bai-viet/chuyen-de-csharp/---csharp----chia-se-source-code-firework-effect-trong-winform/5481a0c82f1b246a.html ---//

    public class firework
    {
        const int MaxRays = 10;
        double start;
        double stop;
        double len;
        double curpos;
        SolidBrush brush;
        int nrays;
        int cx;
        int cy;
        double[] sintab;
        double[] costab;
        double descent;
        static Random rand = new Random();
        const double Step = 0.5;

        public bool Update()
        {
            curpos += Step;
            return curpos <= stop + len;
        }


        public void Paint(Graphics g)
        {
            double lower = Math.Max(curpos - len, start);
            double upper = Math.Min(curpos, stop);

            for (double pos = lower; pos < upper; pos += Step)
            {
                double quad = descent * pos;
                double quadsq = quad * quad;

                for (int i = 0; i < nrays; ++i)
                    g.FillRectangle(brush,
                            (int)(cx + pos * costab[i]),
                            (int)(cy + pos * sintab[i] + quadsq),
                            1, 1);
            }
        }
        public firework(int xsize, int ysize)
        {
            cx = rand.Next(xsize);
            cy = rand.Next(ysize);
            descent = rand.NextDouble() * 0.1 + 0.05;

            start = rand.NextDouble() * 10 + 5;
            stop = rand.NextDouble() * 50 + 50;
            len = rand.NextDouble() * 50 + 25;

            curpos = start;

            brush = new SolidBrush(Color.FromArgb(rand.Next(128, 256),
                                  rand.Next(128, 256),
                                  rand.Next(128, 256)));

            nrays = rand.Next(5, MaxRays + 1);

            double angleInc = 2 * Math.PI / nrays;
            double angle = rand.NextDouble() * angleInc;

            costab = new double[nrays];
            sintab = new double[nrays];
            for (int i = 0; i < nrays; ++i, angle += angleInc)
            {
                costab[i] = Math.Cos(angle);
                sintab[i] = Math.Sin(angle);
            }
        }
    }
    //------------------------------ END OF CODE ----------------------------------------------------------------------------------------------------------------//

}
