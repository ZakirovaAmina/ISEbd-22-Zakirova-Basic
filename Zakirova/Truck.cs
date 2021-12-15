﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Zakirova
{
	public class Truck : Vehicle, IEquatable<Truck>
    {
       
        /// <summary>
        /// Ширина отрисовки самосвала
        /// </summary>
        protected readonly int truckWidth = 90;
        /// <summary>
        /// Высота отрисовки самосвала
        /// </summary>
        protected readonly int truckHeight = 60;
        /// <summary>
        /// Разделитель для записи информации по объекту в файл
        /// </summary>
        protected readonly char separator = ';';
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
        /// <summary>
        /// Конструктор для загрузки с файла
        /// </summary>
        /// <param name="info">Информация по объекту</param>
        public Truck(string info)
        {
            string[] strs = info.Split(separator);
            if (strs.Length == 3)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromArgb(Convert.ToInt32(strs[2]));
            }
        }

        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес самосвала</param>
        /// <param name="mainColor">Основной цвет кузова</param>
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
            int scale = 110;
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                // вправо
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - truckWidth + scale) { _startPosX += step; }
                    break;

                //влево
                case Direction.Left:
                    if (_startPosX - step > 0) { _startPosX -= step; }
                    break;

                //вверх
                case Direction.Up:
                    if (_startPosY - step > 0) { _startPosY -= step; }
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
            Pen wheel = new Pen(MainColor);
          
            Brush fond = new SolidBrush(Color.Black);            
            Brush wheels = new SolidBrush(MainColor);

            
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
        public override string ToString()
        {
            return $"{MaxSpeed}{separator}{Weight}{separator}{MainColor.ToArgb()}";
        }

        /// <summary>
        /// Метод интерфейса IEquatable для класса Car
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Truck other)
        {
            if (other == null)
            {
                return false;
            }
            if (GetType().Name != other.GetType().Name)
            {
                return false;
            }
            if (MaxSpeed != other.MaxSpeed)
            {
                return false;
            }
            if (Weight != other.Weight)
            {
                return false;
            }
            if (MainColor != other.MainColor)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Перегрузка метода от object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Truck truckObj))
            {
                return false;
                
            }
            else
            {
                return Equals(truckObj);
            }
        }
    }
}
