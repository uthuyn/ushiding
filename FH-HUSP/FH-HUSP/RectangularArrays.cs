internal static partial class RectangularArrays
{
    internal static float[][] ReturnRectangularFloatArray(int size1, int size2)
    {
        float[][] newArray;
        if (size1 > -1)
        {
            newArray = new float[size1][];
            if (size2 > -1)
            {
                for (int array1 = 0; array1 < size1; array1++)
                {
                    newArray[array1] = new float[size2];
                }
            }
        }
        else
            newArray = null;

        return newArray;
    }
    internal static int[][] ReturnRectangularIntArray(int size1, int size2)
    {
        int[][] newArray;
        if (size1 > -1)
        {
            newArray = new int[size1][];
            if (size2 > -1)
            {
                for (int array1 = 0; array1 < size1; array1++)
                {
                    newArray[array1] = new int[size2];
                }
            }
        }
        else
            newArray = null;

        return newArray;
    }
}