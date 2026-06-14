namespace TriangleTypeClassifierTests;
using TriangleClassification;

[TestFixture]
public class TriangleTypeClassifierTests
{
    [TestCase(3, 3, 3, TriangleType.Equilateral)]
    [TestCase(3, 3, 4, TriangleType.Isosceles)]
    [TestCase(3, 4, 5, TriangleType.Scalene)]
    public void DetermineTriangleType_ReturnsExpectedType(
        double sideA,
        double sideB,
        double sideC,
        TriangleType expected)
    {
        var result = TriangleTypeClassifier.DetermineTriangleType(
            sideA,
            sideB,
            sideC);

        Assert.That(result, Is.EqualTo(expected));
    }

    public void DetermineTriangleType_Given_Inequal_Triangle_Sides_Throws_ArgumentException()
    {
        Assert.Throws<ArgumentException>(
            () => TriangleTypeClassifier.DetermineTriangleType(1, 2, 3));
    }

    [TestCase(double.PositiveInfinity, 3, 3)]
    [TestCase(double.NaN, 3, 3)]
    public void DetermineTriangleType_Given_Infinite_Side_Throws_ArgumentException(
        double sideA,
        double sideB,
        double sideC)
    {
        Assert.Throws<ArgumentException>(
            () => TriangleTypeClassifier.DetermineTriangleType(
                sideA,
                sideB,
                sideC));
    }


    [TestCase(0, 3, 3)]
    [TestCase(-3, 3, 3)]
    [TestCase(double.NegativeInfinity, 3, 3)]
    public void DetermineTriangleType_Given_Zero_Or_Negative_Side_Throws_ArgumentOutOfRangeException(
        double sideA,
        double sideB,
        double sideC)
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => TriangleTypeClassifier.DetermineTriangleType(
                sideA,
                sideB,
                sideC));
    }
}
