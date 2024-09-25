using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic25._09._2024
{
    internal sealed class OperatrionTimer: IDisposable {
        long _startTime;
        string _text;
        int _collectionCount;
        public OperatrionTimer() { }
        public OperatrionTimer(string text) {
            PrepareForOperation();
            this._text = text;
            _collectionCount = GC.CollectionCount(0);
            _startTime = Stopwatch.GetTimestamp();
        }

        public void Dispose() {
            Console.WriteLine($"{_text}\t" +
                $"{(Stopwatch.GetTimestamp() - _startTime) / Stopwatch.Frequency:0.00} сек.\n " +
                $"мусор: {GC.CollectionCount(0) - _collectionCount}");
        }

        public static void PrepareForOperation()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        } 
    }
    internal class Program
    {
        public static void ValueTypePerfTest()
        {
            const int COUNT = 100_000_000;

            using (new OperatrionTimer("List"))
            {
                List<int> ints = new List<int>();
                for (int i = 0; i < COUNT; i++)
                {
                    ints.Add(i);
                    int x = ints[i];
                }
                ints = null;
            }
            using (new OperatrionTimer("ArrayList"))
            {
                ArrayList arrayInts = new ArrayList();
                for (int i = 0; i < COUNT; i++)
                {
                    arrayInts.Add(i);
                    int x = (int)arrayInts[i];
                }
                arrayInts = null;
            }
         
        }
        static void Main(string[] args)
        {
            // необобщенные коллекции
            /*            ArrayList arrayList = new ArrayList();          
                        arrayList.Add("one");                    
                        arrayList.AddRange(new int[] {4,5,7,7});
                        arrayList.Add(true);
                        arrayList.Add(56.8);
                        arrayList.Add(56.8);*/
            /*Console.WriteLine(arrayList.Capacity);
            Console.WriteLine(arrayList.Count);

            arrayList.Capacity = 10;
            Console.WriteLine(arrayList.Capacity);

            Console.WriteLine(arrayList[6]);

            arrayList.TrimToSize();
            Console.WriteLine(arrayList.Capacity);*/
            /*            arrayList.Insert(3, 'v');

                        foreach(var item in arrayList)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine();
                        arrayList.Remove(7);

                        foreach (var item in arrayList)
                        {
                            Console.WriteLine(item);
                        }
                        arrayList.Sort();
                        foreach (var item in arrayList)
                        {
                            Console.WriteLine(item);
                        }*/
            //ArrayList, Stack, Queue,      HashTable,                  SortedList
            //List<T>,   Stack<>,Queue<>,   Distionary<TKey, TValue>    SortedList<TKey, TValue>                 

            //ValueTypePerfTest();

            /*Dictionary<string, int> pairs = new Dictionary<string, int>()
            {
                ["gr1"] = 45
            };

            pairs["gr2"] = 76;
            try
            {
                pairs.Add("gr2", 44);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex);
            }

            foreach (KeyValuePair<string, int> pair in pairs)
            {
                Console.WriteLine(pair.Key + " - " + pair.Value);
            }

            Console.WriteLine();

            foreach (string keys in pairs.Keys)
            {
                Console.WriteLine(keys);
            }

            Console.WriteLine();

            foreach (int values in pairs.Values)
            {
                Console.WriteLine(values);
            }

            int val; 
            if(pairs.TryGetValue("gr2", out val))
                Console.WriteLine(val);*/

            GenericClass<OperatrionTimer> genericClass = new GenericClass<OperatrionTimer>();

            
        }
    }
}
