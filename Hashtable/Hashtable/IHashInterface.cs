namespace Hashtable
{
    /// <summary>
    /// Интерфейс Хеш-функции
    /// </summary>
    public interface IHashInterface
    {
        /// <summary>
        /// Кодирование 
        /// </summary>
        /// <param name="data">кодируемое значение</param>
        /// <returns>закодированное значение</returns>
        int Transform(int data);
    }
}
