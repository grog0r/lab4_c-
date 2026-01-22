using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    public static class LabClasses
    {
        // ЗАДАНИЕ 1 (List)
        /// <summary>
        /// Переворачиваем список L
        /// </summary>
        public static List<T> ReverseList<T>(List<T> list)
        {
            if (list == null || list.Count == 0)
                return new List<T>();

            List<T> reversed = new List<T>(list);
            reversed.Reverse();
            return reversed;
        }

        // ЗАДАНИЕ 2 (LinkedList)
        /// <summary>
        /// В списке справа и слева от элемента E вставляем элемент F
        /// </summary>
        public static LinkedList<T> InsertAround<T>(LinkedList<T> list, T E, T F)
        {
            if (list == null)
                return new LinkedList<T>();

            var node = list.Find(E);
            if (node != null)
            {
                list.AddBefore(node, F);
                list.AddAfter(node, F);
            }
            return list;
        }

        // ЗАДАНИЕ 3 (HashSet)
        /// <summary>
        /// Анализ посещения дискотек студентами
        /// </summary>
        public static void AnalyzeStudents(Dictionary<string, HashSet<string>> studentClubs, HashSet<string> allClubs)
        {
            if (studentClubs == null || allClubs == null || studentClubs.Count == 0)
            {
                Console.WriteLine("Ошибка. Нет данных для анализа");
                return;
            }

            var allStudents = studentClubs.Keys.ToList();

            var visitedByAll = allClubs
                .Where(club => allStudents.All(s => studentClubs[s].Contains(club)))
                .ToList();

            var visitedBySome = allClubs
                .Where(club => allStudents.Any(s => studentClubs[s].Contains(club)))
                .ToList();

            var visitedByNone = allClubs
                .Where(club => !allStudents.Any(s => studentClubs[s].Contains(club)))
                .ToList();

            Console.WriteLine("Дискотеки, которые посетили все студенты: " + string.Join(", ", visitedByAll));
            Console.WriteLine("Дискотеки, которые посетили некоторые студенты: " + string.Join(", ", visitedBySome));
            Console.WriteLine("Дискотеки, которые не посетили студенты: " + string.Join(", ", visitedByNone));
        }

        // ЗАДАНИЕ 4 (HashSet)
        /// <summary>
        /// Создает тестовый файл с русским текстом
        /// </summary>
        public static void CreateTextFile(string filePath)
        {
            string text = @"Сегодня хорошая погода, хочу сходить погулять и встретиться со своими друзьями! 
            Вечером пойду в кино, а завтра снова выходить на работу";

            File.WriteAllText(filePath, text);
        }

        /// <summary>
        /// Печатаем символы, встречающиеся в словах с четными номерами
        /// </summary>
        public static void PrintEvenWordSymbols(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не найден");
                return;
            }

            string text = File.ReadAllText(filePath).ToLower();
            char[] separators = { ' ', '.', ',', '!', '?', ';', ':', '\n', '\r', '\t', '-', '(', ')' };
            var words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            var evenWordSymbols = new HashSet<char>();
            for (int i = 0; i < words.Length; i++)
            {
                if ((i + 1) % 2 == 0)
                {
                    foreach (char c in words[i])
                    {
                        if (char.IsLetter(c) && IsRussianLetter(c))
                            evenWordSymbols.Add(c);
                    }
                }
            }

            var sortedSymbols = evenWordSymbols.OrderBy(c => c).ToList();
            Console.WriteLine("Символы из слов с четными номерами: " + string.Join(", ", sortedSymbols));
        }

        private static bool IsRussianLetter(char c)
        {
            return (c >= 'а' && c <= 'я');
        }

        // ЗАДАНИЕ 5 (Dictionary/SortedList)
        /// <summary>
        /// Создаем текстовый файл с абитуриентами
        /// </summary>
        public static void CreateApFile(string filePath)
        {
            string[] lines =
            {
                "5",
                "Пупкин Никита 47 40 55",
                "Иванов Иван 22 33 95",
                "Сидоров Сидр 40 50 60",
                "Петров Петр 40 45 50",
                "Жуков Жук 30 30 30"
            };

            File.WriteAllLines(filePath, lines);
        }
        
        /// <summary>
        /// Обрабатываем данные абитуриентов и выводим допущенных к сдаче экзаменов в первом потоке согласно условий
        /// </summary>
        public static void CheckApplicants(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }

            var lines = File.ReadAllLines(filePath);
            if (lines.Length == 0)
            {
                Console.WriteLine("Файл пустой.");
                return;
            }

            if (!int.TryParse(lines[0], out int n) || n <= 0)
            {
                Console.WriteLine("Некорректное количество абитуриентов.");
                return;
            }

            var admitted = new SortedSet<string>();
            for (int i = 1; i <= n && i < lines.Length; i++)
            {
                var parts = lines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 5)
                {
                    Console.WriteLine($"Некорректная строка: {lines[i]}");
                    continue;
                }

                string surname = parts[0];
                string name = parts[1];

                if (!int.TryParse(parts[2], out int score1) || !int.TryParse(parts[3], out int score2) || !int.TryParse(parts[4], out int scroe3))
                {
                    Console.WriteLine($"Ошибка в баллах у {surname} {name}");
                    continue;
                }

                if (score1 >= 30 && score2 >= 30 && scroe3 >= 30 && (score1 + score2 + scroe3 >= 140))
                {
                    admitted.Add($"{surname} {name}");
                }
            }

            Console.WriteLine("Абитуриенты, допущенные к экзаменам: ");
            if (admitted.Count == 0)
            {
                Console.WriteLine("Допущенных абитуриентов нет.");
            }
            else
            {
                foreach (var person in admitted)
                {
                    Console.WriteLine(person);
                }
            }
        }
    }
}