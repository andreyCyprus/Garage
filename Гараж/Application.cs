using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Гараж
{
    internal class Application
    {
        Random random = new Random();

        Admin admin1 = new Admin("Андрей");

        private List<Garage> _garages = new List<Garage>()
        {
            new Garage ("Гараж1"),
            new Garage ("Гараж2"),
            new Garage ("Гараж3"),
            new Garage ("Гараж4"),
            new Garage ("Гараж5"),
        };
        Dictionary<Garage, int> listToPay = new Dictionary<Garage, int>();
        public void Work()
        {
            while (true)
            {
                Console.WriteLine($"Балланс админа:  {admin1.GetMyFieldBalance()}");

                Console.Write("\n** " + new string('-', 33) + " ** ");

                listToPay = GetAllGaragePricesList(random);

                WishOrderService();

                Console.WriteLine($"\nЦены за выбранный сервис от всех гаражей:");

                PrintAllGaragePriceList(listToPay);
  
                Console.WriteLine("\nХотите перейти к оплате?");

                PaymentProceed();


                Console.WriteLine("\nВыберите желаемый гараж для оплаты:");

                int moneyPaid = Pay(PaymentArray(listToPay));

                Console.Write("\n** " + new string('-', 33) + " ** ");


                Console.WriteLine($"\nБалланс админа: {admin1.GetMyFieldBalance()} ");

                Console.WriteLine($"\nБалланс админа после оплаты:{admin1.GetMoneyBalance(moneyPaid)}");  


                Console.ReadKey();
                Console.Clear();

            }
        }

        public void WishOrderService()
        {
            string orderedService;
            Console.WriteLine($"\nКлиент выберите желаемый сервис:");

            Console.WriteLine("\n1 - service1 \n2 - service2\n3 - service3");

            var wishOrderService = new Dictionary<int, string>()
            {
                [1] = "service1",
                [2] = "service2",
                [3] = "service3",
            };

            switch (CheckInput ())
            {
                case 1:
                    orderedService = wishOrderService[1];
                    Console.WriteLine($"\nВы выбрали {orderedService}");

                    break;

                case 2:
                    orderedService = wishOrderService[2];
                    Console.WriteLine($"\nВы выбрали {orderedService}");

                    break;

                case 3:
                    orderedService = wishOrderService[3];
                    Console.WriteLine($"\nВы выбрали {orderedService}");

                    break;
                default:
                    Console.WriteLine("\nВведена неверная команда.");
                    Console.ReadKey();
                    Console.Clear();
                    Work ();
                    break;

            }



        }

        public int CheckInput()
        {
            string input = Console.ReadLine();
            if (Int32.TryParse(input, out int result))
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Входная строка не является числом");
            }
            return result;
        }

        public Dictionary <Garage, int>  GetAllGaragePricesList(Random random)
        {
            Dictionary<Garage, int> garagesPriceList = _garages.ToDictionary(key => key, value => value.GetPrice(random));

            return garagesPriceList;
        }

        public void PrintAllGaragePriceList(Dictionary<Garage, int> priceList)
        {
            foreach (var pair in priceList)
            {
                Console.WriteLine("{0}: {1}", pair.Key.garageName, pair.Value);
            }
            var minKeyValuePair = priceList.Aggregate((l, r) => l.Value < r.Value ? l : r);
            var minKey = minKeyValuePair.Key.garageName;
            int minValue = minKeyValuePair.Value;

            Console.WriteLine($"\nЛучшая цена за выбранный сервис: {minValue} у гаража - {minKey}");

        }

        public void PaymentProceed()
        {
            Console.WriteLine("1 - Да ,\n2 - Нет");
            switch (CheckInput())
            {
                case 1:

                    Console.Clear();
                    PrintPaymentArray(PaymentArray(listToPay)); 

                    break ; 
                
                case 2:

                    Console.Clear();
                    Work();
                    
                    break;

                default:

                    Console.Clear();
                    PaymentProceed(); 
                    
                    break;
            }






        }

        public  int[] PaymentArray(Dictionary<Garage, int> garages)
        {
            int[] paymentArray = new int[garages.Count];
            int i = 0;

            foreach (KeyValuePair<Garage , int> pair in garages)
            {
                paymentArray[i] = pair.Value;
                i++;
            }

            return paymentArray;
        }

        public void  PrintPaymentArray(int[]array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int index = i + 1;
                Console.WriteLine($"\n{index} - гараж{index} - {array[i]}");
            }
          
        }

        public int Pay(int[] array)
        {
            int moneyToPay = 0;
            bool nonRightInput = true;
            while (nonRightInput)
            {
                int index = CheckInput();

                if (index > 0 && index <= array.Length)
                {
                    Console.WriteLine($"Вы выбрали:{array[index - 1]}");
                    nonRightInput = false;
                    moneyToPay = array[index - 1];
                }
                else
                {
                    Console.WriteLine("Сделайте правильный ввод");
                }
            }
            return moneyToPay;


        }





    }




}





