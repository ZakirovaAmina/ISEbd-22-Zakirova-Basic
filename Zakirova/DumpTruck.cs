using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Zakirova
{
    /// <summary>
    /// Класс отрисовки самовсвала
    /// </summary>
    class DumpTruck
	{
        /// <summary>
        /// Левая координата отрисовки самосвала
        /// </summary>
        private float _startPosX;
        /// <summary>
        /// Правая кооридната отрисовки самосвала
        /// </summary>
        private float _startPosY;
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private int _pictureWidth = 100;
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private int _pictureHeight = 100;

        /// <summary>
        /// Ширина отрисовки самосвала
        /// </summary>
        private readonly int truckWidth = 100;
        /// <summary>
        /// Высота отрисовки самосвала
        /// </summary>
        private readonly int truckHeight = 60;
        /// <summary>
        /// Максимальная скорость
        /// </summary>
        public int MaxSpeed { private set; get; }
        /// <summary>
        /// Вес самосвала
        /// </summary>
        public float Weight { private set; get; }
        /// <summary>
        /// Основной цвет кузова
        /// </summary>
        public Color MainColor { private set; get; }
        /// <summary>
        /// Дополнительный цвет
        /// </summary>
        public Color DopColor { private set; get; }
        /// <summary>
        /// Признак наличия трубы
        /// </summary>
        public bool Duct { private set; get; }
        /// <summary>
        /// Признак наличия кузова
        /// </summary>
        public bool Carcase { private set; get; }
        /// <summary>
        /// Признак наличия передней фары
        /// </summary>
        public bool FrontLight { private set; get; }
        /// <summary>
        /// Признак наличия задней фары
        /// </summary>
        public bool BackLight { private set; get; }
        /// <summary>
        /// Инициализация свойств
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес самосвала</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        /// <param name="dopColor">Дополнительный цвет</param>
        /// <param name="duct">Признак наличия трубы</param>
        /// <param name="carcase">Признак наличия кузова</param>
        /// <param name="frontLight">Признак наличия передней фары</param>
        /// <param name="backLight">Признак наличия задней фары</param>
        public void Init(int maxSpeed, float weight, Color mainColor, Color dopColor,
       bool duct, bool carcase, bool frontLight, bool backLight)
        {
            MaxSpeed = maxSpeed;
            
        Weight = weight;
            MainColor = mainColor;
            DopColor = dopColor;
            Duct = duct;
            Carcase = carcase;
            FrontLight = frontLight;
            BackLight = backLight;
        }
        /// <summary>
        /// Установка позиции автомобиля
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="width">Ширина картинки</param>
        /// <param name="height">Высота картинки</param>
        public void SetPosition(int x, int y, int width, int height)
        {           
            _startPosX = x;
            _startPosY = y;
            _pictureHeight = height;
            _pictureWidth = width;
        }
        /// <summary>
        /// Изменение направления пермещения
        /// </summary>
        /// <param name="direction">Направление</param>
        public void MoveTransport(Direction direction)
        {
            int scale = 63;
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                // вправо
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - truckWidth - scale) { _startPosX += step;}                    
                    break;

                //влево
                case Direction.Left:                 
                    if (_startPosX - step > scale) { _startPosX -= step; }                    
                    break;

                //вверх
                case Direction.Up:                    
                    if(_startPosY - step > scale) { _startPosY -= step; }                   
                    break;

                //вниз
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - truckHeight) { _startPosY += step; }                    
                    break;
            }
        }
        /// <summary>
        /// Отрисовка самосвала
        /// </summary>
        /// <param name="g"></param>
        public void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Pen wheel = new Pen(Color.LightBlue);
            Pen fog1 = new Pen(Color.Gray);
            Pen back1 = new Pen(Color.LightGray);
            Pen light1 = new Pen(Color.Yellow);
            Brush fond = new SolidBrush(Color.Black);
            Brush light = new SolidBrush(Color.Yellow);
            Brush wheels = new SolidBrush(Color.LightBlue);
            Brush fog = new SolidBrush(Color.Gray);
            Brush back = new SolidBrush(Color.LightGray);

            g.DrawRectangle(pen, _startPosX, _startPosY, 100, 25);
            g.DrawRectangle(pen, _startPosX + 60, _startPosY - 40, 40, 37);
            g.DrawRectangle(pen, _startPosX + 65, _startPosY - 35, 20, 16);

            g.FillRectangle(fond, _startPosX, _startPosY, 100, 25);
            g.FillRectangle(fond, _startPosX + 60, _startPosY - 40, 40, 37);

            g.DrawEllipse(wheel, _startPosX + 75, _startPosY + 24, 20, 20);
            g.DrawEllipse(wheel, _startPosX + 20, _startPosY + 24, 20, 20);
            g.DrawEllipse(wheel, _startPosX, _startPosY + 24, 20, 20);

            g.FillEllipse(wheels, _startPosX + 75, _startPosY + 24, 20, 20);
            g.FillEllipse(wheels, _startPosX + 20, _startPosY + 24, 20, 20);
            g.FillEllipse(wheels, _startPosX, _startPosY + 24, 20, 20);

            if (FrontLight)
            {
                g.DrawEllipse(light1, _startPosX + 100, _startPosY, 65, 20);
                g.FillEllipse(light, _startPosX + 100, _startPosY, 65, 20);
            }
            if (BackLight)
            {
                g.DrawEllipse(light1, _startPosX - 65, _startPosY + 5, 65, 20);
                g.FillEllipse(light, _startPosX - 65, _startPosY + 5, 65, 20);
            }
            if (Duct)
            {
                g.DrawRectangle(fog1, _startPosX + 90, _startPosY - 57, 10, 16);
                g.FillRectangle(fog, _startPosX + 90, _startPosY - 57, 10, 16);
            }
            if (Carcase)
            {
                g.DrawRectangle(back1, _startPosX, _startPosY - 30, 60, 40);
                g.FillRectangle(back, _startPosX, _startPosY - 30, 60, 40);
            }
            
        }

    }

}
