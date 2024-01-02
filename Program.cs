using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Калькулятор планування ремонтних робiт в квартирi.");
            Console.Write(" Загальна площа квартири в метрах:");
            double allArea = double.Parse(Console.ReadLine());
            Console.Write(" Загальна кiлькiсть кiмнат:");
            int rooms = int.Parse(Console.ReadLine());
            Console.Write(" Висота в метрах:");
            double H = double.Parse(Console.ReadLine());

            int n;
            do
            {
                Console.WriteLine(" Обрахунок.\n 1 - Загальнi матерiали. \n 2 - Кiмнати. \n 3 - Кухня. \n 4 - Санвузол. \n 5 - Коридор. \n 0 - Виxiд. ");
                n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        AreaParameters(allArea);
                        break;
                    case 2:
                        for (int i = 1; i <= rooms; i++)
                        {
                            Console.WriteLine(" Кiмната {0}", i);
                            RoomParametrs(H, n);
                        }
                        break;
                    case 3:
                        Console.WriteLine(" Кухня:");
                        RoomParametrs(H, n);
                        break;
                    case 4:
                        Console.WriteLine(" Оберiть вид санвузла: \n 1 - сумiжний. \n 2 - роздiльний.");
                        int nFlloor = int.Parse(Console.ReadLine());
                        switch (nFlloor)
                        {
                            case 1:
                                RoomParametrs(H, n);
                                break;
                            case 2:
                                for (int i = 1; i <= 2; i++)
                                {
                                    RoomParametrs(H, n);
                                }
                                break;
                        }
                        break;
                    case 5:
                        Console.WriteLine(" Коридор:");
                        RoomParametrs(H, n);
                        break;
                    default:
                        Console.WriteLine($" Число {n} не вiдповiдає умовi. Натиснiть Enter для продовження.");
                        Console.ReadLine();
                        break;
                    case 0:
                        Console.WriteLine(" Натиснiть Enter для заверешння.");
                        break;
                    
                }

            } while (n != 0);

            Console.ReadKey();
        }
        static double Perimeter(double width, double length)
        {
            return (width + length) * 2;
        }
        static double Area(double width, double length)
        {
            return Math.Ceiling(width * length);
        }
        static double Cost(double cost1, double material)
        {
            return cost1 * material;
        }
        static double AllNeeds(double a, double b)
        {
            return Math.Ceiling(a / b);
        }

        static void AreaInformation(double PerSquareMeter, double CostPerSquareMeter, double allArea)
        {
            double Total = PerSquareMeter * allArea;
            double CostTotal = Cost(CostPerSquareMeter, Total);
            Console.WriteLine($" Загальна кiлькiсть матерiалу приблизно {Total:F2}. \n Загальна вартiсть матерiалу: {CostTotal:F2}");

            Console.WriteLine();
        }
        static void AreaParameters(double allArea)
        {
            Console.WriteLine(" Загальнi матерiали.");

            Console.Write(" Введiть кiлькiсть матерiалу (штукатурка) на 1 кв. метр: ");
            double plasterPerSquareMeter = double.Parse(Console.ReadLine());
            Console.Write(" Введiть вартiсть матерiалу (штукатурка): ");
            double plasterCostPerSquareMeter = double.Parse(Console.ReadLine());
            AreaInformation(plasterPerSquareMeter, plasterCostPerSquareMeter, allArea);

            Console.Write(" Введiть кiлькiсть матерiалу (грунтовка) на 1 кв. метр: ");
            double primerPerSquareMeter = double.Parse(Console.ReadLine());
            Console.Write(" Введiть вартiсть матерiалу (грунтовка): ");
            double primerCostPerSquareMeter = double.Parse(Console.ReadLine());
            AreaInformation(primerPerSquareMeter, primerCostPerSquareMeter, allArea);

            Console.Write(" Введiть кiлькiсть матерiалу (стяжка для пiдлоги) на 1 кв. метр: ");
            double screedPerSquareMeter = double.Parse(Console.ReadLine());
            Console.Write(" Введiть вартiсть матерiалу (грунтовка): ");
            double screedCostPerSquareMeter = double.Parse(Console.ReadLine());
            AreaInformation(screedPerSquareMeter, screedCostPerSquareMeter, allArea);

            Console.Write(" Введiть кiлькiсть матерiалу (утеплювач пiдлоги) на 1 кв. метр: ");
            double insulationPerSquareMeter = double.Parse(Console.ReadLine());
            Console.Write(" Введiть вартiсть матерiалу (грунтовка): ");
            double insulationCostPerSquareMeter = double.Parse(Console.ReadLine());
            AreaInformation(insulationPerSquareMeter, insulationCostPerSquareMeter, allArea);

            Console.Write(" Введiть довжину електрокабелiв на 1 кв. метр: ");
            double electricalCablePerSquareMeter = double.Parse(Console.ReadLine());
            Console.Write(" Введiть вартiсть матерiалу (грунтовка): ");
            double electricalCableCostPerSquareMeter = double.Parse(Console.ReadLine());
            AreaInformation(electricalCablePerSquareMeter, electricalCableCostPerSquareMeter, allArea);
        }

        static void RoomParametrs(double H, double n)
        {
            Console.WriteLine();
            Console.Write(" Введiть довжину примiщення в метрах:");
            double width = double.Parse(Console.ReadLine());
            Console.Write(" Введiть ширину примiщення в метрах:");
            double length = double.Parse(Console.ReadLine());

            double floorArea = Area(width, length); //підлога = стеля
            double totalWallArea = Perimeter(width, length) * H; //повна площа стін

            Console.WriteLine(" Площа примiщення: {0}", floorArea);

            double cost = 0;

            Console.WriteLine(" Обрахунок матерiалiв.");
            Console.WriteLine(" Пiдлога.");
            cost += Floor(floorArea);
            Console.WriteLine(" Оберiть матерiал для стiн: \n 1 - шпалери/плитка (для санвузла). \n 2 - фарба.");
            int nWall = int.Parse(Console.ReadLine());
            switch (nWall)
            {
                case 1:
                    if (n != 4)
                    {
                        cost += Wallpaper(totalWallArea);
                    }
                    else
                    {
                        cost += Floor(totalWallArea);
                    }
                    break;
                case 2:
                    cost += Paint(totalWallArea);
                    break;
                default:
                    Console.WriteLine($" Число {n} не вiдповiдає умовi. Натиснiть Enter для продовження.");
                    Console.ReadLine();
                    break;
            }
            Console.WriteLine(" Оберiть матерiал для стелi: \n1 - натяжна стеля. \n2 - фарбована стеля.");
            int nCelling = int.Parse(Console.ReadLine());
            switch (nCelling)
            {
                case 1:
                    Console.WriteLine(" Оформлення стелi - натяжна стеля.");

                    Console.Write(" Введiть вартiсть за 1 кв. метр:");
                    double costCelling = double.Parse(Console.ReadLine());
                    double costC = Cost(costCelling, floorArea);

                    Console.WriteLine();
                    Console.WriteLine($" Загальна вартiсть: {costC}.");
                    Console.WriteLine();
                    cost += costC;
                    break;
                case 2:
                    Console.WriteLine(" Оформлення стелi - фарба.");
                    cost += Paint(floorArea);
                    break;
                default:
                    Console.WriteLine($" Число {n} не вiдповiдає умовi. Натиснiть Enter для продовження.");
                    Console.ReadLine();
                    break;
            }
            Console.WriteLine();
            Console.Write(" Додайте вартiсть обраних вами дверей:");
            double doorCost = double.Parse(Console.ReadLine());
            cost += doorCost;
            Console.WriteLine();
            Console.WriteLine($" Загальна вартiсть примiщення: {cost}.");
            Console.WriteLine();
        }
        static double Wallpaper(double totalWallArea)
        {
            Console.WriteLine(" Введiть розмiри рулону шпалер.");

            Console.Write(" Ширина рулону в метрах: ");
            double wallpaperWidth = double.Parse(Console.ReadLine());

            Console.Write(" Довжина рулону в метрах: ");
            double wallpaperLength = double.Parse(Console.ReadLine());

            double wallpaperArea = Area(wallpaperWidth, wallpaperLength);
            double rollsNeeded = AllNeeds(totalWallArea, wallpaperArea);

            Console.Write(" Цiна за 1 рулон шпалер:");
            double rollsCost = double.Parse(Console.ReadLine());

            double cost = Cost(rollsCost, rollsNeeded);

            Console.WriteLine();
            Console.WriteLine($"\n Для облаштування цього примiщення знадобиться " +
                $"приблизно {rollsNeeded} рулонiв шпалер. " +
                $"\n Загальна вартiсть: {cost}.");
            Console.WriteLine();
            return cost;
        }

        static double Paint(double wallArea)
        {
            double paintVolume = AllNeeds(wallArea, 10) * 2;

            Console.Write(" Цiна за 1 лiтр фарби: ");
            double paintCost = double.Parse(Console.ReadLine());

            double cost = Cost(paintCost, paintVolume);

            Console.WriteLine();
            Console.WriteLine($"\n Для фарбування знадобиться " +
                $"приблизно {paintVolume:F2} лiтрiв фарби." +
                $"\n Загальна вартiсть: {cost}.");
            Console.WriteLine();
            return cost;
        }
        static double Floor(double floorArea)
        {
            Console.Write(" Введiть площу матерiалу в упаковкцi у квадратних метрах: ");
            double ploshchaNaUpakovku = double.Parse(Console.ReadLine());

            double packsNeeded = AllNeeds(floorArea, ploshchaNaUpakovku); ;

            Console.Write(" Цiна за 1 упаковку:");
            double packsCost = double.Parse(Console.ReadLine());

            double cost = Cost(packsCost, packsNeeded);

            Console.WriteLine();
            Console.WriteLine($" Для покриття цього примiщення потрiбно " +
                $"приблизно {packsNeeded} упаковок матерiалу. " +
                $"\n Загальна вартiсть: {cost}.");
            Console.WriteLine();
            return cost;
        }
    }
}


/*static double StretchCeiling(double CellingArea)
{
    Console.WriteLine("Оформлення стелі - натяжна стеля.");

    Console.Write("Введіть вартість за 1 кв. метр:");
    double costCelling = double.Parse(Console.ReadLine());
    double cost = Cost(costCelling, CellingArea);

    Console.WriteLine();
    Console.WriteLine($"Загальна вартість: {cost}.");
    Console.WriteLine();
    return cost;
}*/
/*
}*/