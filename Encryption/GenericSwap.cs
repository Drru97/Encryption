namespace Encryption
{
    public static class GenericSwap
    {
        public static void Swap<T>(this T[] array, int index1, int index2)
        {
            var temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}
