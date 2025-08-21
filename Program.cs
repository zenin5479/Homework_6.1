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
   }

   internal class Program
   {
      static void Main(string[] args)
      {
         string filePath = "spisok.txt";
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
         for (int i = 0; i < readPeople.Length; i++)
         {
            Student person = readPeople[i];
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}",
               person.Group, person.Surname, person.Name, person.Dadsname, person.Year,
               person.Gender, person.Physics, person.Math, person.Inf, person.Grant);
         }

         Console.ReadKey();
      }

      public static Student[] Enter2DArrayDouble(string path, string nameFile)
      {
         // Чтение файла за одну операцию
         string[] allLines = File.ReadAllLines(path);
         Student[] arrayStudent = { };
         if (allLines == null || allLines.Length == 0)
         {
            Console.WriteLine("Ошибка содержимого файла для чтения {0}", nameFile);
            //Console.WriteLine("Ошибка содержимого файла для чтения {0}. Файл пуст", nameFile);
         }
         else
         {
            // Разделение строки на подстроки по пробелу для определения количества столбцов в строке
            arrayStudent = new Student[allLines.Length];
            int[] sizeArray = new int[allLines.Length];
            char symbolSpace = ' ';
            int countRow = 0;
            int countSymbol = 0;
            int countСolumn = 0;
            while (countRow < allLines.Length)
            {
               string line = allLines[countRow];
               while (countSymbol < line.Length)
               {
                  if (symbolSpace == line[countSymbol])
                  {
                     countСolumn++;
                  }

                  if (countSymbol == line.Length - 1)
                  {
                     countСolumn++;
                  }

                  countSymbol++;
               }

               sizeArray[countRow] = countСolumn;
               // 10 количество полей в структуре
               if (countСolumn != 10)
               {
                  Console.WriteLine("Неверный формат строки {0}", countRow);
               }
               countСolumn = 0;
               countRow++;
               countSymbol = 0;
            }


            // Поиск максимального и минимального элемента массива
            // Cчитаем, что максимум - это первый элемент массива
            int max = sizeArray[0];
            // Cчитаем, что минимум - это первый элемент массива
            int min = sizeArray[0];
            int columns = 0;
            while (columns < sizeArray.Length)
            {
               if (max < sizeArray[columns])
               {
                  max = sizeArray[columns];
               }

               if (min > sizeArray[columns])
               {
                  min = sizeArray[columns];
               }

               columns++;
            }

            Console.WriteLine("Максимум равен: {0}", max);
            Console.WriteLine("Минимум равен: {0}", min);

            // Разделение строки на подстроки по пробелу и конвертация подстрок в структуру
            string[] lineArray = new string[max];
            StringBuilder stringModified = new StringBuilder();
            char spaceCharacter = ' ';
            int row = 0;
            int column = 0;
            int countCharacter = 0;
            while (row < allLines.Length)
            {
               string line = allLines[row];
               while (column < sizeArray[row])
               {
                  while (countCharacter < line.Length)
                  {
                     if (spaceCharacter == line[countCharacter])
                     {
                        string subLine = stringModified.ToString();
                        lineArray[column] = subLine;
                        stringModified.Clear();
                        column++;

                        //Group = parts[0],
                        //Surname = parts[1],
                        //Name = parts[2],
                        //Dadsname = parts[3],
                        //Year = int.Parse(parts[4]),
                        //Gender = char.Parse(parts[5]),
                        //Physics = int.Parse(parts[6]),
                        //Math = int.Parse(parts[7]),
                        //Inf = int.Parse(parts[8]),
                        //Grant = double.Parse(parts[9])

                     }
                     else
                     {
                        stringModified.Append(line[countCharacter]);
                     }

                     if (countCharacter == line.Length - 1)
                     {
                        string subLine = stringModified.ToString();
                        stringModified.Clear();
                        column++;
                     }

                     countCharacter++;
                  }
                  
                  arrayStudent[column].Group = lineArray[0];
                  arrayStudent[column].Surname = lineArray[1];
                  arrayStudent[column].Name = lineArray[2];
                  arrayStudent[column].Dadsname = lineArray[3];
                  arrayStudent[column].Year = int.Parse(lineArray[4]);
                  arrayStudent[column].Gender = char.Parse(lineArray[5]);
                  arrayStudent[column].Physics = int.Parse(lineArray[6]);

                  arrayStudent[column].Math = int.Parse(lineArray[7]);

                  arrayStudent[column].Inf = int.Parse(lineArray[8]);

                  arrayStudent[column].Grant = double.Parse(lineArray[9]);

                 


                  countCharacter = 0;
               }

               column = 0;
               row++;
            }

         }

         return arrayStudent;
      }

      public static double[] Enter1DArrayDouble(string path, string nameArray)
      {
         string stroka = null;
         double[] arrayDouble = { };
         FileStream filestream = File.Open(path, FileMode.Open, FileAccess.Read);
         if (filestream == null || filestream.Length == 0)
         {
            Console.WriteLine("Ошибка при открытии файла для чтения");
         }
         else
         {
            StreamReader streamReader = new StreamReader(filestream);
            while (streamReader.Peek() >= 0)
            {
               stroka = streamReader.ReadLine();
               //Console.WriteLine(stroka);
            }

            // Определение количества столбцов в строке разделением строки на подстроки по пробелу
            // Символ пробела
            char symbolSpace = ' ';
            // Счетчик символов
            int symbolСount = 0;
            // Количество столбцов в строке
            int сolumn = 0;
            if (stroka != null)
            {
               //Console.WriteLine("Исходный строковый массив {0}:", nameArray);
               //Console.WriteLine(stroka);
               while (symbolСount < stroka.Length)
               {
                  if (symbolSpace == stroka[symbolСount])
                  {
                     сolumn++;
                  }

                  if (symbolСount == stroka.Length - 1)
                  {
                     сolumn++;
                  }

                  symbolСount++;
               }

               //Console.WriteLine("Количество столбцов {0}:", сolumn);

               // Разделение строки на подстроки по пробелу и конвертация подстрок в double
               //Console.WriteLine("Массив вещественных чисел {0}:", nameArray);
               // Одномерный массив вещественных чисел
               arrayDouble = new double[сolumn];
               // Построитель строк
               StringBuilder stringModified = new StringBuilder();
               // Счетчик символов обнуляем
               symbolСount = 0;
               // Количество столбцов в строке обнуляем
               сolumn = 0;
               while (symbolСount < stroka.Length)
               {
                  if (symbolSpace != stroka[symbolСount])
                  {
                     stringModified.Append(stroka[symbolСount]);
                  }
                  else
                  {
                     string subLine = stringModified.ToString();
                     arrayDouble[сolumn] = Convert.ToDouble(subLine);
                     //Console.Write(arrayDouble[сolumn] + " ");
                     stringModified.Clear();
                     сolumn++;
                  }

                  if (symbolСount == stroka.Length - 1)
                  {
                     string subLine = stringModified.ToString();
                     arrayDouble[сolumn] = Convert.ToDouble(subLine);
                     //Console.Write(arrayDouble[сolumn]);
                     stringModified.Clear();
                     сolumn++;
                  }

                  symbolСount++;
               }
            }

            streamReader.Close();
            //Console.WriteLine();
         }

         return arrayDouble;
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
                  people.Add(Parse(line));
               }
            }
         }

         return people.ToArray();
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