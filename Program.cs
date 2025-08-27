using System;
using System.IO;
using System.IO.Pipes;
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
// 1. Записать структуру в текстовый файл -
// 2. Прочитать структуру из текстового файла +
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

   internal class Program
   {
      static void Main(string[] args)
      {
         string fileEnter = "spisok.txt";
         string pathStruct = Path.GetFullPath(fileEnter);
         string writeStruct = "writestruct.bin";
         string pathWrite = Path.GetFullPath(writeStruct);
         string readStruct = "readstruct.bin";
         string pathRead = Path.GetFullPath(readStruct);
         string fileInput = "finish.txt";

         // Создание массива структур
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

         // Запись массива структур в текстовый файл
         WriteStructFile(pathStruct, people);

         // Чтение массива структур из текстового файла
         Student[] read = MethodsForStruct.ReadStructFile(pathStruct, "spisok.txt");
         // Вывод прочитанных данных
         Console.WriteLine("Прочитанные данные:");
         int i = 0;
         while (i < read.Length)
         {
            Student readTwo = read[i];
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}",
               readTwo.Group, readTwo.Surname, readTwo.Name, readTwo.Dadsname, readTwo.Year,
               readTwo.Gender, readTwo.Physics, readTwo.Math, readTwo.Inf, readTwo.Grant);
            i++;
         }

         // Преобразование массива структур в массив байт и запись в бинарный файл
         WriteStructArrayToFile(people, pathWrite);

         // Способ 1: Ручное чтение
         Student[] points1 = ReadArrayFromFile(pathWrite);
         Console.WriteLine($"Прочитано {points1.Length} точек");

         Console.ReadKey();
      }

      // Метод чтения массива структур из бинарного файла
      public static Student[] ReadArrayFromFile(string filePath)
      {
         FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
         BinaryReader reader = new BinaryReader(stream, Encoding.UTF8);
         // Читаем количество элементов
         int count = reader.ReadInt32();

         // Read the bytes that make up the string
         byte[] stringBytes = reader.ReadBytes(count);
         // Convert the bytes to a string using the appropriate encoding
         string result = Encoding.UTF8.GetString(stringBytes);

         // Создаем массив
         Student[] array = new Student[stringBytes.Length];
         // Читаем каждый элемент
         for (int i = 0; i < stringBytes.Length; i++)
         {
            array[i] = new Student
            {
               Group = reader.ReadString(),
               Surname = reader.ReadString(),
               Name = reader.ReadString(),
               Dadsname = reader.ReadString(),
               Year = reader.ReadInt32(),
               Gender = reader.ReadChar(),
               Physics = reader.ReadInt32(),
               Math = reader.ReadInt32(),
               Inf = reader.ReadInt32(),
               Grant = reader.ReadDouble()
            };
         }
         reader.Close();
         stream.Close();

         return array;
      }

      // Преобразование массива структур в массив байт и запись в бинарный файл
      static void WriteStructArrayToFile(Student[] structArray, string path)
      {
         FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
         BinaryWriter binaryWriter = new BinaryWriter(fileStream, Encoding.UTF8);
         int i = 0;
         while (i < structArray.Length)
         {
            Student item = structArray[i];
            binaryWriter.Write(item.Group);
            binaryWriter.Write(item.Surname);
            binaryWriter.Write(item.Name);
            binaryWriter.Write(item.Dadsname);
            binaryWriter.Write(item.Year);
            binaryWriter.Write(item.Gender);
            binaryWriter.Write(item.Physics);
            binaryWriter.Write(item.Math);
            binaryWriter.Write(item.Inf);
            binaryWriter.Write(item.Grant);

            i++;
         }

         binaryWriter.Close();
         fileStream.Close();
      }

      // Метод записи массива структур в текстовый файл
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