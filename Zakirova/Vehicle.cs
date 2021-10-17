using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Zakirova
{
    public abstract class Vehicle : ITTruck
    {
        /// <summary>
        /// Левая координата отрисовки самосвала
        /// </summary>
        protected float _startPosX;
        /// <summary>
        /// Правая кооридната отрисовки самосвала
        /// </summary>
        protected float _startPosY;
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        protected int _pictureWidth = 100;
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        protected int _pictureHeight = 100;
        protected int height = 57;
        
        /// <summary>
        /// Максимальная скорость
        /// </summary>
        public int MaxSpeed { protected set; get; }
        /// <summary>
        /// Вес самосвала
        /// </summary>
        public float Weight { protected set; get; }
        /// <summary>
        /// Основной цвет кузова
        /// </summary>
        public Color MainColor { protected set; get; }
        /// <summary>
        /// Дополнительный цвет
        /// </summary>
       
        public void SetPosition(int x, int y, int width, int height)
        {
            _startPosX = x + 60;
            _startPosY = y + 57;
            _pictureHeight = height;
            _pictureWidth = width;
        }
        public abstract void DrawTransport(Graphics g);
        public abstract void MoveTransport(Direction direction);
    }
}
