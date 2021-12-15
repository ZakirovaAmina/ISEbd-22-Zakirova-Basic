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
    public class DumpTruck : Truck, IEquatable<DumpTruck>
    {       
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
        public DumpTruck(int maxSpeed, float weight, Color mainColor, Color dopColor,
bool duct, bool carcase, bool frontLight, bool backLight) :
 base(maxSpeed, weight, mainColor, 100, 60)
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
        /// Конструктор для загрузки с файла
        /// </summary>
        /// <param name="info"></param>
        public DumpTruck(string info) : base(info)
        {
            string[] strs = info.Split(separator);
            if (strs.Length == 8)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromArgb(Convert.ToInt32(strs[2]));
                DopColor = Color.FromArgb(Convert.ToInt32(strs[3]));
                Duct = Convert.ToBoolean(strs[4]);
                Carcase = Convert.ToBoolean(strs[5]);
                FrontLight = Convert.ToBoolean(strs[6]);
                BackLight = Convert.ToBoolean(strs[7]);
            }
        }

        /// <summary>
        /// Отрисовка самосвала
        /// </summary>
        /// <param name="g"></param>
        public override void DrawTransport(Graphics g)
        {          
            Pen fog1 = new Pen(Color.Gray);
            Pen back1 = new Pen(DopColor);
            Pen light1 = new Pen(Color.Yellow);
         
            Brush light = new SolidBrush(Color.Yellow);
            Brush fog = new SolidBrush(Color.Gray);
            Brush back = new SolidBrush(DopColor);

            base.DrawTransport(g);

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
        /// <summary>
        /// Смена дополнительного цвета
        /// </summary>
        /// <param name="color"></param>
        public void SetDopColor(Color color)
        {
            DopColor = color;
        }

        public override string ToString()
        {
            return
           $"{base.ToString()}{separator}{DopColor.ToArgb()}{separator}{Duct}{separator}{Carcase}" +
           $"{separator}{FrontLight}{ separator}{BackLight}";
        }

        /// <summary>
        /// Метод интерфейса IEquatable для класса SportCar
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(DumpTruck other)
        {
            // Реализовать метод сравнения для дочернего класса
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
            if (DopColor != other.DopColor)
            {
                return false;
            }
            if (Duct != other.Duct)
            {
                return false;
            }
            if (Carcase != other.Carcase)
            {
                return false;
            }
            if (FrontLight != other.FrontLight)
            {
                return false;
            }
            if (BackLight != other.BackLight)
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
            if (!(obj is DumpTruck truckObj))
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
