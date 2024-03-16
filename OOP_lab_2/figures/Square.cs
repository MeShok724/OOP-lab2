using System.Drawing;

namespace OOP_lab_1
{
    public class Square : DisplayObject
    {
        private int _X2;
        private int _Y2;
        override public void Draw(Graphics g)
        {
            using (var pen = new Pen(_borderColor, _borderSize*2))
            {
                using (var brush = new SolidBrush(_fillColor))
                {
                    g.FillRectangle(brush, _X1, _Y1, _X2 - _X1, _Y2 - _Y1);
                    g.DrawRectangle(pen, _X1, _Y1, _X2 - _X1, _Y2 - _Y1);
                }
            }
        }
        
        public Square(int x1, int y1, int vX, int vY, int aX, int aY, Color fillColor, Color borderColor, int borderSize, int side) : base(x1, y1, vX, vY, aX, aY, fillColor, borderColor, borderSize)
        {
            _X2 = _X1 + side;
            _Y2 = _Y1 + side;
            _rectX1 = _X1 - borderSize / 2;
            _rectY1 = _Y1 - borderSize / 2;
            _rectX2 = _X2 + borderSize / 2;
            _rectY2 = _Y2 + borderSize / 2;
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