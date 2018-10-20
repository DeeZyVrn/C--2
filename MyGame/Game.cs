using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MyGame
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        //свойства
        //ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }

        private static Ship _ship = new Ship(new Point(10, 400), new Point(5, 5), new Size(10, 10));

        private static Timer _timer = new Timer();
        public static Random Rnd = new Random();

        static Game()
        {

        }
        /// <summary>
        /// Метод инициализации формы для приложения
        /// </summary>
        /// <param name="form"></param>
        public static void Init(Form form)
        {
            //графическое утройство для вывода графики
            Graphics g;
            //представляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            //создаем объект (поверхность рисования) и связываем его с формой
            //запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            if (Width > 1000 || Height > 1000)
            {
                throw new ArgumentOutOfRangeException();
            }

            //связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();

            form.KeyDown += Form_KeyDown;

            //добавляем таймер
            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
            Ship.MessageDie += Finish;
        }

        /// <summary>
        /// обработчик таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        /// <summary>
        /// Метод вывода графики в приложении
        /// </summary>
        public static void Draw()
        {

            //вывод всех объектов на экран
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            foreach (Asteroid a in _asteroids)
            {
                a?.Draw();
            }

            _bullet?.Draw();
            _ship?.Draw();
            if (_ship != null)
                Buffer.Graphics.DrawString("Energy:" + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
            Buffer.Render();

        }

        /// <summary>
        /// Метод изменения состояния объектов
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
            _bullet?.Update();

            for (var i = 0; i < _asteroids.Length; i++)
            {
                if (_asteroids[i] == null) continue;
                _asteroids[i].Update();
                if (_bullet != null && _bullet.Collision(_asteroids[i]))
                {
                    System.Media.SystemSounds.Hand.Play();
                    _asteroids[i] = null;
                    _bullet = null;
                    continue;
                }
                if (!_ship.Collision(_asteroids[i])) continue;
                var rnd = new Random();
                _ship?.EnergyLow(rnd.Next(1, 10));
                System.Media.SystemSounds.Asterisk.Play();
                if (_ship.Energy <= 0) _ship?.Die();
            }
        }

        public static BaseObject[] _objs;
        private static Bullet _bullet;
        private static Asteroid[] _asteroids;

        /// <summary>
        /// Метод инициализации объектов
        /// </summary>
        public static void Load()
        {
            _objs = new BaseObject[30];
            _bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1));
            _asteroids = new Asteroid[10];
            var rnd = new Random();

            for (var i = 0; i < _objs.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _objs[i] = new Star(new Point(1000, rnd.Next(0, Game.Height)), new Point(-r, r), new Size(3, 3));
            }
            for (var i = 0; i < _asteroids.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _asteroids[i] = new Asteroid(new Point(1000, rnd.Next(0, Game.Height)), new Point(-r / 5, r), new Size(r, r));
            }
        }

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) _bullet = new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 4),
                new Point(4, 0), new Size(4, 1));
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
        }

        public static void Finish()
        {
            _timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }
    }
}
