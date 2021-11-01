using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Zakirova
{
	public class Truck : Vehicle
	{
       
        /// <summary>
        /// Ширина отрисовки самосвала
        /// </summary>
        protected readonly int truckWidth = 100;
        /// <summary>
        /// Высота отрисовки самосвала
        /// </summary>
        protected readonly int truckHeight = 60;
        /// <summary>
        /// Максимальная скорость
        /// </summary>
       
        /// <param name="duct">Признак наличия трубы</param>
        /// <param name="carcase">Признак наличия кузова</param>
        /// <param name="frontLight">Признак наличия передней фары</param>
        /// <param name="backLight">Признак наличия задней фары</param>
        public Truck (int maxSpeed, float weight, Color mainColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            
        }

        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес самосвала</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        /// <param name="dopColor">Дополнительный цвет</param>
        /// <param name="duct">Признак наличия трубы</param>
        /// <param name="carcase">Признак наличия кузова</param>
        /// <param name="frontLight">Признак наличия передней фары</param>
        /// <param name="backLight">Признак наличия задней фары</param>
        protected Truck(int maxSpeed, float weight, Color mainColor, int truckWidth, int
truckHeight)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            this.truckWidth = truckWidth;
            this.truckHeight = truckHeight;
        }
        public override void MoveTransport(Direction direction)
        {
            int scale = 63;
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                // вправо
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - truckWidth - scale) { _startPosX += step; }
                    break;

                //влево
                case Direction.Left:
                    if (_startPosX - step > scale) { _startPosX -= step; }
                    break;

                //вверх
                case Direction.Up:
                    if (_startPosY - step > scale) { _startPosY -= step; }
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
        public override void DrawTransport(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Pen wheel = new Pen(Color.LightBlue);
          
            Brush fond = new SolidBrush(Color.Black);            
            Brush wheels = new SolidBrush(Color.LightBlue);

            
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


        }
    }
}
