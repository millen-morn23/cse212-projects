
public static class Trees
{
    /// <summary>
    /// Given a sorted list, create a balanced binary search tree.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree();

        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);

        return bst;
    }

    /// <summary>
    /// Recursively inserts the middle value of each range into the BST
    /// to create a balanced tree.
    /// </summary>
    /// <param name="sortedNumbers">Input numbers that are already sorted.</param>
    /// <param name="first">The first index in the range.</param>
    /// <param name="last">The last index in the range.</param>
    /// <param name="bst">The BinarySearchTree in which to insert values.</param>
    private static void InsertMiddle(
        int[] sortedNumbers,
        int first,
        int last,
        BinarySearchTree bst)
    {
        // Base case: the range is empty.
        if (first > last)
            return;

        // Find the middle index without creating sublists.
        int middle = first + (last - first) / 2;

        // Insert the middle value first.
        bst.Insert(sortedNumbers[middle]);

        // Recursively insert values from the left half.
        InsertMiddle(sortedNumbers, first, middle - 1, bst);

        // Recursively insert values from the right half.
        InsertMiddle(sortedNumbers, middle + 1, last, bst);
    }
}
