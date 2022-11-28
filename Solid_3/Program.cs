using System;
/*
Поведінка Square відрізняється від типових
реалізацій Rectangle. Таким чином, Square не може бути
замінений базовим типом. Це і є порушення принципу
заміщення Лісков.

 Правильним рішенням буде використовувати свій
власний інтерфейс,*/
public interface IRectangle
{
    int Width { get; set; }
    int Height { get; set; }
    int GetRectangleArea();
}
class Rectangle : IRectangle
{
    public int Width { get; set; }
    public int Height { get; set; }
    public int GetRectangleArea()
    {
        return Width * Height;
    }
}
public interface ISquare
{
    int Side { get; set; }
    int GetSquareArea();
}
class Square : ISquare
{
    public int Side { get; set; }
    public int GetSquareArea()
    {
        return Side * Side;
    } 
}
class Program
{
    static void Main(string[] args)
    {
        Square sq = new Square();
        Rectangle rect = new Rectangle();
        sq.Side = 6;
        rect.Height = 10;
        rect.Width = 5;
        Console.WriteLine(rect.GetRectangleArea());
        Console.WriteLine(sq.GetSquareArea());
        Console.ReadKey();
    }
}
