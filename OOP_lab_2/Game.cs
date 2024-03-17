using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OOP_lab_1
{
    public class Game
    {
        private List<DisplayObject> _objects = new List<DisplayObject>();
        
        private Bitmap _bitmap;
        private PictureBox _pictureBox;
        
        private Timer _timer;
        private PictureBox _pictBox;
        private Graphics _graphics;
        private DrawField _field;
        private int _fieldX1 = 0;
        private int _fieldY1 = 0;
        private int _fieldX2;
        private int _fieldY2;

        public Game(PictureBox pb, int maxX, int maxY)
        {
            _fieldX2 = maxX;
            _fieldY2 = maxY;
            _bitmap = new Bitmap(maxX, maxY);
            _pictBox = pb;
            _graphics = Graphics.FromImage(_bitmap);
            _field = new DrawField(0, 0, maxX, maxY, Color.White, Color.White, 0);
            
            _objects.Add(_field);
            InitObjects();

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
                        _objects.Add(CreateNewObject(obj));
                        break;
                    }
                }
            }

            foreach (DisplayObject obj in _objects)
            {
                obj.Draw(_graphics);
            }

            _pictBox.Image = _bitmap;
        }

        private DisplayObject CreateNewObject(DisplayObject oldObj)
        {
            
            Random rand = new Random();
            int x = rand.Next(_fieldX1, _fieldX2); // случайная координата X
            int y = rand.Next(_fieldY1, _fieldY2); // случайная координата Y
            int vX = rand.Next(-5, 5);
            int vY = rand.Next(-5, 5);
            int aX = rand.Next(-5, 5);
            int aY = rand.Next(-5, 5);
            
            switch (oldObj)
            {
                case Circle circle: 
                    return new Circle(x, y, rand.Next(5, 50), vX, vY, aX, aY, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),rand.Next(1, 10));
                case Ellipse ellipse:
                    return new Ellipse(x, y, rand.Next(5, 50), rand.Next(5, 50), vX, vY, aX, aY, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),rand.Next(1, 10));
                case EquilateralTriangle equilateralTriangle:
                    return new EquilateralTriangle(x, y, rand.Next(5, 100), vX, vY, aX, aY, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),rand.Next(1, 10));
                case IsoscelesTriangle isoscelesTriangle:
                    return new IsoscelesTriangle(x, y, rand.Next(5, 100), rand.Next(5, 100), vX, vY, aX, aY, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),rand.Next(1, 10));
                case Rectangle rectangle:
                    return new Rectangle(x, y, rand.Next(5, 100), rand.Next(5, 100), vX, vY, aX, aY, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),rand.Next(1, 10));
                case Section section:
                    int x2 = rand.Next(_fieldX1, _fieldX2);
                    int y2 = rand.Next(_fieldY1, _fieldY2);
                    return new Section(x, y, x2, y2, rand.Next(5, 10), vX, vY, aX, aY, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),rand.Next(1, 5));
                case Square square:
                    return new Square(x, y, rand.Next(5, 100), vX, vY, aX, aY, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),
                        Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),rand.Next(1, 10));
                case Triangle triangle:
                    int pMinX = x - 100;
                    int pMaxX = x + 100;
                    int pMinY = y - 100;
                    int pMaxY = y + 100;
                    return  new Triangle(x, y, rand.Next(pMinX, pMaxX), rand.Next(pMinY, pMaxY), rand.Next(pMinX, pMaxX), rand.Next(pMinY, pMaxY), vX, vY, aX, aY, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),rand.Next(1, 10));
            }
            return new Rectangle(x, y, rand.Next(5, 100), rand.Next(5, 100), vX, vY, aX, aY, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),rand.Next(1, 10));;
        }

        private void InitObjects()
        {
            for (int i = 0; i < 10; i++)
            {
                Random rand = new Random();
                int x = rand.Next(_fieldX1, _fieldX2); 
                int y = rand.Next(_fieldY1, _fieldY2); 
                int vX = rand.Next(-5, 5);
                int vY = rand.Next(-5, 5);
                int aX = rand.Next(-5, 5);
                int aY = rand.Next(-5, 5);
                _objects.Add(new Circle(x, y, rand.Next(5, 50), vX, vY, aX, aY, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),rand.Next(1, 10)));
            }
            for (int i = 0; i < 10; i++)
            {
                Random rand = new Random();
                int x = rand.Next(_fieldX1, _fieldX2); 
                int y = rand.Next(_fieldY1, _fieldY2); 
                int vX = rand.Next(-5, 5);
                int vY = rand.Next(-5, 5);
                int aX = rand.Next(-5, 5);
                int aY = rand.Next(-5, 5);
                _objects.Add(new Ellipse(x, y, rand.Next(5, 50), rand.Next(5, 50), vX, vY, aX, aY, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),rand.Next(1, 10)));
            }
            for (int i = 0; i < 10; i++)
            {
                Random rand = new Random();
                int x = rand.Next(_fieldX1, _fieldX2); 
                int y = rand.Next(_fieldY1, _fieldY2); 
                int vX = rand.Next(-5, 5);
                int vY = rand.Next(-5, 5);
                int aX = rand.Next(-5, 5);
                int aY = rand.Next(-5, 5);
                _objects.Add(new EquilateralTriangle(x, y, rand.Next(5, 100), vX, vY, aX, aY, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),rand.Next(1, 10)));
            }
            for (int i = 0; i < 10; i++)
            {
                Random rand = new Random();
                int x = rand.Next(_fieldX1, _fieldX2); 
                int y = rand.Next(_fieldY1, _fieldY2); 
                int vX = rand.Next(-5, 5);
                int vY = rand.Next(-5, 5);
                int aX = rand.Next(-5, 5);
                int aY = rand.Next(-5, 5);
                _objects.Add(new Rectangle(x, y, rand.Next(5, 100), rand.Next(5, 100), vX, vY, aX, aY, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),rand.Next(1, 10)));
            }
            for (int i = 0; i < 10; i++)
            {
                Random rand = new Random();
                int x = rand.Next(_fieldX1, _fieldX2); 
                int y = rand.Next(_fieldY1, _fieldY2); 
                int vX = rand.Next(-5, 5);
                int vY = rand.Next(-5, 5);
                int aX = rand.Next(-5, 5);
                int aY = rand.Next(-5, 5);
                int x2 = rand.Next(_fieldX1, _fieldX2);
                int y2 = rand.Next(_fieldY1, _fieldY2);
                _objects.Add(new Section(x, y, x2, y2, rand.Next(1, 10), vX, vY, aX, aY, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),rand.Next(1, 5)));
            }
            for (int i = 0; i < 10; i++)
            {
                Random rand = new Random();
                int x = rand.Next(_fieldX1, _fieldX2); 
                int y = rand.Next(_fieldY1, _fieldY2); 
                int vX = rand.Next(-5, 5);
                int vY = rand.Next(-5, 5);
                int aX = rand.Next(-5, 5);
                int aY = rand.Next(-5, 5);
                _objects.Add(new Square(x, y, rand.Next(5, 100), vX, vY, aX, aY, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),rand.Next(1, 10)));
            }
            for (int i = 0; i < 10; i++)
            {
                Random rand = new Random();
                int x = rand.Next(_fieldX1, _fieldX2); 
                int y = rand.Next(_fieldY1, _fieldY2); 
                int vX = rand.Next(-5, 5);
                int vY = rand.Next(-5, 5);
                int aX = rand.Next(-5, 5);
                int aY = rand.Next(-5, 5);
                int pMinX = x - 100;
                int pMaxX = x + 100;
                int pMinY = y - 100;
                int pMaxY = y + 100;
                _objects.Add(new Triangle(x, y, rand.Next(pMinX, pMaxX), rand.Next(pMinY, pMaxY), rand.Next(pMinX, pMaxX), rand.Next(pMinY, pMaxY), vX, vY, aX, aY, Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)), Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255)),rand.Next(1, 10)));
            }
        }
    }
}