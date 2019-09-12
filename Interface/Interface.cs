
namespace Interface
{
    public interface IStack
    {
        //Количество элементов
        int Size { get; }

        /// <summary>
        /// Добавляет число
        /// </summary>
        /// <param name="symbol">число</param>
        /// <returns>true, если добавление прошло успешно</returns>
        bool Add(string symbol);

        /// <summary>
        /// Возвращает количество чисел
        /// </summary>
        int GetSize();

        /// <summary>
        /// Применение соответствующей операции
        /// </summary>
        /// <param name="symbol"></param>
        void Operate(string symbol);

        /// <summary>
        /// Выводит результат вычислений, если выражение было синтаксически завершено
        /// </summary>
        string Print();

        /// <summary>
        /// Распечатывает все элементы, находящиеся внутри калькулятора
        /// </summary>
        string PrintList();

        /// <summary>
        /// Очистка
        /// </summary>
        void Clear();
    }
}
