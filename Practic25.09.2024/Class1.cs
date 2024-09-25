using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic25._09._2024
{
    class OperationTimer { }
    internal class GenericClass<T>
    {
        List<T> list = new List<T>();

        public void Add(T item) {
            list.Add(item);        
        }
        //public T Sum()
        //{
           /* T result = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                result = result.Sum(list[i]);
            }
            return list.Sum();*/
        //}
    }
}
