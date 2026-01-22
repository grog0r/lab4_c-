using System;
using System.Reflection.Emit;

namespace Point
{
    class Program
    {
        static void Main()
        {
            // создаем точки для тестирования
            Point p1 = new Point(5.7, 3.2);
            Point p2 = new Point(2.1, 4.8);
            Point p3 = new Point(0, 0);

            Console.WriteLine($"Точка p1 = {p1}");
            Console.WriteLine($"Точка p2 = {p2}");
            Console.WriteLine($"Точка p3 (начало координат) = {p3}\n");

            // ========== ТЕСТИРОВАНИЕ ЗАДАНИЯ 6 ==========
            Console.WriteLine("--- ЗАДАНИЕ 6: Метод DistanceToOrigin() ---");
            Console.WriteLine($"Расстояние от p1 до начала координат: {p1.Distance():F2}");
            Console.WriteLine($"Расстояние от p2 до начала координат: {p2.Distance():F2}\n");

            // ========== ТЕСТИРОВАНИЕ ЗАДАНИЯ 7 ==========
            Console.WriteLine("--- ЗАДАНИЕ 7: Перегрузка операторов ---");

            // 1. Тест унарного оператора --
            Console.WriteLine("\n1. Унарный оператор -- (уменьшить координаты на 1):");
            Console.WriteLine($"Исходная: {p1}");
            p1--;
            Console.WriteLine($"После p1--: {p1}");

            // 2. Тест унарного оператора - (поменять координаты местами)
            Console.WriteLine("\n2. Унарный оператор - (поменять координаты местами):");
            Point swapped = -p1;
            Console.WriteLine($"Исходная: {p1}");
            Console.WriteLine($"После -p1 (swap): {swapped}");

            // 3. Тест явного приведения к int (целая часть X)
            Console.WriteLine("\n3. Явное приведение к int (целая часть X):");
            int xAsInt = (int)p1;
            Console.WriteLine($"(int)p1 = {xAsInt} (целая часть от X = {p1.X})");

            // 4. Тест явного приведения к double (координата Y)
            Console.WriteLine("\n4. Явное приведение к double (координата Y):");
            double yAsDouble = (double)p1;
            Console.WriteLine($"(double)p1 = {yAsDouble} (Y = {p1.Y})");

            // 5. Тест бинарного оператора - (Point - int)
            Console.WriteLine("\n5. Бинарный оператор - (Point - int):");
            Point pMinusInt = p2 - 3;
            Console.WriteLine($"p2 - 3 = {pMinusInt}");

            // 6. Тест бинарного оператора - (int - Point)
            Console.WriteLine("\n6. Бинарный оператор - (int - Point):");
            Point intMinusP = 10 - p2;
            Console.WriteLine($"10 - p2 = {intMinusP}");

            // 7. Тест бинарного оператора - (расстояние между точками)
            Console.WriteLine("\n7. Бинарный оператор - (расстояние между точками):");
            double distance = Math.Abs(p1 - p2);
            Console.WriteLine($"p1 - p2 (расстояние) = {distance:F2}");

            // Дополнительные тесты
            Console.WriteLine("\n--- Дополнительные тесты ---");

            // Проверка с началом координат
            Console.WriteLine($"Расстояние от p1 до начала координат через оператор: {p1 - p3:F2}");
            Console.WriteLine($"Расстояние от p2 до начала координат через оператор: {p2 - p3:F2}");

            // Последовательные операции
            Console.WriteLine("\nПоследовательные операции:");
            Point testPoint = new Point(10, 20);
            Console.WriteLine($"Исходная: {testPoint}");
            testPoint--;
            Console.WriteLine($"После --: {testPoint}");
            testPoint = -testPoint;
            Console.WriteLine($"После - (swap): {testPoint}");
            Point final = testPoint - 5;
            Console.WriteLine($"После - 5: {final}");

            Console.WriteLine("\n=== Все операции протестированы успешно ===");
            Console.ReadKey();
        }
    }
}