using System;

namespace Task_10_1
{
	class Program
	{
		static void Main()
		{
			try
			{
				string path = @"C:\temp";
				Directory.CreateDirectory(path + @"\k1");
				Console.WriteLine("Папка k1 создана");


				Directory.CreateDirectory(path + @"\k2");
				Console.WriteLine("Папка k2 создана");

				File.Create(path + @"\k1\t1.txt").Close();
				Console.WriteLine("Файл t1 был создан");
				string text1 = "Моисеев Дмитрий Алексеевич, 2004 года рождения, место жительства г. Кольчугино\n";
				File.WriteAllText(path + @"\k1\t1.txt", text1);

				File.Create(path + @"\k1\t2.txt").Close();
				Console.WriteLine("Файл t2 был создан");
				string text2 = "Моисеева Ольга Владимировна, 1984 года рождения, место жительства г. Кольчугино\n";
				File.WriteAllText(path + @"\k1\t2.txt", text2);

				File.Create(path + @"\k2\t3.txt").Close();
				Console.WriteLine("Файл t3 был создан");

				File.WriteAllText(path + @"\k2\t3.txt", File.ReadAllText(path + @"\k1\t1.txt"));
				File.AppendAllText(path + @"\k2\t3.txt", File.ReadAllText(path + @"\k1\t2.txt"));

				FileInfo file1 = new FileInfo(path + @"\k1\t1.txt");
				FileInfo file2 = new FileInfo(path + @"\k1\t2.txt");
				FileInfo file3 = new FileInfo(path + @"\k2\t3.txt");

				Console.WriteLine("\nРазвернутая информация о файлах");
				Console.WriteLine("Первый файл\nИмя файла: {0}, Размер файла: {1}, Время создания файла: {2}\n", file1.Name, file1.Length, file1.CreationTime);
				Console.WriteLine("Второй файл\nИмя файла: {0}, Размер файла: {1}, Время создания файла: {2}\n", file2.Name, file2.Length, file2.CreationTime);
				Console.WriteLine("третий файл\nИмя файла: {0}, Размер файла: {1}, Время создания файла: {2}\n", file3.Name, file3.Length, file3.CreationTime);

				file2.MoveTo(@"C:\temp\k2\t2.txt");
				Console.WriteLine("Файл t2 был перемещен в папку k2");
				file1.CopyTo(@"C:\temp\k2\t1.txt");
				Console.WriteLine("Файл t1 был копирован в папку k2");

				Directory.Move(@"C:\temp\k2", @"C:\temp\ALL");
				Console.WriteLine("Папка k2 была переименованна в ALL");

				File.Delete(path + @"\k1\t1.txt");
				Directory.Delete(path + @"\k1");
				Console.WriteLine("Файл t1 папка k1 были успешно удалены");

				DirectoryInfo directoryAll = new DirectoryInfo(path + @"\ALL");
				FileInfo[] filesInfo = directoryAll.GetFiles();

				foreach (FileInfo file in filesInfo)
				{
					Console.WriteLine("\nИмя файла: {0}\nРазмер файла: {1}\nВремя создания файла: {2}", file.Name, file.Length, file.CreationTime);
				}
			}
			catch
			{
				Console.WriteLine("Что-то пошло не так...");
			}
		}
	}
}