using System;
using System.Drawing;
using System.Windows.Forms;

namespace OOP_lab_1
{
    public partial class FormMain : Form
    {
        public Graphics g;
        public Game game;
        
        public FormMain()
        {
            InitializeComponent();
        }
        

        private void pbDrawField_Click(object sender, EventArgs e)
        {
            if (game == null)
            {
                g = pbDrawField.CreateGraphics();
                g.Clear(Color.White);
                game = new Game(g, pbDrawField.Width, pbDrawField.Height);   
            }
        }
    }
}