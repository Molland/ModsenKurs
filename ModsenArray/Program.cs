using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsenArray
{
    internal class Program
    {
        static void Main()
        {
            int choice, num;

        ArrayDimensionalityCheck:

            Console.Write("Введите размерность массива: ");

            if (int.TryParse(Console.ReadLine(), out num))
            {
                int[] arr = new int[num];

                ArrayRandom(arr, num);

            ChoiseCheck:

                Menu();

                Console.Write("\nВыберите пункт меню: ");

                if (int.TryParse(Console.ReadLine(), out choice)) {}
                else
                {
                    Console.WriteLine("Введите переменную с типом int!");

                    Console.ReadKey();

                    Console.Clear();

                    goto ChoiseCheck;
                }

                OptionSelection(arr, choice);
            }
            else
            {
                Console.WriteLine("Введите переменную с типом int!");

                Console.ReadKey();

                Console.Clear();

                goto ArrayDimensionalityCheck;
            }  
        }
        static void ArrayRandom(int[] arr, int num)
        {
            int max;         

            Random rand = new Random();

            Console.Write("Предел значения элемента в массиве: ");

        LimitOfArrayValue:

            if (int.TryParse(Console.ReadLine(), out max)) {}
            else
            {
                Console.WriteLine("Введите переменную с типом int!");

                Console.ReadKey();

                Console.Clear();

                goto LimitOfArrayValue;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next() % max;
            }

            Console.Write("Элементы массива: ");

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }     

            Console.WriteLine("");
        }
        static void OptionSelection(int[] arr, int choice)
        {
            Choice:

            switch(choice)
            {
                case 1:
                {
                    int sum = 0;

                    for (int i = 0; i < arr.Length; i++ )
                    {
                        sum += arr[i];
                    }

                    Console.WriteLine("\nСумма всех элементов массива: " + sum);

                    Console.ReadKey();

                    goto Choice;
                }

                case 2:
                {
                    int max = arr.Min();

                    for (int i = 0; i < arr.Length; i++)
                    {
                            if (max < arr[i]) max = arr[i];
                    }

                    Console.WriteLine("\nМаксимальное значение элемента массива: " + max);

                    Console.ReadKey();

                    goto Choice;
                }
                case 3:
                {
                    int max = arr.Min();
                    int secMax = 0;

                    foreach (int num in arr)
                    {
                        if (num > max)
                        {
                            secMax = max;
                            max = num;
                        }
                        else if (num > secMax)
                        {
                            secMax = num;
                        }
                    }

                    Console.WriteLine("\nВторой по величине элемент массива: " + secMax);

                    Console.ReadKey();

                    goto Choice;
                }

                case 4:
                {
                    int unic = 0;
                    bool found = false;

                    for (int i = 0; i < arr.Length; i++)
                    {
                        found = false;

                        for (int j = 0; j < arr.Length; j++)
                        {
                            if (i != j && arr[i] == arr[j])
                            {
                                found = true;
                                break;
                            }
                        }
                        if (!found) unic++;
                    }

                    if (!found)
                    {
                        Console.WriteLine("\nПервый уникальный элемент массива: " + unic);
                    }
                    else
                    {
                        Console.WriteLine("\nУникальный элемент в массиве не найден");
                    }

                    Console.ReadKey();

                    goto Choice;
                }

                case 5:
                {
                    int unic = 0;
                    bool found = false;

                    for (int i = 0; i < arr.Length; i++)
                    {
                        found = false;

                        for (int j = 0; j < arr.Length; j++)
                        {
                            if (i != j && arr[i] == arr[j])
                            {
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            unic += arr[i];
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine("\nПервый уникальный элемент массива: " + unic);
                    }
                    else
                    {
                        Console.WriteLine("\nУникальный элемент в массиве не найден");
                    }

                    Console.ReadKey();

                    goto Choice;
                }

                case 6:
                {
                    int maxIndex = 0;
                    int minIndex = 0;

                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i] > arr[maxIndex])
                        {
                            maxIndex = i;
                        }

                        if (arr[i] < arr[minIndex])
                        {
                            minIndex = i;
                        }
                    }

                    int temp = arr[maxIndex];
                    arr[maxIndex] = arr[minIndex];
                    arr[minIndex] = temp;

                    Console.Write("Массив после обмена местами максимальных и минимальных по значению элементов: ");

                    for (int i = 0; i < arr.Length; i++)
                    {
                        Console.Write(arr[i] + " ");
                    }

                    Console.ReadKey();

                    goto Choice;
                }

                case 7:
                {
                    int temp = arr[0];
                    arr[0] = arr[arr.Length - 1];
                    arr[arr.Length - 1] = temp;
           
                    Console.Write("Массив после обмена местами первого и последнего элементов: ");

                    for (int i = 0; i < arr.Length; i++)
                    {
                        Console.Write(arr[i] + " ");
                    }

                    Console.ReadKey();

                    goto Choice;
                }

                case 8:
                {
                    Array.Sort(arr);

                    Console.Write("Массив после сортировки по возрастанию: ");

                    for (int i = 0; i < arr.Length; i++)
                    {
                        Console.Write(arr[i] + " ");
                    }

                    Console.ReadKey();

                    goto Choice;
                }

                case 9:
                {
                    Array.Sort(arr);
                    Array.Reverse(arr);

                    Console.Write("Массив после сортировки по убыванию: ");

                    for (int i = 0; i < arr.Length; i++)
                    {
                        Console.Write(arr[i] + " ");
                    }

                    Console.ReadKey();

                    goto Choice;
                }

                case 10:
                {
                    int first = 0;
                    int second = arr.Length - 1;
                    int[] result = new int[arr.Length];

                    foreach (int num in arr)
                    {
                        if (num % 2 == 0)
                        {
                            result[first] = num;
                            first++;
                        }
                        else
                        {
                            result[second] = num;
                            second--;
                        }
                    }

                    Console.WriteLine("Перемещенный массив:");

                    foreach (int num in result)
                    {
                        Console.Write(num + " ");
                    }

                    Console.ReadKey();

                    goto Choice;
                }

                case 11:
                {
                    Environment.Exit(0);

                    break;
                }

            }
        }

        static void Menu()
        {
            Console.WriteLine("\n1. Сумма всех элементов массива\n" +
                "2. Максимальное значение элемента массива\n" +
                "3. Значение второго по величине элемента массива\n" +
                "4. Количество уникальных элементов массива\n" +
                "5. Значение первого уникального элемента массива\n" +
                "6. Обмен местами максимальных и минимальных по значению элементов массива\n" +
                "7. Обмен местами первого и последнего значения элементов массива\n" +
                "8. Сортировка элементов массива по возрастанию\n" +
                "9. Сортировка элементов массива по убыванию\n" +
                "10. Вывод элементов массива. Сначала четные элементы, потом нечетные\n" +
                "11. Выйти из программы\n");
        }
    }
}
