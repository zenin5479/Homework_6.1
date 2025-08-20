namespace Homework_6._1
{
   internal class Draft
   {
      //// Запись в файл
      //using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
      //{
      //   // Преобразуем строку в байты
      //   byte[] buffer = Encoding.Default.GetBytes(originalText);
      //   // Запись массива байтов в файл
      //   fstream.Write(buffer, 0, buffer.Length);
      //   Console.WriteLine("Текст записан в файл");
      //}

      //// Чтение из файла
      //using (FileStream fstream = File.OpenRead(path))
      //{
      //   // Выделяем массив для считывания данных из файла
      //   byte[] buffer = new byte[fstream.Length];
      //   // Считываем данные
      //   int read = fstream.Read(buffer, 0, buffer.Length);
      //   // Декодируем байты в строку
      //   string textFromFile = Encoding.Default.GetString(buffer);
      //   Console.WriteLine("Текст из файла:\n{0}", textFromFile);
      //}

      //string path = "spisok.txt";
      //string[] originalText =
      //{
      //   "IP-21; Иванов Иван Иванович; 2000; М; 4; 5; 3; 5000\n" +
      //   "IP-21; Петрова Анна Сергеевна; 2001; Ж; 5; 4; 5; 6000\n" +
      //   "IP-22; Смирнов Алексей Викторович; 1999; М; 3; 4; 4; 4000\n" +
      //   "Fiz-21; Кузнецова Мария Павловна; 2000; Ж; 5; 5; 5; 7000\n" +
      //   "Phys-22; Сидоров Дмитрий Андреевич; 2001; М; 4; 3; 4; 4500\n" +
      //   "IP-22; Васильева Екатерина Николаевна; 2009; Ж; 3; 5; 4; 5500\n" +
      //   "Fiz-21; Орлов Сергей Владимирович; 2000; М; 4; 4; 3; 3000\n" +
      //   "IP-21; Лебедева Светлана Александровна; Ж; 2001; 5; 5; 5; 8000\n" +
      //   "Fiz-22; Николаев Андрей Сергеевич; 2007; М; 3; 2; 3; 2500\n" +
      //   "IP-22; Сергеева Дарья Викторовна; 2007; Ж; 2; 2; 2; 5000"
      //};

      //// Запись ведомости
      //File.WriteAllLines(path, originalText, Encoding.UTF8);
      //// Чтение файла
      //string[] fileText = File.ReadAllLines(path, Encoding.UTF8);
      //int i = 0;
      //while (i < fileText.Length)
      //{
      //   string s = fileText[i];
      //   Console.WriteLine(s);
      //   i++; 
      //}

      //
      //Console.OutputEncoding = Encoding.UTF8;
      //string inputFile = "input.txt";
      //Toy[] toys = ReadFile(inputFile);
      //// Выводим исходный массив игрушек
      //Console.WriteLine("--------Исходный массив--------");
      //Display(toys);
      //Console.WriteLine("-------------------------------");

      //
      // // Путь к файлу
      //string path = "note.txt";
      // Путь к файлу
      //string path = "input.txt";
      //// Строка для записи
      //string text = "Самолет";

      //// запись в файл
      //using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
      //{
      //   // преобразуем строку в байты
      //   byte[] buffer = Encoding.Default.GetBytes(text);
      //   // запись массива байтов в файл
      //   fstream.WriteAsync(buffer, 0, buffer.Length);
      //   Console.WriteLine("Текст записан в файл");
      //}

      //// чтение из файла
      //using (FileStream fstream = File.OpenRead(path))
      //{
      //   // выделяем массив для считывания данных из файла
      //   byte[] buffer = new byte[fstream.Length];
      //   // считываем данные
      //   fstream.ReadAsync(buffer, 0, buffer.Length);
      //   // декодируем байты в строку
      //   string textFromFile = Encoding.Default.GetString(buffer);
      //   Console.WriteLine($"Текст из файла: {textFromFile}");
      //}
      
      //      toys[i].AgeMin = Convert.ToInt32(toyFields[2]);
      //      toys[i].AgeMax = Convert.ToInt32(toyFields[3]);
      //      i++;
   }
}