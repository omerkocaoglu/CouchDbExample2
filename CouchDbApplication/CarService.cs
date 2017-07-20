using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LoveSeat;
using Newtonsoft.Json;
using CouchDbApplication.DTO;


namespace CouchDbApplication
{
    public class CarService:BaseConnection
    {
        public List<Car> CreateCars()
        {
            List<Car> cars = new List<Car>();
            string baseNumber = DateTime.Now.Year.ToString() + "00000";
            string[] brands = new string[] { "Mercedes", "BMW", "Audi", "Volkswagen", "Opel" };
            string[] models = new string[] { "E250", "AMG GT", "AMG C63", "C180", "A180", "M5", "750Li", "520i", "320d", "A8", "A7", "A6", "A5", "A4", "Q7", "Q5", "Polo", "Golf", "Jetta", "Passat", "Insignia", "Corsa", "Astra" };
            for (int i = 0; i < 50; i++)
            {

                Car car = new Car();
                car.Number = baseNumber + (i + 1).ToString();
                if (i < 10)
                {
                    car.Brand = brands[0];
                }
                else if (i < 20)
                {
                    car.Brand = brands[1];
                }
                else if (i < 30)
                {
                    car.Brand = brands[2];
                }
                else if (i < 40)
                {
                    car.Brand = brands[3];
                }
                else if (i < 50)
                {
                    car.Brand = brands[4];
                }
                switch (car.Brand)
                {
                    case "Mercedes":
                        car.Model = models[new Random().Next(0, 5)];
                        Thread.Sleep(10);
                        break;
                    case "BMW":
                        car.Model = models[new Random().Next(5, 9)];
                        Thread.Sleep(15);
                        break;
                    case "Audi":
                        car.Model = models[new Random().Next(9, 16)];
                        Thread.Sleep(20);
                        break;
                    case "Volkswagen":
                        car.Model = models[new Random().Next(16, 20)];
                        Thread.Sleep(25);
                        break;
                    case "Opel":
                        car.Model = models[new Random().Next(20, 23)];
                        Thread.Sleep(30);
                        break;
                }
                car.Year = new Random().Next(2010, 2018);
                car.Price = new Random().Next(50000, 500000);
                cars.Add(car);

            }
            return cars;
        }
        public void ListAllCars()
        {
            ViewResult result = Db.View("getall", null, "car");
            foreach (var item in result.Rows)
            {
                carDTO car = JsonConvert.DeserializeObject<carDTO>(item.ToString());
                Console.Write("\n");
                Console.WriteLine("Araç Şasi No  : " + car.Id);
                Console.WriteLine("Araç Motor No : " + car.Key);
                Console.WriteLine("Marka : " + car.Value[0]);
                Console.WriteLine("Model : " + car.Value[1]);
                Console.WriteLine("Yıl   : " + car.Value[2]);
                Console.WriteLine("Fiyat : " + car.Value[3]);
            }
        }
        public void GroupCarByModel()
        {
            ViewOptions option = new ViewOptions();
            option.GroupLevel = 2;
            ViewResult result = Db.View("groupbybrand",option, "car");
            foreach (var item in result.Rows)
            {
                groupingCarDTO groupingCar = JsonConvert.DeserializeObject<groupingCarDTO>(item.ToString());
                Console.Write("\n");
                Console.WriteLine("Marka : " + groupingCar.Key[0]);
                Console.WriteLine("Model : " + groupingCar.Key[1]);
                Console.WriteLine("Adet  :" + groupingCar.Value);
            }
        }

        public void GroupCarByBrand()
        {
            ViewOptions option = new ViewOptions();
            option.GroupLevel = 1;
            ViewResult result = Db.View("groupbybrand", option, "car");
            foreach (var item in result.Rows)
            {
                groupingCarDTO groupingCar = JsonConvert.DeserializeObject<groupingCarDTO>(item.ToString());
                Console.Write("\n");
                Console.WriteLine("Marka : " + groupingCar.Key[0]);
                Console.WriteLine("Adet  :" + groupingCar.Value);
            }
        }

        public void OrderByDescendingForPrice()
        {
            ViewOptions option = new ViewOptions();
            option.Descending = true;
            ViewResult result = Db.View("descendingbyprice", option, "car");
            foreach (var item in result.Rows)
            {
                descendingCarDTO descendingCar = JsonConvert.DeserializeObject<descendingCarDTO>(item.ToString());
                Console.Write("\n");
                Console.WriteLine("Araç Şasi No: " + descendingCar.Id);
                Console.WriteLine("Araç Motor No: " + descendingCar.Value[0]);
                Console.WriteLine("Marka: " + descendingCar.Value[1]);
                Console.WriteLine("Model: " + descendingCar.Value[2]);
                Console.WriteLine("Fiyat: " + descendingCar.Key);
            }
        }

        public void OrderByDescendingForYear()
        {
            ViewOptions option = new ViewOptions();
            option.Descending = true;
            ViewResult result = Db.View("descendingbyyear", option, "car");
            foreach (var item in result.Rows)
            {
                descendingCarDTO descendingCar = JsonConvert.DeserializeObject<descendingCarDTO>(item.ToString());
                Console.Write("\n");
                Console.WriteLine("Araç Saşi No: " + descendingCar.Id);
                Console.WriteLine("Araç Motor No: " + descendingCar.Value[0]);
                Console.WriteLine("Marka: " + descendingCar.Value[1]);
                Console.WriteLine("Model: " + descendingCar.Value[2]);
                Console.WriteLine("Yıl  : " + descendingCar.Key);
            }
        }
    }
}
