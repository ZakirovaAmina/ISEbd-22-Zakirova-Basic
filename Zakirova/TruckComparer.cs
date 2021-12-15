using System.Collections.Generic;

namespace Zakirova
{
    public class TruckComparer : IComparer<Vehicle>
    {
        public int Compare(Vehicle x, Vehicle y)
        {
            //  метод сравнения для объектов
            if (x is DumpTruck && y is DumpTruck)
            {
                return ComparerDumpTruck((DumpTruck)x, (DumpTruck)y);
            }
            if (x is DumpTruck && y is Truck)
            {
                return -1;
            }
            if (x is Truck && y is DumpTruck)
            {
                return 1;
            }
            if (x is Truck && y is Truck)
            {
                return ComparerTruck((Truck)x, (Truck)y);
            }
            return 0;
        }
        private int ComparerTruck(Truck x, Truck y)
        {
            if (x.MaxSpeed != y.MaxSpeed)
            {
                return x.MaxSpeed.CompareTo(y.MaxSpeed);
            }
            
        if (x.Weight != y.Weight)
            {
                return x.Weight.CompareTo(y.Weight);
            }
            if (x.MainColor != y.MainColor)
            {
                return x.MainColor.Name.CompareTo(y.MainColor.Name);
            }
            return 0;
        }
        private int ComparerDumpTruck(DumpTruck x, DumpTruck y)
        {
            var res = ComparerTruck(x, y);
            if (res != 0)
            {
                return res;
            }
            if (x.DopColor != y.DopColor)
            {
                return x.DopColor.Name.CompareTo(y.DopColor.Name);
            }
            if (x.Duct != y.Duct)
            {
                return x.Duct.CompareTo(y.Duct);
            }
            if (x.Carcase != y.Carcase)
            {
                return x.Carcase.CompareTo(y.Carcase);
            }
            if (x.FrontLight != y.FrontLight)
            {
                return x.FrontLight.CompareTo(y.FrontLight);
            }
            if (x.BackLight != y.BackLight)
            {
                return x.BackLight.CompareTo(y.BackLight);
            }
            return 0;
        }
    }
}
