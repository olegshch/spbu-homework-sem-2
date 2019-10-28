namespace Hashtable
{
    public class HashSymbol : IHashInterface
    {
        public int Transform(int data)
        {
            int k = 0;
            while (data > 0)
            {
                k += data % 10;
                data /= 10;
            }
            return k;
        }
    }
}
