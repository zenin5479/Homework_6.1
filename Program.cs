using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

   struct State
   {
      public string Name;
      public double Population;
      public int Area;
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
         string inputFile = "input.txt";
         Toy[] toys = ReadFile(inputFile);
         // Выводим исходный массив игрушек
         Console.WriteLine("--------Исходный массив--------");
         Display(toys);
         Console.WriteLine("-------------------------------");


         // Запись файла
         // Создаем массив структур
         State[] states =
         {
            new State { Name = "Россия", Area = 48, Population = 144.915908 },
            new State { Name = "Белоруссия", Area = 6, Population = 9.155978 }
         };

         // Октрываем файл для записи - сопоставляем его с ключем 1
         //FileSystem.FileOpen(1, "States.bin", OpenMode.Random);
         FileSystem.FileOpen(1, "States.txt", OpenMode.Input);
         for (int i = 0; i < states.Length; i++)
         {
            // Записываем в файл одну структуру
            FileSystem.FilePut(1, states[i]);
         }

         // Перематываем файл на начало для последующего чтения, поскольку после записи указатель
         // находится в конце файла. Но мы могли бы также просто закрыть файл и просто открыть.
         FileSystem.Seek(1, 1);

         // Чтение файла
         // Список, в который заносим значения из файла
         List<State> newStates = new List<State>();

         // Пока не обнаружен конец файла,читаем его
         while (!(FileSystem.EOF(1)))
         {
            // Создаем новую структуру
            ValueType tempState = new State();
            // Заносим в нее данные
            FileSystem.FileGet(1, ref tempState);
            //Добавляем ее в список
            newStates.Add((State)tempState);
         }

         // Закрываем файл
         FileSystem.FileClose(1);
         // Выводим содержимое списка на экран
         foreach (State s in newStates)
         {
            Console.WriteLine("Название страны: {0}; Областей: {1}; Население: {2}.", s.Name, s.Area, s.Population);
         }
      }
   }
}