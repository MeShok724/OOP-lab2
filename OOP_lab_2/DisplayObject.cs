using System.Drawing;

namespace OOP_lab_1
{
    public abstract class DisplayObject
    {
        protected int _X1;
        protected int _Y1;
        protected int _vX;
        protected int _vY;
        protected int _aX;
        protected int _aY;
        protected int _rectX1;
        protected int _rectY1;
        protected int _rectX2;
        protected int _rectY2;
        protected readonly Color _fillColor;
        protected readonly Color _borderColor;
        protected readonly int _borderSize;
        public abstract void Draw(Graphics g);
        protected abstract void MoveOn(int dX, int dY);
        protected DisplayObject(int x1, int y1, int vX, int vY, int aX, int aY, Color fillColor, Color borderColor, int borderSize)
        {
            _X1 = x1;
            _Y1 = y1;
            _vX = vX;
            _vY = vY;
            _aX = aX;
            _aY = aY;
            _fillColor = fillColor;
            _borderColor = borderColor;
            _borderSize = borderSize;
        }

        public void Move()
        {
            if (_aX == 0 && _aY == 0)
            {
                MoveOn(_vX, _vY);
            }
            else
            {
                MoveOn(_vX + _aX/2, _vY + _aY/2);
                _vX += _aX;
                _vY += _aY;
            }
        }
        public bool Intersects(DrawField obj)
        {
            var cords = obj.GetCords();
            return !(_X1 >= cords.Item1 && _X1 <= cords.Item3 && _Y1 >= cords.Item2 && _Y1 <= cords.Item4);
        }
    }
}