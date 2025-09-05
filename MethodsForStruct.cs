using System;
using System.IO;
using System.Text;

namespace Homework_6._1
{
   public class MethodsForStruct
   {
      // Метод записи массива структур в текстовый файл
      public static void WriteStructFileTxt(string path, Student[] students)
      {
         FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Write);
         StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);
         int i = 0;
         while (i < students.Length)
         {
            Student person = students[i];
            writer.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}",
               person.Group, person.Surname, person.Name, person.Dadsname, person.Year,
               person.Gender, person.Physics, person.Math, person.Inf, person.Grant);
            i++;
         }

         writer.Close();
      }
      
      // Метод чтения массива структур из текстового файла
      public static Student[] ReadStructFileTxt(string path, string nameFile)
      {
         Student[] arrayStudent = { };
         // Чтение файла за одну операцию
         string[] allLines = File.ReadAllLines(path, Encoding.UTF8);
         if (allLines == null || allLines.Length == 0)
         {
            Console.WriteLine("Ошибка содержимого файла для чтения {0}", nameFile);
            //Console.WriteLine("Ошибка содержимого файла для чтения {0}. Файл пуст", nameFile);
         }
         else
         {
            // Разделение строки на подстроки по пробелу для определения количества столбцов в строке
            arrayStudent = new Student[allLines.Length];
            int[] сolumnArray = new int[allLines.Length];
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

               сolumnArray[countRow] = countСolumn;
               // 10 количество полей в структуре
               if (countСolumn != 10)
               {
                  Console.WriteLine("Неверный формат строки {0}", countRow);
               }

               countRow++;
               countСolumn = 0;
               countSymbol = 0;
            }

            // Поиск максимального и минимального элемента массива
            // Cчитаем, что максимум - это первый элемент массива
            int max = сolumnArray[0];
            // Cчитаем, что минимум - это первый элемент массива
            int min = сolumnArray[0];
            int columns = 0;
            while (columns < сolumnArray.Length)
            {
               if (max < сolumnArray[columns])
               {
                  max = сolumnArray[columns];
               }

               if (min > сolumnArray[columns])
               {
                  min = сolumnArray[columns];
               }

               columns++;
            }

            //Console.WriteLine("Максимум равен: {0}", max);
            //Console.WriteLine("Минимум равен: {0}", min);

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
               while (column < сolumnArray[row])
               {
                  while (countCharacter < line.Length)
                  {
                     if (spaceCharacter == line[countCharacter])
                     {
                        string subLine = stringModified.ToString();
                        lineArray[column] = subLine;
                        stringModified.Clear();
                        column++;
                     }
                     else
                     {
                        stringModified.Append(line[countCharacter]);
                     }

                     if (countCharacter == line.Length - 1)
                     {
                        string subLine = stringModified.ToString();
                        lineArray[column] = subLine;
                        stringModified.Clear();
                        column++;
                     }

                     countCharacter++;
                  }

                  arrayStudent[row].Group = lineArray[0];
                  arrayStudent[row].Surname = lineArray[1];
                  arrayStudent[row].Name = lineArray[2];
                  arrayStudent[row].Dadsname = lineArray[3];
                  arrayStudent[row].Year = int.Parse(lineArray[4]);
                  arrayStudent[row].Gender = char.Parse(lineArray[5]);
                  arrayStudent[row].Physics = int.Parse(lineArray[6]);
                  arrayStudent[row].Math = int.Parse(lineArray[7]);
                  arrayStudent[row].Inf = int.Parse(lineArray[8]);
                  arrayStudent[row].Grant = double.Parse(lineArray[9]);

                  countCharacter = 0;
               }

               row++;
               column = 0;
            }
         }

         return arrayStudent;
      }

      // Метод записи массива структур в бинарный файл
      public static void WriteStructFileBin(string path, Student[] students)
      {
         FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write);
         BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8);
         writer.Write(students.Length);
         int i = 0;
         while (i < students.Length)
         {
            Student person = students[i];
            // Запись строки в UTF-8 с предварительной длиной
            writer.Write(person.Group);
            writer.Write(person.Surname);
            writer.Write(person.Name);
            writer.Write(person.Dadsname);
            writer.Write(person.Year);
            writer.Write(person.Gender);
            writer.Write(person.Physics);
            writer.Write(person.Math);
            writer.Write(person.Inf);
            writer.Write(person.Grant);
            i++;
         }

         stream.Close();
         writer.Close();
      }
      
      // Метод чтения массива структур из бинарного файла
      public static Student[] ReadStructFileBin(string path)
      {
         FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
         BinaryReader reader = new BinaryReader(stream, Encoding.UTF8);
         int length = reader.ReadInt32();
         Student[] persons = new Student[length];
         int i = 0;
         while (i < length)
         {
            string group = reader.ReadString();
            string surname = reader.ReadString();
            string name = reader.ReadString();
            string dadsname = reader.ReadString();
            int year = reader.ReadInt32();
            char gender = reader.ReadChar();
            int physics = reader.ReadInt32();
            int Math = reader.ReadInt32();
            int inf = reader.ReadInt32();
            double grant = reader.ReadDouble();
            persons[i] = new Student
            {
               Group = group,
               Surname = surname,
               Name = name,
               Dadsname = dadsname,
               Year = year,
               Gender = gender,
               Physics = physics,
               Math = Math,
               Inf = inf,
               Grant = grant
            };

            i++;
         }

         stream.Close();
         reader.Close();
         return persons;
      }
   }
}