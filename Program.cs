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
// Найти несовершеннолетнего студента с худшим средним баллом

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
         Student[] students =
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
               Year = 2008, Gender = 'Ж', Physics = 3, Math = 3, Inf = 3, Grant = 3000
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
               Year = 2008, Gender = 'M', Physics = 3, Math = 2, Inf = 3, Grant = 2500
            },
            new Student
            {
               Group = "IP-22", Surname = "Сергеева", Name = "Дарья", Dadsname = "Викторовна",
               Year = 2008, Gender = 'Ж', Physics = 2, Math = 2, Inf = 2, Grant = 2000
            }
         };
         // Запись массива структур в текстовый файл
         MethodsForStruct.WriteStructFileTxt(pathStruct, students);
         // Чтение массива структур из текстового файла
         Student[] readStudents = MethodsForStruct.ReadStructFileTxt(pathStruct, "spisok.txt");
         // Вывод прочитанных данных
         Console.WriteLine("Прочитанные данные:");
         int i = 0;
         while (i < readStudents.Length)
         {
            Student student = readStudents[i];
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}",
               student.Group, student.Surname, student.Name, student.Dadsname, student.Year,
               student.Gender, student.Physics, student.Math, student.Inf, student.Grant);
            i++;
         }

         Console.WriteLine();
         // Запись массива структур в бинарный файл
         MethodsForStruct.WriteStructFileBin(pathWrite, readStudents);
         // Чтение массива структур из бинарного файла
         Student[] readCadets = MethodsForStruct.ReadStructFileBin(pathWrite);
         // Вывод прочитанных данных
         Console.WriteLine("Прочитанные данные:");
         int j = 0;
         while (j < readCadets.Length)
         {
            Student cadet = readCadets[j];
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}",
               cadet.Group, cadet.Surname, cadet.Name, cadet.Dadsname, cadet.Year,
               cadet.Gender, cadet.Physics, cadet.Math, cadet.Inf, cadet.Grant);
            j++;
         }

         Console.WriteLine();
         double average = AverageScore(students);

         Console.WriteLine();
         AverageHigherScore(pathRead, students, average);

         Console.WriteLine();
         MinorStudentWorstAverage(fileInput, students);

         Console.ReadKey();
      }

      // Метод поиска несовершеннолетнего студента с худшим средним баллом
      static void MinorStudentWorstAverage(string path, Student[] student)
      {
         Console.WriteLine("Несовершеннолетние студенты:");
         // Возраст совершеннолетнего студента
         int underage = 18;
         int currentDate = DateTime.Now.Year;
         // Определяем количество студентов удовлетворяющих условию для расчета размера массива структур
         int count = 0;
         int i = 0;
         while (i < student.Length)
         {
            int minorStudent = (currentDate - student[i].Year);
            if (minorStudent < underage)
            {
               count++;
            }

            i++;
         }

         Student[] minor = new Student[count];
         int j = 0;
         int k = 0;
         while (j < student.Length)
         {
            int minorStudent = (currentDate - student[j].Year);
            if (minorStudent < underage)
            {
               minor[k] = student[j];
               Console.WriteLine("{0} {1} {2} {3}",
                  student[j].Group, student[j].Surname, student[j].Name, student[j].Dadsname);
               k++;
            }

            j++;
         }

         // Рассчитываем средний балл несовершеннолетних студентов для добавления в массив структур и расчета худшего среднего балла
         int l = 0;
         double[] average = new double[count];
         double bySubjects;
         while (l < minor.Length)
         {
            bySubjects = ((minor[l].Physics + minor[l].Math + minor[l].Inf) / 3.0f);
            average[l] = bySubjects;
            l++;
         }

         // Cчитаем, что минимум - это первый элемент массива
         double min = average[0];
         int m = 0;
         while (m < average.Length)
         {
            if (min > average[m])
            {
               min = average[m];
            }

            m++;
         }

         Console.WriteLine("Минимум равен: {0:f}", min);
         //Console.WriteLine("Минимум равен: {0:f2}", min);

         // Поиск индекса минимума массива
         int n = 0;
         int counter = 0;
         bool flag = false;
         while (n < average.Length && flag == false)
         {
            // Сравниваем значения double используя метод CompareTo(Double) 
            if (average[n].CompareTo(min) == 0)
            {
               counter = n;
               flag = true;
            }

            // Сравниваем значения double используя метод Equals(Double)
            //if (average[n].Equals(min))
            //{
            //   counter = n;
            //   flag = true;
            //}

            n++;
         }

         if (flag)
         {
            Console.WriteLine("Индекс минимума равен: {0}", counter);
         }

         Console.WriteLine("Несовершеннолетний студент с худшим средним баллом:");
         Student worstAverage = minor[counter];
         Console.WriteLine("{0} {1} {2} {3}",
            worstAverage.Group, worstAverage.Surname, worstAverage.Name, worstAverage.Dadsname);

         // Запись структуры в текстовый файл
         FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Write);
         StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);
         writer.WriteLine("{0} {1} {2} {3}",
            worstAverage.Group, worstAverage.Surname, worstAverage.Name, worstAverage.Dadsname);
         writer.Close();
      }

      // Метод поиска студентов средний балл которых выше, чем общий средний балл
      static void AverageHigherScore(string path, Student[] student, double medium)
      {
         Console.WriteLine("Студенты, средний балл которых выше, чем общий средний балл:");
         // Определяем количество студентов удовлетворяющих условию для расчета размера массива структур
         int count = 0;
         int i = 0;
         while (i < student.Length)
         {
            double bySubjects = ((student[i].Physics + student[i].Math + student[i].Inf) / 3.0f);
            if (bySubjects > medium)
            {
               count++;
            }

            i++;
         }

         Student[] averageHigher = new Student[count];
         int j = 0;
         int k = 0;
         while (j < student.Length)
         {
            double bySubjects = ((student[j].Physics + student[j].Math + student[j].Inf) / 3.0f);
            if (bySubjects > medium)
            {
               averageHigher[k] = student[j];
               Console.WriteLine("{0} {1}", student[j].Surname, student[j].Name);
               k++;
            }

            j++;
         }

         // Запись массива структур в бинарный файл
         FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write);
         BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8);
         writer.Write(averageHigher.Length);
         int m = 0;
         while (m < averageHigher.Length)
         {
            // Запись строки в UTF-8 с предварительной длиной
            writer.Write(averageHigher[m].Surname);
            writer.Write(averageHigher[m].Name);
            m++;
         }

         stream.Close();
         writer.Close();
      }

      // Метод расчета среднего балла всех студентов по всем предметам
      static double AverageScore(Student[] students)
      {
         double medium;
         double allSubjects = 0;
         int i = 0;
         while (i < students.Length)
         {
            double bySubjects = ((students[i].Physics + students[i].Math + students[i].Inf) / 3.0f);
            allSubjects += bySubjects;
            //Console.WriteLine("Cредний балл: {0} {1} - {2:f2}",
            //   students[i].Surname, students[i].Name, bySubjects);
            Console.WriteLine("Cредний балл: {0} {1} - {2:f}",
               students[i].Surname, students[i].Name, bySubjects);
            //Console.WriteLine("Cредний балл: {0} {1} - {2}",
            //   students[i].Surname, students[i].Name, bySubjects);
            i++;
         }

         medium = allSubjects / students.Length;         
         Console.WriteLine("Средний балл всех студентов по всем предметам: {0:f}", medium);
         return medium;
      }
   }
}