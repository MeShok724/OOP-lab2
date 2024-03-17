using System.Drawing;

namespace OOP_lab_1
{
    public class Ellipse : DisplayObject
    {
        override public void Draw(Graphics g)
        {
            using (var pen = new Pen(_borderColor, _borderSize))
            {
                using (var brush = new SolidBrush(_fillColor))
                {
                    g.FillEllipse(brush, _X1, _Y1, _X2 - _X1, _Y2 - _Y1);
                    g.DrawEllipse(pen, _X1, _Y1, _X2 - _X1, _Y2 - _Y1);
                }
            }
        }
        
        public Ellipse(int x1, int y1, int rx, int ry, int vX, int vY, int aX, int aY, Color fillColor, Color borderColor, int borderSize) : base(x1, y1, vX, vY, aX, aY, fillColor, borderColor, borderSize)
        {
            _X2 = x1 + 2 * rx;
            _Y2 = y1 + 2 * ry;
            _rectX1 = _X1 - borderSize / 2;
            _rectY1 = _Y1 - borderSize / 2;
            _rectX2 = _X1 + 2 * rx + borderSize / 2;
            _rectY2 = _Y1 + 2 * ry + borderSize / 2;
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