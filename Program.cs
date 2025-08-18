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
   // Определяем структуру
   public struct Student
   {
      public string Group;
      public string Surname;
      public string Name;
      public string Dadsname;
      public int Year;
      public char Gender;
      public int Physics;
      public int Math;
      public int Inf;
      public double Grant;

      // Метод для преобразования структуры в строку
      public override string ToString()
      {
         return string.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}",
            Group, Surname, Name, Dadsname, Year, Gender, Physics, Math, Inf, Grant);
      }

      // Метод для создания структуры из строки
      public static Student Parse(string line)
      {
         string[] parts = line.Split(' ');
         if (parts.Length != 10)
         {
            Console.WriteLine("Неверный формат строки");
         }

         return new Student
         {
            Group = parts[0],
            Surname = parts[1],
            Name = parts[2],
            Dadsname = parts[3],
            Year = int.Parse(parts[4]),
            Gender = char.Parse(parts[5]),
            Physics = int.Parse(parts[6]),
            Math = int.Parse(parts[7]),
            Inf = int.Parse(parts[8]),
            Grant = double.Parse(parts[9])
            //Year = Convert.ToInt32(parts[4]),
            //Gender = Convert.ToChar(parts[5]),
            //Physics = Convert.ToInt32(parts[6]),
            //Math = Convert.ToInt32(parts[7]),
            //Inf = Convert.ToInt32(parts[8]),
            //Grant = Convert.ToDouble(parts[9])
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
            new Student
            {
               Group = "IP-21", Surname = "Иванов", Name = "Иван", Dadsname = "Иванович",
               Year = 2000, Gender = 'М', Physics = 4, Math = 5, Inf = 3, Grant = 5000
            },
            new Student
            {
               Group = "IP-21", Surname = "Петрова", Name = "Анна", Dadsname = "Сергеевна",
               Year = 2001, Gender = 'Ж', Physics = 5, Math = 4, Inf = 5, Grant = 6000
            },
            new Student
            {
               Group = "IP-22", Surname = "Смирнов", Name = "Алексей", Dadsname = "Викторович",
               Year = 1999, Gender = 'M', Physics = 3, Math = 4, Inf = 4, Grant = 4000
            },
            new Student
            {
               Group = "Fiz-21", Surname = "Кузнецова", Name = "Мария", Dadsname = "Павловна",
               Year = 2000, Gender = 'Ж', Physics = 5, Math = 5, Inf = 5, Grant = 7000
            },
            new Student
            {
               Group = "Phys-22", Surname = "Сидоров", Name = "Дмитрий", Dadsname = "Андреевич",
               Year = 2001, Gender = 'M', Physics = 4, Math = 3, Inf = 4, Grant = 4500
            },
            new Student
            {
               Group = "IP-22", Surname = "Васильева", Name = "Екатерина", Dadsname = "Николаевна",
               Year = 2009, Gender = 'Ж', Physics = 3, Math = 5, Inf = 4, Grant = 5500
            },
            new Student
            {
               Group = "Fiz-21", Surname = "Орлов", Name = "Сергей", Dadsname = "Владимирович",
               Year = 2000, Gender = 'M', Physics = 4, Math = 4, Inf = 3, Grant = 3000
            },
            new Student
            {
               Group = "IP-21", Surname = "Лебедева", Name = "Светлана", Dadsname = "Александровна",
               Year = 2001, Gender = 'Ж', Physics = 5, Math = 5, Inf = 5, Grant = 8000
            },
            new Student
            {
               Group = "Fiz-22", Surname = "Николаев", Name = "Андрей", Dadsname = "Сергеевич",
               Year = 2007, Gender = 'M', Physics = 3, Math = 2, Inf = 3, Grant = 2500
            },
            new Student
            {
               Group = "IP-22", Surname = "Сергеева", Name = "Дарья", Dadsname = "Викторовна",
               Year = 2007, Gender = 'Ж', Physics = 2, Math = 2, Inf = 2, Grant = 5000
            },
         };

         // Запись структур в файл
         WriteStructFile(filePath, people);
         // Чтение структур из файла
         Student[] readPeople = ReadStructFile(filePath);
         // Вывод прочитанных данных
         Console.WriteLine("Прочитанные данные:");
         foreach (var person in readPeople)
         {
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}",
               person.Group, person.Surname, person.Name, person.Dadsname, person.Year,
               person.Gender, person.Physics, person.Math, person.Inf, person.Grant);
         }

         Console.ReadKey();
      }

      // Метод для записи массива структур в файл
      static void WriteStructFile(string path, Student[] people)
      {
         using (StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8))
         {
            for (int i = 0; i < people.Length; i++)
            {
               Student person = people[i];
               writer.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}",
                  person.Group, person.Surname, person.Name, person.Dadsname, person.Year,
                  person.Gender, person.Physics, person.Math, person.Inf, person.Grant);
            }
         }
      }

      // Метод для чтения массива структур из файла
      static Student[] ReadStructFile(string path)
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