using System;
using System.Drawing;
using System.Windows.Forms;

namespace OOP_lab_1
{
    public partial class FormMain : Form
    {
        public Game game;
        
        public FormMain()
        {
            InitializeComponent();
        }
        

        private void pbDrawField_Click(object sender, EventArgs e)
        {
            if (game == null)
            {
                game = new Game(pbDrawField, pbDrawField.Width, pbDrawField.Height);   
            }
        }
    }
}