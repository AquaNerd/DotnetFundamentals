namespace Fundamentals.Algorithms;

public class EfficientSequenceSearch
{
    /// <summary>
    /// The goal is to get all even numbers that are divisible by the lowest number
    /// </summary>
    /// <param name="first"></param>
    /// <param name="second"></param>
    /// <returns></returns>
    public int[] GetAllEvenNumbers(int first, int second)
    {
        var result = new List<int>();
        var max = Math.Max(first, second);
        var min = Math.Min(first, second);

        for (int i = min; i <= max; i++)
        {
            if (i % min == 0 && i % 2 == 0)
            {
                result.Add(i);
            }
        }

        return result.ToArray();
    }
}
