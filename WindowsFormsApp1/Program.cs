using System;
using System.Windows.Forms;

namespace MyGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();
            {
                var Width = Screen.PrimaryScreen.Bounds.Width;
                var Height = Screen.PrimaryScreen.Bounds.Height;
            }
            Game.Init(form);
            form.Show();
            Game.Load();
            Game.Draw();
            Application.Run(form);
        }
    }
}
