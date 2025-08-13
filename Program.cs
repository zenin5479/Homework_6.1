using System;
using System.IO;

// Обработка студенческой ведомости
// Составить программу для обработки информации о студентах какого-то факультета
// Каждый студент характеризуется совокупностью признаков: группа; фамилия, имя, отчество; год рождения; пол; оценка по физике; оценка по математике; оценка по информатике; стипендия
// Выбор типа исходных и выходных данных зависит от языка программирования
// Можно рассмотреть вариант, соответствующий объекту: структура
// Кроме того, рассмотреть разные способы ввода/вывода: с клавиатуры/на экран, с использованием файлов (текстовых, типизированных, бинарных)
// При работе с файлами первая программа создаёт файл, а вторая его обрабатывает
// Программы следует писать при условии, что файл целиком во внутреннюю память разместить невозможно
// При решении можно использовать стандартные классы
// Вычислить средний балл всех студентов по всем предметам
// Вывести фамилии и имена студентов, средний балл которых больше, чем общий средний балл

namespace Homework_6._1
{
   struct Student
   {
      char group;
      char surname;
      char name;
      char dadsname;
      int year;
      char gender;
      int physics;
      int math;
      int inf;
      float grant;
   };

   /// <summary>
   /// Структура, содержащая полную информацию об игрушке
   /// </summary>
   public struct Toy
   {
      public string Name { get; set; }
      public int Price { get; set; }
      public int AgeMin { get; set; }
      public int AgeMax { get; set; }

      public override string ToString()
      {
         return $"{Name};{Price};{AgeMin};{AgeMax}";
      }
   }

   internal class Program
   {
      public static void WriteFile(string fileName, Toy[] toys)
      {
         using (StreamWriter sw = new StreamWriter(fileName))
         {
            foreach (Toy toy in toys)
            {
               sw.WriteLine(toy.ToString());
            }
         }
      }

      public static Toy[] ReadFile(string fileName)
      {
         string[] lines = File.ReadAllLines(fileName);
         Toy[] toys = new Toy[lines.Length];
         int i = 0;
         foreach (string s in lines)
         {
            string[] toyFields = s.Split(new[] { ';' });
            toys[i].Name = toyFields[0];
            toys[i].Price = Convert.ToInt32(toyFields[1]);
            toys[i].AgeMin = Convert.ToInt32(toyFields[2]);
            toys[i].AgeMax = Convert.ToInt32(toyFields[3]);
            i++;
         }
         return toys;
      }
      public static void Display(Toy[] toys)
      {
         foreach (Toy toy in toys)
         {
            Console.WriteLine($"Наименование: {toy.Name}\tСтоимость: {toy.Price} руб.\tВозрастные ограницения: от {toy.AgeMin} до {toy.AgeMax} лет");
         }
      }

      static void Main(string[] args)
      {
         string inputFile = "input.txt";
         string outputFile = "output.txt";
         Toy[] toys = ReadFile(inputFile);
         //выводим исходный массив игрушек
         Console.WriteLine("--------Исходный массив--------");
         Display(toys);
         Console.WriteLine("-------------------------------");
      }
   }
}