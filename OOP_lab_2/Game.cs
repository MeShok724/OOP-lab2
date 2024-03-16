using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OOP_lab_1
{
    public class Game
    {
        private List<DisplayObject> _objects = new List<DisplayObject>();
        private Timer _timer;
        private PictureBox _pictBox;
        private Graphics _graphics;
        private DrawField _field;
        private int _fieldX1 = 0;
        private int _fieldY1 = 0;
        private int _fieldX2;
        private int _fieldY2;

        public Game(Graphics graphics, int maxX, int maxY)
        {
            _graphics = graphics;
            _fieldX2 = maxX;
            _fieldY2 = maxY;
            _field = new DrawField(0, 0, Color.White, Color.White, 0, maxX, maxY);
            Rectangle rect1 = new Rectangle(100, 100, 5, 5, 0, 5, Color.Red, Color.Black, 2, 50, 50);

            _objects.Add(_field);
            _objects.Add(rect1);

            _timer = new Timer();
            _timer.Interval = 17;
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            _graphics.Clear(Color.White);

            foreach (DisplayObject obj in _objects)
            {
                if (!(obj is DrawField))
                {
                    obj.Move();

                    if (obj.Intersects(_field))
                    {
                        _objects.Remove(obj);
                        _objects.Add(CreateNewObject());
                        break;
                    }
                }
            }

            foreach (DisplayObject obj in _objects)
            {
                obj.Draw(_graphics);
            }
        }
        
        public void PaintObjects(Graphics g)
        {
            foreach (DisplayObject obj in _objects)
            {
                obj.Draw(_graphics);
            }
        }

        private DisplayObject CreateNewObject()
        {
            // Здесь вы можете создать новый объект с произвольными параметрами
            // Например, создание прямоугольника в случайном месте
            Random rand = new Random();
            int x = rand.Next(_fieldX1, _fieldX2); // случайная координата X
            int y = rand.Next(_fieldY1, _fieldY2); // случайная координата Y
            int vX = rand.Next(-5, 5);
            int vY = rand.Next(-5, 5);
            int aX = rand.Next(-5, 5);
            int aY = rand.Next(-5, 5);
            return new Rectangle(x, y, vX, vY, aX, aY, Color.Red, Color.Black, 2, 50, 50);
        }
    }
}