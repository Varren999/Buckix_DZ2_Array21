//==================================================================================
// Array21. Дан массив размера N и целые числа K и L (1 <= K <= L <= N).
// Найти среднее арифметическое элементов массива с номерами от K до L включительно.
//==================================================================================
using System;
using System.Linq;

namespace Buckix_DZ2_Array21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int N = 0, K = 0, L = 0;
            int[] array;
            bool cycle = true;
            string[] message = { "Введите размерность массива: ", "Введите число K: ", "Введите число L: " };
            

            Console.WriteLine("Дан массив размера N и целые числа K и L (1 <= K <= L <= N).\nНайти среднее арифметическое элементов массива с номерами от K до L включительно.");
            // Цикл запроса данных от пользователя.
            while (cycle)
            {
                cycle = false;
                try
                {
                    N = InputText(message[0]);
                    K = InputText(message[1]);
                    L = InputText(message[2]);

                    if (!(1 < K && K < L && L < N))
                    {
                        cycle = true;
                        throw new Exception("Введеные вами числа не удовлетворяют условие (1 <= K <= L <= N), Повторите ввод");
                    }
                }
                catch(Exception ex) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
            }
            // Создаем массив
            array = new int[N];
            // Заполняем его рандомными числами.
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(1, 100);
            }

            Console.WriteLine("Массив: " + string.Join(" ", array));

            // Чтобы не изобретать колесо, можно воспользоваться уже существующими методами. Из нужной части основного массива сделаем копию.
            // И у этой копии найдем средее арифметическое.
            int[] average = new int[L - K + 1];
            Array.Copy(array, K, average, 0, average.Length);
            Console.WriteLine("Массив: " + string.Join(" ", average));
            Console.WriteLine("Среднее арифметическое: " + average.Average());
            // Или так.
            int sum = 0;
            for (int i = K; i <= L; i++)
            {
                sum += array[i];
            }
            Console.WriteLine("Среднее арифметическое: " + ((double)sum / (L - K + 1)));
        }

        static int InputText(string msg)
        {
            int a = 0;
            bool cycle = true;
            while (cycle)
            {
                try
                {
                    Console.Write(msg);
                    a = Convert.ToInt32(Console.ReadLine());
                    if (a > 0)
                        cycle = false;
                    else
                        throw new Exception("Введеное число не может быть меньше 1.");
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
            }
            return a;
        }
    }
}
