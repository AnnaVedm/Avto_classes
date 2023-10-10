namespace Классы_Анютка
{
    class Program
    {
        public static int cars_quantity = 3;
        static void Main(string[] args)
        {
            Avto car = new Avto();

            Avto[] cars
                = new Avto[cars_quantity];

            for (int i = 0; i < cars.Length; i++) //Заполнение инфы о каждой машине
            {
                cars[i] = new Avto();
                cars[i].Info();

                Console.Clear();

                cars[i].output();
                cars[i].ezda();
            }

            Console.Clear();
            for (int i = 0; i < cars.Length; i++) //Вывод каждой машины
            {
                Console.WriteLine($"Машина {i + 1}");
                cars[i].output();

                Console.WriteLine();
            }
            car.Avaria(cars_quantity);

            Console.ReadKey();
        }
    }
}
