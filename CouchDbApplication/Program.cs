using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoveSeat;
using Newtonsoft.Json;

namespace CouchDbApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            CarService carService = new CarService();
            while (true)
            {
                Console.Write("\n");
                Console.WriteLine("Menu (CouchDB Vehicle Example)");
                Console.WriteLine("------------------------------");
                Console.WriteLine("Car List ==> (1)");
                Console.WriteLine("Car List By Car Model ==> (2)");
                Console.WriteLine("Car List By Car Brand ==> (3)");
                Console.WriteLine("Car List Order By Descending For Price ==> (4)");
                Console.WriteLine("Car List Order By Descending For Year ==> (5)");
                string selection = Console.ReadLine();
                if (Convert.ToInt32(selection) < 6 & Convert.ToInt32(selection) > 0)
                {
                    switch (selection)
                    {
                        case "1":
                            carService.ListAllCars();
                            break;
                        case "2":
                            carService.GroupCarByModel();
                            break;
                        case "3":
                            carService.GroupCarByBrand();
                            break;
                        case "4":
                            carService.OrderByDescendingForPrice();
                            break;
                        case "5":
                            carService.OrderByDescendingForYear();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Menuü dışında bir indeks seçtiniz...");
                    Console.ReadLine();
                }
            }
        }
    }
}
