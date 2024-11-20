using Fundamentals.Algorithms;

namespace Fundamentals.Tests.Algorithms;

public class EfficientSequenceSearchUnitTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Given17and4()
    {
        var question = new EfficientSequenceSearch();
        var answers = question.GetAllEvenNumbers(17, 4);
        Assert.That(answers, Is.EquivalentTo(new[] { 4, 8, 12, 16 }));
    }

    [Test]
    public void Given21and7()
    {
        var question = new EfficientSequenceSearch();
        var answers = question.GetAllEvenNumbers(21, 7);
        Assert.That(answers, Is.EquivalentTo(new[] { 14 }));
    }

    [Test]
    public void Given5and20()
    {
        var question = new EfficientSequenceSearch();
        var answers = question.GetAllEvenNumbers(5, 20);
        Assert.That(answers, Is.EquivalentTo(new[] { 10, 20 }));
    }

    [Test]
    public void Given3and10()
    {
        var question = new EfficientSequenceSearch();
        var answers = question.GetAllEvenNumbers(3, 10);
        Assert.That(answers, Is.EquivalentTo(new[] { 6 }));
    }

    [Test]
    public void Given2and2()
    {
        var question = new EfficientSequenceSearch();
        var answers = question.GetAllEvenNumbers(2, 2);
        Assert.That(answers, Is.EquivalentTo(new[] { 2 }));
    }
}
