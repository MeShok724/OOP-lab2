using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace OOP_lab_1
{
    public class DrawField : DisplayObject
    {
        public override void Draw(Graphics g)
        {
            using (var brush = new SolidBrush(_fillColor))
            {
                using (var pen = new Pen(_borderColor, _borderSize))
                {
                    g.FillRectangle(brush, _X1, _Y1, _X2 - _X1, _Y2 - _Y1);
                    if (_borderSize != 0)
                        g.DrawRectangle(pen, _X1, _Y1, _X2 - _X1, _Y2 - _Y1);
                }
            }
        }
        public DrawField(int X1, int Y1, int width, int heigth, Color fillColor, Color borderColor, int borderSize) : base(X1, Y1, 0, 0, 0, 0, fillColor, borderColor, borderSize)
        {
            _X2 = X1 + width;
            _Y2 = Y1 + heigth;
            _rectX1 = _X1 - borderSize / 2;
            _rectY1 = _Y1 - borderSize / 2;
            _rectX2 = _X2 + borderSize / 2;
            _rectY2 = _Y2 + borderSize / 2;
        }
        public (int, int, int, int) GetCords()
        {
            return (_X1, _Y1, _X2, _Y2);
        }

        protected override void MoveOn(int dX, int dY) { }
    }
}