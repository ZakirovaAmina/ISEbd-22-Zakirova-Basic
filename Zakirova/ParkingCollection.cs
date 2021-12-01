using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace Zakirova
{
    public class ParkingCollection
    {
        /// <summary>
        /// Словарь (хранилище) с парковками
        /// </summary>
        readonly Dictionary<string, Parking<Vehicle>> parkingStages;
        /// <summary>
        /// Возвращение списка названий праковок
        /// </summary>
        public List<string> Keys => parkingStages.Keys.ToList();
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private readonly int pictureWidth;
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private readonly int pictureHeight;
        /// <summary>
        /// Разделитель для записи информации в файл
        /// </summary>
        private readonly char separator = ':';
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pictureWidth"></param>
        /// <param name="pictureHeight"></param>
        public ParkingCollection(int pictureWidth, int pictureHeight)
        {
            parkingStages = new Dictionary<string, Parking<Vehicle>>();
            this.pictureWidth = pictureWidth;
            this.pictureHeight = pictureHeight;
        }

        /// <summary>
        /// Добавление парковки
        /// </summary>
        /// <param name="name">Название парковки</param>
        public void AddTruckParking(string name)
        {
            if (parkingStages.ContainsKey(name))
            {
                return;
            }
            parkingStages.Add(name, new Parking<Vehicle>(pictureWidth, pictureHeight));
        }
        /// <summary>
        /// Удаление парковки
        /// </summary>
        /// <param name="name">Название парковки</param>
        public void DelParking(string name)
        {
            if (parkingStages.ContainsKey(name))
            {
                parkingStages.Remove(name);
            }
        }
        /// <summary>
        /// Доступ к парковке
        /// </summary>
        /// <param name="ind"></param>
        /// <returns></returns>
        public Parking<Vehicle> this[string ind]
        {
            get
            {
                if (parkingStages.ContainsKey(ind))
                {
                    return parkingStages[ind];
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Метод записи информации в файл
        /// </summary>
        /// <param name="text">Строка, которую следует записать</param>
        /// <param name="stream">Поток для записи</param>
        private void WriteToFile(string text, FileStream stream)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(text);
            stream.Write(info, 0, info.Length);
        }
        /// <summary>
        /// Сохранение информации по автомобилям на парковках в файл
        /// </summary>
        /// <param name="filename">Путь и имя файла</param>
        /// <returns></returns>
        public bool SaveData(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            using (StreamWriter fs = new StreamWriter(filename))
            {
                fs.Write($"ParkingCollection{Environment.NewLine}");
                foreach (var level in parkingStages)
                {
                    //Начинаем парковку
                    fs.Write($"Parking{separator}{level.Key}{Environment.NewLine}");
                    ITTruck truck = null;
                    for (int i = 0; (truck = level.Value.GetNext(i)) != null; i++)
                    {
                        if (truck != null)
                        {
                            //если место не пустое
                            //Записываем тип машины
                            if (truck.GetType().Name == "Truck")
                            {
                                fs.Write($"Truck{separator}");
                            }
                            if (truck.GetType().Name == "DumpTruck")
                            {
                                fs.Write($"DumpTruck{separator}");
                            }
                            //Записываемые параметры
                            fs.Write(truck + Environment.NewLine);
                        }
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Загрузка Информации по автомобилям на парковках из файла
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool LoadData(string filename)
        {
            if (!File.Exists(filename))
            {
				throw new FileNotFoundException();
            }
            string bufferTextFromFile = "";
            using (StreamReader fs = new StreamReader(filename))
            {

                bufferTextFromFile = fs.ReadLine();

                if (bufferTextFromFile.Contains("ParkingCollection"))
                {
                    //очищаем записи
                    parkingStages.Clear();
                }
                else
                {
					//если нет такой записи, то это не те данные
					throw new FileLoadException("Неверный формат файла");
					
				}
                Vehicle truck = null;
                string key = string.Empty;                
                while (!fs.EndOfStream) { 

                    //идем по считанным записям
                    bufferTextFromFile = fs.ReadLine();
                    if (bufferTextFromFile.Contains("Parking"))
                    {
                        //начинаем новую парковку
                        key = bufferTextFromFile.Split(separator)[1];
                        parkingStages.Add(key, new Parking<Vehicle>(pictureWidth, pictureHeight));
                        continue;
                    }
                    if (string.IsNullOrEmpty(bufferTextFromFile))
                    {
                        continue;
                    }
                    if (bufferTextFromFile.Split(separator)[0] == "Truck")
                    {
                        truck = new Truck(bufferTextFromFile.Split(separator)[1]);
                    }
                    else if (bufferTextFromFile.Split(separator)[0] == "DumpTruck")
                    {
                        truck = new DumpTruck(bufferTextFromFile.Split(separator)[1]);
                    }
                    var result = parkingStages[key] + truck;
                    if (!result)
                    {
                        throw new FileLoadException("Не удалось загрузить автомобиль на парковку");
                    }
                }

            }
            return true;
        }
    }
}
