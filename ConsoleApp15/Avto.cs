using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Классы_Анютка
{
    class Avto
    {
        private string car_number;
        private double benzin_bak; //Максимальный объем бака
        private double now_in_bak;
        private double rashod;
        private double distance;
        private double V;
        private double probeg;
        private double x2;
        private double y2;
        private double S; //Расстояние по координатам
        private double X = 3; //1 единица по оси X равна 3 километрам
        private double proiden_distance = 0;

        public void Info()
        {
            Console.Write("Введите номер машины: ");
            car_number = Console.ReadLine();

            Console.Write("Введите объем бака: ");
            benzin_bak = Convert.ToSingle(Console.ReadLine());

            Console.Write("Введите расход бака: ");
            rashod = Convert.ToSingle(Console.ReadLine());

            Console.Write("Введите пробег автомобиля: ");
            probeg = Convert.ToSingle(Console.ReadLine());

            Random rnd = new Random();
            distance = rnd.Next(1, 3000);
            V = rnd.Next(10, 300);
        }
        public void output()
        {
            Console.WriteLine("ИНФОРМАЦИЯ О МАШИНЕ: \n");
            Console.WriteLine($"Номер машины: {car_number}\nОбъем бака: {benzin_bak}\nРасход бака: {rashod}");
            Console.WriteLine($"Расстояние, которое нужно преодолеть: {distance} км");
            Console.WriteLine($"Ваша скорость : {V} км/ч");
            Console.WriteLine($"Ваш пробег: {probeg} км");

            Random rnd = new Random();
            now_in_bak = rnd.Next(10, Convert.ToInt32(benzin_bak));

            Console.ReadKey();
        }
        public void ezda()
        {
            Console.Clear();
            int kilometers_quantity = Convert.ToInt32(((now_in_bak / rashod)) * 100 - 100); //Сколько километров можно проехать
            int necessary_add_in_a_bak = Convert.ToInt32((distance * rashod) / 100 - now_in_bak); //Объем бака с запасом на 100км
            int ostatok_benzina = Convert.ToInt32((kilometers_quantity * rashod) / 100);

            if (distance <= kilometers_quantity)
            {
                Console.WriteLine($"При объеме бака в {now_in_bak} литров, вы сможете проехать {kilometers_quantity} км");

                Console.Write("Нажмите Enter, чтобы начать поездку: ");
                Console.ReadKey();
                Console.Clear();

                string move = "Едем...";

                for (int j = 0; j < 3; j++) //Сообщение о езде
                {
                    for (int i = 0; i < move.Length; i++)
                    {
                        Console.Write(move[i]);
                        Thread.Sleep(200);
                    }
                    Console.Clear();
                }
                //Обновление данных после езды
                kilometers_quantity = Convert.ToInt32(distance);
                now_in_bak = now_in_bak - ostatok_benzina;
                proiden_distance += distance;
                probeg_distance(distance);
            }

            else
            {
                while (proiden_distance < distance) //Пройденное расстояние меньше нужного расстояния
                {
                    kilometers_quantity = Convert.ToInt32(((now_in_bak / rashod)) * 100 - 100);
                    ostatok_benzina = Convert.ToInt32((kilometers_quantity * rashod) / 100);

                    Console.WriteLine($"Вы сможете проехать {kilometers_quantity} км");
                    Console.WriteLine($"По окончании поездки в баке останется {now_in_bak - ostatok_benzina} л");

                    Console.WriteLine();

                    Console.Write("Нажмите Enter, чтобы начать поездку: ");
                    Console.ReadKey();
                    Console.Clear();

                    string move = "Едем...";

                    for (int j = 0; j < 3; j++) //Вывод сообщения о езде
                    {
                        for (int i = 0; i < move.Length; i++)
                        {
                            Console.Write(move[i]);
                            Thread.Sleep(200);
                        }
                        Console.Clear();
                    }

                    Console.WriteLine($"Вы движетесь со скоростью {V}");
                    Console.Write("Выберите действие:\n1.Разогнаться\n2.Притормозить\n3.Двигаться с текущей скоростью: ");
                    int user_choice = Convert.ToInt32(Console.ReadLine());

                    if (user_choice == 1)
                    {
                        gaz();
                    }
                    else if (user_choice == 2)
                    {
                        tormoz();
                    }
                    else
                    {
                        Console.WriteLine($"Вы выбрали оставить вашу текущую скорость - {V} км/ч");
                    }


                    now_in_bak = now_in_bak - ostatok_benzina; //Количество бензина в баке после поездки
                    proiden_distance += kilometers_quantity; //Пройденное расстояние
                    probeg_distance(kilometers_quantity);

                    Console.WriteLine($"Вы проехали {proiden_distance}/{distance} км");
                    koordinates(kilometers_quantity);

                    if (kilometers_quantity >= distance)
                    {
                        kilometers_quantity = Convert.ToInt32(distance);
                        break;
                    }
                    else if (now_in_bak <= rashod) //Почти доехали до координаты
                    {
                        Console.WriteLine("Ваше топливо почти закончилось!");
                        Console.WriteLine("Выберите действие: ");
                        Console.Write("1.Заправиться\n2.Не заправляться: ");

                        int choice = Convert.ToInt32(Console.ReadLine());
                        if (choice == 1) //Заправка
                        {
                            zapravka_car(kilometers_quantity, necessary_add_in_a_bak);
                        }
                        else
                        {
                            Console.WriteLine("Ваша поездка закончена. Вы посреди трассы!");
                            break;
                        }
                    }
                }
            }

            now_in_bak = now_in_bak - ostatok_benzina;

            Console.WriteLine($"Вы преодолели расстояние в {proiden_distance} км!");
            Console.WriteLine($"В баке осталось: {ostatok_benzina} л");
            Console.WriteLine($"Ваш пробег: {probeg}");
            Console.ReadKey();
            Console.Clear();
        }

        public void tormoz()
        {
            Random rnd = new Random();
            V -= rnd.Next(5, 20);

            Console.WriteLine($"\nВаша скорость уменьшилась, теперь она = {V} км/ч. Вы медленнее!");
        }

        public void gaz()
        {
            Random rnd = new Random();
            V += rnd.Next(5, 20);

            Console.WriteLine($"\nВаша скорость увеличилась, теперь она = {V} км/ч. Вы едете быстрее ветра!");
        }

        public void zapravka_car(double kilometers_quantity, double necessary_add_in_a_bak)
        {
            Console.WriteLine($"Для заправки до полного бака вам нужно залить {benzin_bak - now_in_bak}");

            Console.WriteLine();

            Console.Write("Введите количество бензина, которое хотите залить: ");
            int zalit_benzin = Convert.ToInt32(Console.ReadLine());
            now_in_bak += zalit_benzin;

            Console.WriteLine();

            Console.WriteLine($"В вашем баке теперь {now_in_bak}");
        }

        public void probeg_distance(double kilometers_quantity)
        {
            probeg = probeg + kilometers_quantity; // Расчёт общего пробега с учётом пройденного расстояния
            Console.Write($"Теперь пробег машины после пройденного расстояния равен: {probeg}");
            Console.WriteLine();
            Console.ReadKey();
            Console.Clear();
        }

        public void Avaria(int cars_quantity) // Вывод в конце программы. Аварии с учётом участвующих машин
        {
            Random rand = new Random();
            int i = rand.Next(0, cars_quantity);
            int j = rand.Next(0, cars_quantity);

            if (i != j)
            {
                Console.WriteLine($"Машины {i},{j} попали в аварию!");
            }
            else
            {
                Console.WriteLine("За сегодня аварий не было!");
            }
        }

        public void koordinates(int kilometers_quantity) //Ввод координат и рассчитываем расстояние
        {
            S = S + Math.Sqrt(Math.Pow(kilometers_quantity * 3, 2));

            Console.WriteLine($"Расстояние между начальной и конечной точками равно {S} пунктов");
        }
    }
}
