﻿using System;
using System.Linq;

/* В задаче не использовать циклы for, while. Все действия по обработке данных выполнять с использованием LINQ
 * 
 * На вход подается строка, состоящая из целых чисел типа int, разделенных одним или несколькими пробелами.
 * Необходимо оставить только те элементы коллекции, которые предшествуют нулю, или все, если нуля нет.
 * Дважды вывести среднее арифметическое квадратов элементов новой последовательности.
 * Вывести элементы коллекции через пробел.
 * Остальные указания см. непосредственно в коде.
 * 
 * Пример входных данных:
 * 1 2 0 4 5
 * 
 * Пример выходных:
 * 2,500
 * 2,500
 * 1 2
 * 
 * Обрабатывайте возможные исключения путем вывода на экран типа этого исключения 
 * (не использовать GetType(), пишите тип руками).
 * Например, 
 *          catch (SomeException)
            {
                Console.WriteLine("SomeException");
            }
 * В случае возникновения иных нештатных ситуаций (например, в случае попытки итерирования по пустой коллекции) 
 * выбрасывайте InvalidOperationException!
 */
namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTesk02();
        }

        public static void RunTesk02()
        {
            int[] arr;
            try
            {
                // Попробуйте осуществить считывание целочисленного массива, записав это ОДНИМ ВЫРАЖЕНИЕМ.
                arr = (Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(u => int.Parse(u))).ToArray();
            }
            catch (FormatException)
            {
                Console.WriteLine("FormatException");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("OverflowException");
                return;
            }


            var filteredCollection = arr.TakeWhile(n => n != 0);
            
            try
            {
                if (filteredCollection.Count() == 0)
                    throw new InvalidOperationException();
                // использовать статическую форму вызова метода подсчета среднего
                double averageUsingStaticForm = (double)(from int a in filteredCollection
                                                 select a*a).Sum() / filteredCollection.Count();


                // использовать объектную форму вызова метода подсчета среднего
                double averageUsingInstanceForm = (double)filteredCollection.Sum(n => n*n) / filteredCollection.Count();

                if (averageUsingStaticForm > 15000000)
                {
                    throw new OverflowException();
                }
                if (averageUsingInstanceForm < -15000000)
                {
                    throw new OverflowException();
                }

                Console.WriteLine($"{averageUsingStaticForm:F3}".Replace('.', ','));
                Console.WriteLine($"{averageUsingInstanceForm:F3}".Replace('.', ','));
                // вывести элементы коллекции в одну строку
                filteredCollection.ToList().ForEach(x => Console.Write(@"{0} ", x));
            }
            catch (OverflowException)
            {
                Console.WriteLine("OverflowException");
                return;
            }

            catch (Exception)
            {
                Console.WriteLine("InvalidOperationException");
                return;
            }           

        }
        
    }
}
