using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            //Задание 1: переворот списка
            List<int> numbers = new List<int> { 10, 20, 30, 40, 50 };
            Console.WriteLine($"Исходный список: " + string.Join(", ", numbers));
            var reversed = LabClasses.ReverseList(numbers);
            Console.WriteLine($"Перевернутый список: " + string.Join(", ", reversed));
            Console.WriteLine();

            //Задание 2: вставка рядом с выбранным элементом
            LinkedList<int> linkedList = new LinkedList<int>(new[] { 1, 2, 3, 4, 5 });
            Console.WriteLine($"Исходный список: " + string.Join(", ", linkedList));
            LabClasses.InsertAround(linkedList, 3, 100);
            Console.WriteLine($"Список после вставки элемента 100 до и после элемента 3: " + string.Join(", ", linkedList));
            Console.WriteLine();

            //Задание 3: анализ дискотек
            var allClubs = new HashSet<string> { "У Снегурочки", "Снежный вальс", "Волшебная ночь", "Новодиско", "Полночь" };
            var studentVisits = new Dictionary<string, HashSet<string>>
            {
                {"Иван", new HashSet<string> {"У Снегурочки", "Снежный вальс"}},
                {"Владимир", new HashSet<string> {"Снежный вальс", "Волшебная ночь"}},
                {"Михаил", new HashSet<string> {"У Снегурочки", "Снежный вальс", "Волшебная ночь"} }
            };
            LabClasses.AnalyzeStudents(studentVisits, allClubs);
            Console.WriteLine();

            //Задание 4: анализ текстового файла
            string textFilePath = "text.txt";
            LabClasses.CreateTextFile(textFilePath);
            LabClasses.PrintEvenWordSymbols(textFilePath);
            Console.WriteLine();

            //Задание 5: анализ абитуриентов
            string applicantsFilePath = "applicants.txt";
            LabClasses.CreateApFile(applicantsFilePath);
            LabClasses.CheckApplicants(applicantsFilePath);
        }
    }
}