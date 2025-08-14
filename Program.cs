using System;
using System.IO;
using System.Text;

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

   struct Toy
   {
      public string Name;
      public int Price;
      public int AgeMin;
      public int AgeMax;
   }

   internal class Program
   {
      public static Toy[] ReadFile(string fileName)
      {

         string[] lines = File.ReadAllLines(fileName, Encoding.Default);
         Toy[] toys = new Toy[lines.Length];
         int i = 0;
         for (int index = 0; index < lines.Length; index++)
         {
            string s = lines[index];
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
         for (int i = 0; i < toys.Length; i++)
         {
            Toy toy = toys[i];
            Console.WriteLine(
               $"Наименование: {toy.Name}\tСтоимость: {toy.Price} руб.\tВозрастные ограничения: от {toy.AgeMin} до {toy.AgeMax} лет");
         }
      }

      static void Main(string[] args)
      {
         //Console.OutputEncoding = Encoding.UTF8;
         //string inputFile = "input.txt";
         //Toy[] toys = ReadFile(inputFile);
         //// Выводим исходный массив игрушек
         //Console.WriteLine("--------Исходный массив--------");
         //Display(toys);
         //Console.WriteLine("-------------------------------");

          // Путь к файлу
         //string path = "note.txt";
         // Путь к файлу
         string path = "input.txt";
         // Строка для записи
         string text = "Самолет"; 

         // запись в файл
         using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
         {
            // преобразуем строку в байты
            byte[] buffer = Encoding.Default.GetBytes(text);
            // запись массива байтов в файл
            fstream.WriteAsync(buffer, 0, buffer.Length);
            Console.WriteLine("Текст записан в файл");
         }

         // чтение из файла
         using (FileStream fstream = File.OpenRead(path))
         {
            // выделяем массив для считывания данных из файла
            byte[] buffer = new byte[fstream.Length];
            // считываем данные
            fstream.ReadAsync(buffer, 0, buffer.Length);
            // декодируем байты в строку
            string textFromFile = Encoding.Default.GetString(buffer);
            Console.WriteLine($"Текст из файла: {textFromFile}");
         }
      }
   }
}