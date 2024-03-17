using System;
using System.Drawing;

namespace OOP_lab_1
{
    public class Section : DisplayObject
    {
        private int _diffX;
        private int _diffY;
        private readonly int _width;

        override public void Draw(Graphics g)
        {
            using (var pen = new Pen(_borderColor, _borderSize + _width))
            {
                using (var penFill = new Pen(_fillColor, _width - _borderSize))
                {
                    g.DrawLine(pen, _X1, _Y1, _X2, _Y2);
                    g.DrawLine(penFill,_X1 + _diffX, _Y1 + _diffY, _X2 - _diffX, _Y2 - _diffY);
                }
            }
        }

        private void FindDiff()
        {
            double dist = Math.Sqrt(Math.Pow(_X2 - _X1, 2) + Math.Pow(_Y2 - _Y1, 2));
            double k = Math.Round(dist / _borderSize);
            _diffX = (int)Math.Round((_X2 - _X1) / k);
            _diffY = (int)Math.Round((_Y2 - _Y1) / k);
            
            //?
            _diffX = Math.Abs(_diffX);
            _diffY = Math.Abs(_diffY);
            if (_X2 - _X1 < 0)
            {
                _diffX = -_diffX;
            } 
            if (_Y2 - _Y1 < 0)
            {
                _diffY = -_diffY;
            }
        }
        
        public Section(int x1, int y1, int x2, int y2, int width, int vX, int vY, int aX, int aY, Color fillColor, Color borderColor, int borderSize) : base(x1, y1, vX, vY, aX, aY, fillColor, borderColor, borderSize)
        {
            _X2 = x2;
            _Y2 = y2;
            _rectX1 = Math.Min(_X1, _X2) - borderSize / 2;
            _rectY1 = Math.Min(_Y1, _Y2) - borderSize / 2;
            _rectX2 = Math.Max(_X1, _X2) + borderSize / 2;
            _rectY2 = Math.Max(_Y1, _Y2) + borderSize / 2;
            _width = width;
            FindDiff();
        }
        protected override void MoveOn(int dX, int dY)
        {
            _X1 += dX;
            _X2 += dX;
            _Y1 += dY;
            _Y2 += dY;
        }
    }
}