using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    /// <summary>
    /// Базовый объект
    /// </summary>
    abstract class BaseObject: ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        protected Image img;

        public delegate void Message();

        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        /// <summary>
        /// форма базового объекта
        /// </summary>
        public abstract void Draw();

        /// <summary>
        /// начальное поведение объектов
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// Метод вставки картинки из файла
        /// </summary>
        /// <param name="fileName"></param>
        protected void LoadImage(string fileName)
        {
            img = Image.FromFile(fileName);
        }

        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect); //обнаружение пересечения объектов
        public Rectangle Rect => new Rectangle(Pos, Size);
    }
}
