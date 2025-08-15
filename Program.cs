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

   // Определяем структуру
   public struct Person
   {
      public int Id;
      public string Name;
      public int Age;
      public DateTime BirthDate;

      // Метод для преобразования структуры в строку
      public override string ToString()
      {
         return $"{Id}|{Name}|{Age}|{BirthDate:yyyy-MM-dd}";
      }

      // Метод для создания структуры из строки
      public static Person Parse(string line)
      {
         string[] parts = line.Split('|');
         if (parts.Length != 4)
         {
            throw new FormatException("Неверный формат строки");
         }

         return new Person
         {
            Id = int.Parse(parts[0]),
            Name = parts[1],
            Age = int.Parse(parts[2]),
            BirthDate = DateTime.ParseExact(parts[3], "yyyy-MM-dd", null)
         };
      }
   }

   internal class Program
   {
      static void Main(string[] args)
      {
         string filePath = "persons.txt";
         // Создаем массив структур для записи
         Person[] people =
         {
            new Person { Id = 1, Name = "Иванов Иван Иванович", Age = 30, BirthDate = new DateTime(1993, 5, 15) },
            new Person { Id = 2, Name = "Петрова Анна Сергеевна", Age = 25, BirthDate = new DateTime(1998, 10, 22) },
            new Person { Id = 3, Name = "Смирнов Алексей Викторович", Age = 40, BirthDate = new DateTime(1983, 3, 8) }
         };

         // Запись структур в файл
         WritePeopleToFile(filePath, people);

         // Чтение структур из файла
         Person[] readPeople = ReadPeopleFromFile(filePath);

         // Вывод прочитанных данных
         Console.WriteLine("Прочитанные данные:");
         foreach (var person in readPeople)
         {
            Console.WriteLine($"ID: {person.Id}, Ф.И.О.: {person.Name}, Возраст: {person.Age}, Дата рождения: {person.BirthDate:dd.MM.yyyy}");
         }

         Console.ReadKey();
      }

      // Метод для записи массива структур в файл
      static void WritePeopleToFile(string path, Person[] people)
      {
         using (StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8))
         {
            for (int i = 0; i < people.Length; i++)
            {
               Person person = people[i];
               writer.WriteLine(person.ToString());
            }
         }
      }

      // Метод для чтения массива структур из файла
      static Person[] ReadPeopleFromFile(string path)
      {
         List<Person> people = new List<Person>();
         using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
         {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
               if (!string.IsNullOrWhiteSpace(line))
               {
                  people.Add(Person.Parse(line));
               }
            }
         }

         return people.ToArray();
      }
   }
}