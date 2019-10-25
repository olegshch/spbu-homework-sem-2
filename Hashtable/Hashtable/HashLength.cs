namespace Hashtable
{
    public class HashLength : IHashInterface
    {
        public int Transform(int data)
        {
            int k = 0;
            while (data > 0)
            {
                data = data / 10;
                k++;
            }
            return k;
        }
    }
}
