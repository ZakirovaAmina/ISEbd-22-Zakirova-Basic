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
    public partial class FormTruckConfig : Form
    {
        /// <summary>
        /// Переменная-выбранная машина
        /// </summary>
        Vehicle truck = null;

        /// <summary>
        /// Событие
        /// </summary>
        private event Action<Vehicle> eventAddTruck;

        public FormTruckConfig()
        {
            InitializeComponent();
            this.panelPurple.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelColor_MouseDown);
            this.panelYellow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelColor_MouseDown);
            this.panelOrange.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelColor_MouseDown);
            this.panelPink.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelColor_MouseDown);
            this.panelGreen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelColor_MouseDown);
            this.panelAqua.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelColor_MouseDown);
            this.panelBlue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelColor_MouseDown);
            this.panelRed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelColor_MouseDown);
            buttonCancel.Click += (object sender, EventArgs e) => { Close(); };
        }
        /// <summary>   
        /// Отрисовать машину
        /// </summary>
        private void DrawTruck()
        {
            if (truck != null)
            {
                Bitmap bmp = new Bitmap(pictureBoxShowTruck.Width, pictureBoxShowTruck.Height);
                Graphics gr = Graphics.FromImage(bmp);
                truck.SetPosition(5, 5, pictureBoxShowTruck.Width, pictureBoxShowTruck.Height);
                truck.DrawTransport(gr);
                pictureBoxShowTruck.Image = bmp;
            }
        }
        /// <summary>
        /// Передаем информацию при нажатии на Label обычный
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelTruck_MouseDown(object sender, MouseEventArgs e)
        {
            labelTruck.DoDragDrop(labelTruck.Text, DragDropEffects.Move |
                DragDropEffects.Copy);
        }

        /// <summary>
        /// Передаем информацию при нажатии на Label улучшенный
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelImprovedTruck_MouseDown(object sender, MouseEventArgs e)
        {
            labelImprovedTruck.DoDragDrop(labelImprovedTruck.Text, DragDropEffects.Move |
                DragDropEffects.Copy);
        }

        /// <summary>
        /// Действия при приеме перетаскиваемой информации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelShowTruck_DragDrop(object sender, DragEventArgs e)
        {
            switch (e.Data.GetData(DataFormats.Text).ToString())
            {
                case "Обычный самосвал":
                    truck = new Truck((int)numericUpDownMaxSpeed.Value,
                        (int)numericUpDownWeightTruck.Value, Color.Black);
                    break;
                case "Улучшенный самосвал":
                    truck = new DumpTruck((int)numericUpDownMaxSpeed.Value,
                        (int)numericUpDownWeightTruck.Value, Color.Black, Color.Brown,
                        checkBoxDuct.Checked, checkBoxCarcase.Checked,
                        checkBoxFrontLight.Checked, checkBoxBackLight.Checked);
                    break;
            }
            DrawTruck();
        }

        /// <summary>
        /// Добавление события
        /// </summary>
        /// <param name="ev"></param>
        public void AddEvent(Action<Vehicle> ev)
        {
            if (eventAddTruck == null)
            {
                eventAddTruck = new Action<Vehicle>(ev);
            }
            else
            {
                eventAddTruck += ev;
            }
        }   

        /// <summary>
        /// Проверка получаемой информации (ее типа на соответствие требуемому)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelShowTruck_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void PanelColor_MouseDown(object sender, MouseEventArgs e)
        {
            Color color = (sender as Panel).BackColor;
            (sender as Panel).DoDragDrop(color, DragDropEffects.Move | DragDropEffects.Copy);

        }
        private void labelMainColor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Color)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void labelMainColor_DragDrop(object sender, DragEventArgs e)
        {
            truck.SetMainColor((Color)e.Data.GetData(typeof(Color)));
            DrawTruck();
        }
        private void labelDopColor_DragDrop(object sender, DragEventArgs e)
        {
            if (truck is DumpTruck)
            {
                (truck as DumpTruck).SetDopColor((Color)e.Data.GetData(typeof(Color)));
                DrawTruck();
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            eventAddTruck?.Invoke(truck);
            Close();
        }
    }
}
