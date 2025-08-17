using System;
using System.Collections.Generic;
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
   //struct Student
   //{
   //   char group;
   //   char surname;
   //   char name;
   //   char dadsname;
   //   int year;
   //   char gender;
   //   int physics;
   //   int math;
   //   int inf;
   //   float grant;
   //};

   // Определяем структуру
   public struct Student
   {
      public string Group;
      public string Surname;
      public string Name;
      public string Dadsname;

      // Метод для преобразования структуры в строку
      public override string ToString()
      {
         return $"{Group}|{Surname}|{Name}|{Dadsname}";
      }

      // Метод для создания структуры из строки
      public static Student Parse(string line)
      {
         string[] parts = line.Split('|');
         if (parts.Length != 4)
         {
            throw new FormatException("Неверный формат строки");
         }

         return new Student
         {
            Group = parts[0] ,
            Surname = parts[1],
            Name = parts[2],
            Dadsname = parts[3]
         };
      }
   }

   internal class Program
   {
      static void Main(string[] args)
      {
         string filePath = "persons.txt";
         // Создаем массив структур для записи
         Student[] people =
         {
            new Student { Group = "IP-21", Surname = "Иванов", Name = "Иван", Dadsname = "Иванович" },
            new Student { Group = "IP-21", Surname = "Петрова Анна Сергеевна", Name = "Анна", Dadsname = "Сергеевна" },
            new Student { Group = "IP-22", Surname = "Смирнов Алексей Викторович", Name = "Алексей", Dadsname = "Викторович" }
         };

         // Запись структур в файл
         WritePeopleToFile(filePath, people);
         // Чтение структур из файла
         Student[] readPeople = ReadPeopleFromFile(filePath);
         // Вывод прочитанных данных
         Console.WriteLine("Прочитанные данные:");
         foreach (var person in readPeople)
         {
            Console.WriteLine($"ID: {person.Group}, Ф.И.О.: {person.Surname}, Возраст: {person.Name}, Дата рождения: {person.Dadsname:dd.MM.yyyy}");
         }

         Console.ReadKey();
      }

      // Метод для записи массива структур в файл
      static void WritePeopleToFile(string path, Student[] people)
      {
         using (StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8))
         {
            for (int i = 0; i < people.Length; i++)
            {
               Student person = people[i];
               writer.WriteLine(person.ToString());
            }
         }
      }

      // Метод для чтения массива структур из файла
      static Student[] ReadPeopleFromFile(string path)
      {
         List<Student> people = new List<Student>();
         using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
         {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
               if (!string.IsNullOrWhiteSpace(line))
               {
                  people.Add(Student.Parse(line));
               }
            }
         }

         return people.ToArray();
      }
   }
}