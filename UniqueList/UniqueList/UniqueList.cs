using _2._1;
using System;

namespace UniqueList
{
    /// <summary>
    /// Односвязный список с уникальными элементами`
    /// </summary>
    public class UniqueList : List
    {
        /// <summary>
        /// Добавление с проверкой на уникальность
        /// </summary>
        /// <param name="position">заданная позиция</param>
        /// <param name="data">здаваемое значение</param>
        /// <returns>true, если добавление было успешным</returns>
        public override bool Add(int position, int data)
        {
            if (Count(data))
            {
                throw new UniqueElementException();
            }
            return base.Add(position, data);
        }

        /// <summary>
        /// Установка значения с проверкой на уникальность
        /// </summary>
        /// <param name="position">заданная позиция</param>
        /// <param name="data">устанавливаемое значение</param>
        /// <returns>true, если установка была успешной</returns>
        public override bool Dataset(int position, int data)
        {
            if (Count(data))
            {
                throw new UniqueElementException();
            }
            return base.Dataset(position, data);
        }

    }

    /// <summary>
    /// Исключение для дублирующихся элементов
    /// </summary>
    public class UniqueElementException : Exception
    {
    }

    

}
