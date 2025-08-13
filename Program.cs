using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

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

   public struct State
   {
      public string name;
      public int population;
      public double area;
   }

   internal class Program
   {
      static void Main(string[] args)
      {
         //---------------------------------------------------------
         // Запись файла

         // Создаем массив структур
         State[] states = new State[] { new State() { name = "Russia", population = 10, area = 30 },
            new State(){name = "Canada", population = 3, area = 10}};

         // Октрываем файл для записи - сопоставляем его с ключем 1
         FileSystem.FileOpen(1, "States.bin", OpenMode.Random);
         for (int i = 0; i < states.Length; i++)
         {
            // Записываем в файл одну структуру
            FileSystem.FilePut(1, states[i]);
         }

         // Перематываем файл на начало для последующего чтения, поскольку после записи указатель
         // находится в конце файла. Но мы могли бы также просто закрыть файл и просто открыть.
         FileSystem.Seek(1, 1);


         //---------------------------------------------------------
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
            Console.WriteLine("Name of the state: {0}, population : {1}", s.name, s.population);
         }
      }
   }
}