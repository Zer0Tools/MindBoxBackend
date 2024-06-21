namespace ShapesLib;

/*

Задание:

Напишите на C# библиотеку для поставки внешним клиентам, 
которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам.

Это библиотека со статическими методами для вычисления площадей или билиотека классов фигур, 
у которых есть метод для получения площади? Решил, что второй вариант.

*/


/// <summary>
/// Base for all shapes
/// </summary>
public abstract class Shape
{
    /// <summary>
    /// Get shape area
    /// </summary>
    /// <returns> returns area </returns>
    public abstract float GetArea();
}


