using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConverterLib;


namespace ConsoleAPI
{
    internal class Program
    {
        static void Main()
        {
            /// Создается неопр.тип для использования класса, методов
            Manager cm = new Manager();
            List<string> physicValues = cm.Get_list_physic_values();

            bool povtor = true;
            while (povtor)
            {
                try
                {
                    Console.Write("Введите число для конвертации: ");
                    double num = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine(Environment.NewLine + "Перед вами список с типом физ.величины. Выберите тип: ");

                    /// Перебор всех физ.величин
                    for (int i = 0; i < physicValues.Count; i++)
                    {
                        Console.WriteLine($" {i}) {physicValues[i]}");
                    }
                    Console.Write(Environment.NewLine + "Тип под номером: ");
                    int input_type = Convert.ToInt16(Console.ReadLine());

                    /// Создается неопр.тип для сохранения выбранной меры
                    var spisok_mer = cm.get_spisok_mer(physicValues[input_type]);

                    Console.WriteLine(Environment.NewLine + "Выберите измерение, из которого нужно конвертировать: ");
                    /// Перебор всех элементов из spisok_mer
                    for (int i = 0; i < spisok_mer.Count; i++)
                    {
                        Console.WriteLine($" {i}) {spisok_mer[i]}");
                    }
                    Console.Write(Environment.NewLine + "Введите номер из которого (Например: 1): ");
                    int fromIndex = Convert.ToInt16(Console.ReadLine());

                    Console.WriteLine(Environment.NewLine + "Выберите измерение, в которое нужно конвертировать: ");
                    /// Перебор всех элементов из spisok_mer
                    for (int i = 0; i < spisok_mer.Count; i++)
                    {
                        Console.WriteLine($" {i}) {spisok_mer[i]}");
                    }

                    Console.Write(Environment.NewLine + "Введите номер в которое: ");
                    int toIndex = Convert.ToInt16(Console.ReadLine());

                    Console.WriteLine(Environment.NewLine +
                        $"Результат конвертации: " +
                        $"{Convert.ToDouble(cm.Get_converted_value(num, physicValues[input_type], spisok_mer[fromIndex], spisok_mer[toIndex]))}");
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Повторить?" + Environment.NewLine + "Нажмите Enter...");
                    Console.Clear();
                }
            }
            Console.Read();
        }
    }
}
