﻿using System;
using System.Drawing;

namespace MyGame
{
    abstract class BaseObject: ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }
        public abstract void Draw();

        public abstract void Update();
        
        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect); //обнаружение пересечения объектов
        public Rectangle Rect => new Rectangle(Pos, Size);

        public delegate void Message();
    }
}
