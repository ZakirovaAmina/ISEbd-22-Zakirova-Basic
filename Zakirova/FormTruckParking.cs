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
        /// <summary>
        /// Объект от класса-коллекции парковок
        /// </summary>
        private readonly ParkingCollection parkingCollection;
        public FormTruckParking()
        {
            InitializeComponent();
            parkingCollection = new ParkingCollection(pictureBoxParking.Width,
pictureBoxParking.Height);
        }
        /// <summary>
        /// Заполнение listBoxLevels
        /// </summary>
        private void ReloadLevels()
        {
            int index = listBoxParking.SelectedIndex;
            listBoxParking.Items.Clear();
            for (int i = 0; i < parkingCollection.Keys.Count; i++)
            {
                listBoxParking.Items.Add(parkingCollection.Keys[i]);
            }
            if (listBoxParking.Items.Count > 0 && (index == -1 || index >=
           listBoxParking.Items.Count))
            {
                listBoxParking.SelectedIndex = 0;
            }
            else if (listBoxParking.Items.Count > 0 && index > -1 && index <
           listBoxParking.Items.Count)
            {
                listBoxParking.SelectedIndex = index;
            }
        }


        /// <summary>
        /// Метод отрисовки парковки
        /// </summary>
        private void Draw()
        {
            if (listBoxParking.SelectedIndex > -1)
            {//если выбран один из пуктов в listBox (при старте программы ни один пункт
             //не будет выбран и может возникнуть ошибка, если мы попытаемся обратиться к элементу listBox)
                Bitmap bmp = new Bitmap(pictureBoxParking.Width, pictureBoxParking.Height);
                Graphics gr = Graphics.FromImage(bmp);
                parkingCollection[listBoxParking.SelectedItem.ToString()].Draw(gr);
                pictureBoxParking.Image = bmp;
            }
        }      
        /// <summary>
        /// Обработка нажатия кнопки "Припарковать автомобиль"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_parking_Click(object sender, EventArgs e)
        {
            var formTruckConfig = new FormTruckConfig();
            formTruckConfig.AddEvent(AddTruck);
            formTruckConfig.Show();
        }
        /// <summary>
        /// Метод добавления машины
        /// </summary>
        private void AddTruck(Vehicle truck)
        {
            if (truck != null && listBoxParking.SelectedIndex > -1)
            {
                if ((parkingCollection[listBoxParking.SelectedItem.ToString()]) + truck)
                {
                    Draw();
                }
                else
                {
                    MessageBox.Show("Самосвал не удалось поставить");
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
            if (listBoxParking.SelectedIndex > -1 && maskedTextBox1.Text != "")
            {

                var truck = parkingCollection[listBoxParking.SelectedItem.ToString()] -
                    Convert.ToInt32(maskedTextBox1.Text);
                if (truck != null)
                {
                    FormTruck form = new FormTruck();
                    form.SetTruck(truck);
                    form.ShowDialog();
                }
                Draw();
            }
        }

        /// <summary>
        /// Обработка нажатия кнопки "Добавить парковку"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddPark_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLevelsName.Text))
            {
                MessageBox.Show("Введите название парковки", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            parkingCollection.AddTruckParking(textBoxLevelsName.Text);
            ReloadLevels();
        }
        /// <summary>
        /// Обработка нажатия кнопки "Удалить парковку"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void DelPark_Click(object sender, EventArgs e)
        {
            if (listBoxParking.SelectedIndex > -1)
            {
                if (MessageBox.Show($"Удалить парковку {listBoxParking.SelectedItem.ToString()}?", "Удаление",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {                    
                    parkingCollection.DelParking(textBoxLevelsName.Text);
                    ReloadLevels();                    
                }
            }
        }
      
        /// <summary>
        /// Метод обработки выбора элемента на listBoxLevels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void listBoxParking_SelectedIndexChanged(object sender, EventArgs e)
        {
            Draw();
        }
    }
}
