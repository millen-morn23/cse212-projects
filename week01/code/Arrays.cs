
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// Produces an array of the requested length containing multiples of a number.
    /// </summary>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan:
        // 1. Create an array with the requested length.
        // 2. Visit each array index, starting at zero.
        // 3. Calculate the multiple for that position.
        // 4. Store the calculated value at that index.
        // 5. Return the completed array.

        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
    }

    /// <summary>
    /// Rotates the list to the right by the specified amount.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan:
        // 1. Find the index where the final amount of elements begins.
        // 2. Copy those final elements into a temporary list.
        // 3. Remove those elements from the original list.
        // 4. Insert the copied elements at the beginning.
        // 5. The original list now contains the rotated elements.

        int startIndex = data.Count - amount;

        List<int> lastElements = data.GetRange(startIndex, amount);

        data.RemoveRange(startIndex, amount);

        data.InsertRange(0, lastElements);
    }
}
