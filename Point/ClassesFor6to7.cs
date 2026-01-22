using System;

namespace Point
{
    public class Point
    {
        // Поля (координаты точки)
        public double X { get; set; }
        public double Y { get; set; }

        // Конструкторы
        public Point() : this(0, 0) { }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        // Задание 6: метод вычисления расстояния до начала координат
        public double Distance()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        // Задание 7: перегрузка операторов

        // 1. уменьшение координат на 1
        public static Point operator --(Point p)
        {
            if (p == null)
                throw new ArgumentNullException(nameof(p));
            
            return new Point(p.X - 1, p.Y - 1);
        }

        // 2. смена мест координат (X <--> Y)
        public static Point operator -(Point p)
        {
            if (p == null)
                throw new ArgumentNullException(nameof(p));
            
            return new Point(p.Y, p.X);
        }

        // 3. Выделение целой части (координата X)
        public static explicit operator int(Point p)
        {
            if (p == null)
                throw new ArgumentNullException(nameof(p));
            
            return (int)p.X; // Отбрасываем дробную часть
        }

        // 4. Приведение к double (координата Y)
        public static explicit operator double(Point p)
        {
            if (p == null)
                throw new ArgumentNullException(nameof(p));
            
            return p.Y;
        }

        // 5. Уменьшает координату X на значение d
        public static Point operator -(Point p, int d)
        {
            if (p == null)
                throw new ArgumentNullException(nameof(p));
            
            return new Point(p.X - d, p.Y);
        }

        // 6. Уменьшение координаты Y на значение d
        public static Point operator -(int d, Point p)
        {
            if (p == null)
                throw new ArgumentNullException(nameof(p));
            
            return new Point(d - p.X, p.Y);
        }

        // 7. Определение расстояния между двумя точками
        public static double operator -(Point a, Point b)
        {
            if (a == null || b == null)
                throw new ArgumentNullException(a == null ? nameof(a) : nameof(b));
            
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }

        // Переопределение ToString()
        public override string ToString()
        {
            return $"({X}; {Y})";
        }
    }
}