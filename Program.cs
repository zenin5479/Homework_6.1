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
      //public char Group;
      //public char Surname;
      public char[] Group;
      public string Surname;
      public int Age;
      public DateTime BirthDate;

      // Метод для преобразования структуры в строку
      public override string ToString()
      {
         return $"{Group}|{Surname}|{Age}|{BirthDate:yyyy-MM-dd}";
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
            Group = new[] { char.Parse(parts[0]) },
            Surname = parts[1],
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
         Student[] people =
         {
            new Student { Group = new  char[] {'l', '5'"ip-22"}, Surname = "Иванов Иван Иванович", Age = 30, BirthDate = new DateTime(1993, 5, 15) },
            new Student { Group = 2, Surname = "Петрова Анна Сергеевна", Age = 25, BirthDate = new DateTime(1998, 10, 22) },
            new Student { Group = 3, Surname = "Смирнов Алексей Викторович", Age = 40, BirthDate = new DateTime(1983, 3, 8) }
         };

         // Запись структур в файл
         WritePeopleToFile(filePath, people);
         // Чтение структур из файла
         Student[] readPeople = ReadPeopleFromFile(filePath);
         // Вывод прочитанных данных
         Console.WriteLine("Прочитанные данные:");
         foreach (var person in readPeople)
         {
            Console.WriteLine($"ID: {person.Group}, Ф.И.О.: {person.Surname}, Возраст: {person.Age}, Дата рождения: {person.BirthDate:dd.MM.yyyy}");
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