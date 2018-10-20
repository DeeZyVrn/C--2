using System.Drawing;

namespace MyGame
{
    class Star2: BaseObject
    {
        public Star2(Point pos, Point dir, Size size):base(pos,dir,size)
        {

        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.Y < 600) Pos.Y = Game.Height + Size.Height;
        }
    }
}
