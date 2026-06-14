namespace TriangleClassification;

/// <summary>
/// Enum to represent types of triangles.
/// </summary>
public enum TriangleType
{
    Equilateral,
    Isosceles,
    Scalene,
}

/// <summary>
/// TriangleClassifier that classifies a given triangle based on the lengths of its sides.
/// </summary>
public static class TriangleTypeClassifier
{
    /// <summary>
    /// Classifies a triangle based on the lengths of its sides.
    /// </summary>
    /// <param name="sideA">The length of side A.</param>
    /// <param name="sideB">The length of side B.</param>
    /// <param name="sideC">The length of side C.</param>
    /// <returns>The triangle type</returns>
    /// <exception cref="ArgumentException">Throws if the given sides do not form a valid triangle.</exception>
    public static TriangleType DetermineTriangleType(double sideA, double sideB, double sideC)
    {
        ValidateTriangle(sideA, sideB, sideC);

        if (sideA == sideB && sideB == sideC)
        {
            return TriangleType.Equilateral;
        }

        if (sideA == sideB || sideA == sideC || sideB == sideC)
        {
            return TriangleType.Isosceles;
        }

        return TriangleType.Scalene;
    }

    /// <summary>
    /// Validates whether three triangle sides can form a valid triangle.
    /// </summary>
    /// <param name="sideA">Length of the side A</param>
    /// <param name="sideB">Length of the side B</param>
    /// <param name="sideC">Length of the side C</param>
    private static void ValidateTriangle(double sideA, double sideB, double sideC)
    {
        ValidateSideLength(sideA, nameof(sideA));
        ValidateSideLength(sideB, nameof(sideB));
        ValidateSideLength(sideC, nameof(sideC));

        ValidateTriangleInequality(sideA, sideB, sideC);
    }

    /// <summary>
    /// Validates the length of a triangle side
    /// </summary>
    /// <param name="sideLength">The length of the side</param>
    /// <param name="sideName">The name of the side</param>
    /// <exception cref="ArgumentException">Throws if the side length is not greater than zero</exception>
    private static void ValidateSideLength(double sideLength, string sideName)
    {
        if (sideLength <= 0)
        {
            throw new ArgumentOutOfRangeException($"Triangle side {sideName} must be greater than zero but was {sideLength}.");
        }
        if (!double.IsFinite(sideLength))
        {
            throw new ArgumentException($"Triangle side {sideName} must not be infinite but was {sideLength}.");
        }
    }

    /// <summary>
    /// Validates the triangle inequality theorem
    /// </summary>
    /// <param name="sideA">Length of the side A</param>
    /// <param name="sideB">Length of the side B</param>
    /// <param name="sideC">Length of the side C</param>
    /// <exception cref="ArgumentException">Throws if the inequality theorem is not upheld</exception>
    private static void ValidateTriangleInequality(double sideA, double sideB, double sideC)
    {
        if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
        {
            throw new ArgumentException($"Triangle inequality violated for sidelengths: {sideA}, {sideB}, {sideC}.");
        }
    }
}

public class Program
{
    /// <summary>
    /// Gets the length of a triangle side from user input.
    /// </summary>
    /// <param name="sideName">The name of the side.</param>
    /// <returns>The length of the side.</returns>
    private static double GetSideLengthInput(string sideName)
    {
        while (true)
        {
            Console.Write($"Side {sideName}: ");
            if (double.TryParse(Console.ReadLine(), out double side))
            {
                return side;
            }
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the lengths of the three sides of the triangle:");
        double sideA = GetSideLengthInput("A");
        double sideB = GetSideLengthInput("B");
        double sideC = GetSideLengthInput("C");

        try
        {
            TriangleType triangleType = TriangleTypeClassifier.DetermineTriangleType(sideA, sideB, sideC);
            Console.WriteLine($"The triangle is: {triangleType}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}