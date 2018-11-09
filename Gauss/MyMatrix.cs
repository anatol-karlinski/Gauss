using System;
using System.Collections.Generic;
using System.Linq;

namespace Gauss
{
    internal class MyMatrix<T>
        where T : ICloneable
    {
        public List<T> Content;
        public int Rows;
        public int Columns;

        public dynamic ConvertFractionToType(FractionType fractionType)
        {
            switch (typeof(T).FullName)
            {
                case "System.Int32":
                    return (int) fractionType;
                case "System.Double":
                    return (double) fractionType;
                case "System.Single":
                    return (float) fractionType;
                default:
                    throw new InvalidCastException();
            }
        }

        public T GetValue(int x, int y) => Content.ElementAt(Columns * Rows + Rows);

        public MyMatrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Content = new List<T>();
            var seed = new Random();

            for (int i = 0; i < rows * columns; i++)
            {
                int random = seed.Next(-65536, 65535);
                var fraction = ConvertFractionToType(new FractionType(random, 65536));
                Content.Add(fraction);
            }
        }

        public MyMatrix(MyMatrix<T> matrix)
        {
            Content = matrix.Content.Select(item => (T) item.Clone()).ToList();
            Columns = matrix.Columns;
            Rows = matrix.Rows;
        }
    }
}
