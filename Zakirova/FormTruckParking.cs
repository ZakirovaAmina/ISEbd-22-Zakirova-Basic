using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zakirova
{
    public partial class FormTruckParking : Form
    {
        private readonly Parking<Truck> parking;
        public FormTruckParking()
        {
            InitializeComponent();
            parking = new Parking<Truck>(pictureBoxParking.Width,
pictureBoxParking.Height);
            Draw();
        }
        /// <summary>
        /// Метод отрисовки парковки
        /// </summary>
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxParking.Width, pictureBoxParking.Height);
            Graphics gr = Graphics.FromImage(bmp);
            parking.Draw(gr);
            pictureBoxParking.Image = bmp;
        }      
        /// <summary>
        /// Обработка нажатия кнопки "Припарковать автомобиль"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_parking_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var truck = new Truck(100, 1000, dialog.Color);

                if (parking + truck != -1)
                {
                    Draw();
                }
                else
                {
                    MessageBox.Show("Парковка переполнена");
                }
            }
        }
        /// <summary>
        /// Обработка нажатия кнопки "Припарковать гоночный автомобиль"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_parkingMod_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ColorDialog dialogDop = new ColorDialog();
                if (dialogDop.ShowDialog() == DialogResult.OK)
                {
                    var truck = new DumpTruck(100, 1000, dialog.Color, dialogDop.Color,
                   true, true, true, true);
                    if (parking + truck != -1)
                    {
                        Draw();
                    }
                    else
                    {
                        MessageBox.Show("Парковка переполнена");
                    }
                }
            }
        }
        /// <summary>
        /// Обработка нажатия кнопки "Забрать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Take_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != "")
            {
                var truck = parking - Convert.ToInt32(maskedTextBox1.Text);
                if (truck != null)
                {
                    FormTruck form = new FormTruck();
                    form.SetTruck(truck);
                    form.ShowDialog();
                }
                Draw();
            }
        }
    }
}
