using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public abstract class ColoredFigure
    {
        protected string color;
        protected double size;

        public ColoredFigure(string color, double size)
        {
            this.color = color;
            this.size = size;
        }

        public void Show()
        {
            Console.WriteLine($"Color: {color}, Size: {size}");
        }

        public abstract string GetName();
        public abstract double GetArea();
    }


}
