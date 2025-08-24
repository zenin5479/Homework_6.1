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
// Найти несовершеннолетнего студента с худшим средним баллом 6.1
// 1. Записать структуру в текстовый файл +
// 2. Прочитать структуру из текстового файла -
// 3. Записать структуру в бинарный файл -
// 4. Прочитать структуру из бинарного файла -
// 5. Провести расчеты -
// 6. Записать в структуру в текстовый файл +
// 7. Записать в структуру в в бинарный файл -

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
   }

   // Простая структура с разными типами данных
   public struct Employee
   {
      public int Id;
      public string Name;
      public double Salary;
      public DateTime HireDate;
      public bool IsActive;
      public byte DepartmentId;
   }

   internal class Program
   {
      static void Main(string[] args)
      {
         string fileEnter = "spisok.txt";
         string pathStruct = Path.GetFullPath(fileEnter);
         string writeStruct = "writestruct.bin";
         string pathWrite = Path.GetFullPath(writeStruct);

         string readStruct = "readstruct.bin";
         string fileInput = "finish.txt";

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
         WriteStructFile(pathStruct, people);

         // Чтение структур из файла
         Student[] read = MethodsForStruct.ReadStructFile(pathStruct, "spisok.txt");
         // Вывод прочитанных данных
         Console.WriteLine("Прочитанные данные:");
         int i = 0;
         while (i < read.Length)
         {
            Student personTwo = read[i];
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}",
               personTwo.Group, personTwo.Surname, personTwo.Name, personTwo.Dadsname, personTwo.Year,
               personTwo.Gender, personTwo.Physics, personTwo.Math, personTwo.Inf, personTwo.Grant);
            i++;
         }

         // Создаем экземпляр структуры
         Employee employee = new Employee
         {
            Id = 12345,
            Name = "Дакота Джонсон",
            Salary = 125000.5787,
            HireDate = new DateTime(1989, 10, 4),
            IsActive = false,
            DepartmentId = 5
         };

         Console.WriteLine("Исходная структура:");
         PrintEmployee(employee);

         // Преобразуем структуру в массив байтов
         byte[] bytes = StructToBytes(employee);

         Console.WriteLine($"\nМассив байтов ({bytes.Length} байт):");
         Console.WriteLine(BitConverter.ToString(bytes));

         // Восстанавливаем структуру из байтов
         Employee restoredEmployee = BytesToStruct(bytes);

         Console.WriteLine("\nВосстановленная структура:");
         PrintEmployee(restoredEmployee);

         // Сохраняем в файл
         SaveToFile(employee, "employee.dat");

         // Загружаем из файла
         Employee fileEmployee = LoadFromFile("employee.dat");
         Console.WriteLine("\nЗагружено из файла:");
         PrintEmployee(fileEmployee);

         Console.ReadKey();
      }

      // Преобразование структуры в массив байтов
      public static byte[] StructToBytes(Employee employee)
      {
         using MemoryStream memoryStream = new MemoryStream();
         using BinaryWriter writer = new BinaryWriter(memoryStream, Encoding.UTF8);
         // Записываем все поля структуры по порядку
         writer.Write(employee.Id);
         writer.Write(employee.Name);
         writer.Write(employee.Salary);
         writer.Write(employee.HireDate.ToBinary());
         writer.Write(employee.IsActive);
         writer.Write(employee.DepartmentId);

         return memoryStream.ToArray();
      }

      // Преобразование массива байтов обратно в структуру
      public static Employee BytesToStruct(byte[] bytes)
      {
         using MemoryStream memoryStream = new MemoryStream(bytes);
         using BinaryReader reader = new BinaryReader(memoryStream, Encoding.UTF8);
         Employee employee = new Employee();
         // Читаем все поля структуры по порядку
         employee.Id = reader.ReadInt32();
         employee.Name = reader.ReadString();
         employee.Salary = reader.ReadDouble();
         employee.HireDate = DateTime.FromBinary(reader.ReadInt64());
         employee.IsActive = reader.ReadBoolean();
         employee.DepartmentId = reader.ReadByte();

         return employee;
      }

      static void PrintEmployee(Employee emp)
      {
         Console.WriteLine($"ID: {emp.Id}");
         Console.WriteLine($"Name: {emp.Name}");
         Console.WriteLine($"Salary: {emp.Salary}");
         Console.WriteLine($"HireDate: {emp.HireDate:yyyy-MM-dd}");
         Console.WriteLine($"IsActive: {emp.IsActive}");
         Console.WriteLine($"Department: {emp.DepartmentId}");
      }

      static void SaveToFile(Employee employee, string filename)
      {
         byte[] bytes = StructToBytes(employee);
         File.WriteAllBytes(filename, bytes);
         Console.WriteLine($"\nСохранено в файл: {filename}");
      }

      static Employee LoadFromFile(string filename)
      {
         byte[] bytes = File.ReadAllBytes(filename);
         return BytesToStruct(bytes);
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
   }
}