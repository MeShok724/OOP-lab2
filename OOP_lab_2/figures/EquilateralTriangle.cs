using System;
using System.Drawing;

namespace OOP_lab_1
{
    public class EquilateralTriangle : DisplayObject
    {
        private int _X3;
        private int _Y3;
        override public void Draw(Graphics g)
        {
            using (var pen = new Pen(_borderColor, _borderSize))
            {
                using (var brush = new SolidBrush(_fillColor))
                {
                    g.FillPolygon(brush,new []{ new Point(_X1, _Y1), new Point(_X2, _Y2), new Point(_X3, _Y3) });
                    g.DrawPolygon(pen, new []{ new Point(_X1, _Y1), new Point(_X2, _Y2), new Point(_X3, _Y3) });
                }
            }
        }
        
        public EquilateralTriangle(int x1, int y1, int side, int vX, int vY, int aX, int aY, Color fillColor, Color borderColor, int borderSize) : base(x1, y1, vX, vY, aX, aY, fillColor, borderColor, borderSize)
        { 
            int height = (int)Math.Round(side * Math.Sqrt(3) / 2);
            _rectX1 = _X1 - side / 2 - borderSize / 2;
            _rectY1 = _Y1 - borderSize / 2;
            _rectX2 = _X1 + side / 2 + borderSize / 2;
            _rectY2 = _Y1 + height + borderSize / 2;
            _X2 = _X1 - side / 2;
            _X3 = _X1 + side / 2;
            _Y2 = _Y1 + height;
            _Y3 = _Y2;
        }
        
        protected override void MoveOn(int dX, int dY)
        {
            _X1 += dX;
            _X2 += dX;
            _X3 += dX;
            _Y1 += dY;
            _Y2 += dY;
            _Y3 += dY;
        }
    }
}