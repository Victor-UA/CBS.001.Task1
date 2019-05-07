using System;
using System.Collections;

namespace Task01
{
    static class CollectionPlus
    {                
        public static IEnumerable Skip(this IEnumerable collection, int n)
        {            
            int i = 0;            
            foreach (var item in collection)
            {
                if (i >= n)
                {
                    yield return item;                    
                }                
                i++;
            }            
        }

        public static IEnumerable Take(this IEnumerable collection, int n)
        {
            int i = 0;
            foreach (var item in collection)
            {
                if (i < n)
                {
                    yield return item;
                }
                else
                {
                    break;
                }
                i++;
            }            
        }

        public static IEnumerable Distinct(this IEnumerable collection)
        {
            object[] resultArray = new object[1];
            int i = 0;
            foreach (var item in collection)
            {
                bool unique = true;
                foreach (var arrayItem in resultArray)
                {
                    if (item.Equals(arrayItem))
                    {
                        unique = false;                        
                        break;
                    }
                }
                if (unique)
                {
                    ArrayAdd(ref resultArray, item, i++);
                }
            }
            ArrayResize(ref resultArray, i);
            return resultArray;
        }

        public static void PrintToConsole(this IEnumerable collection)
        {
            if (collection != null)
            {
                foreach (var item in collection)
                {
                    Console.WriteLine($"[{item}]");
                }
            }
            else
            {
                Console.WriteLine("NULL");
            }
            Console.WriteLine();
        }

        private static void ArrayAdd(ref object[] source, object element, int index)
        {
            if (index >= source.Length)
            {
                int newLength = (int)(source.Length * 1.5 + 1);
                ArrayResize(ref source, newLength);
            }
            source[index] = element;                
        }

        private static void ArrayResize(ref object[] source, int length, int indexFrom = 0)
        {
            if (length < 0)
            {
                source = new object[0];
            }
            else
            {
                object[] result = new object[length];
                if (source.Length - indexFrom > result.Length)
                {
                    for (int i = 0; i < length; i++)
                    {
                        result[i] = source[i + indexFrom];
                    }
                }
                else
                {
                    source.CopyTo(result, indexFrom);
                }
                source = result;
            }
        }

        #region Array additions
        private static object[] Add(this object[] source, object element, int index)
        {
            if (index > source.Length)
            {
                int newLength = (int)(source.Length * 1.5);
                object[] resultArray = source.Resize(newLength);
                resultArray[index] = element;
                return resultArray;
            }
            else
            {
                source[index] = element;
                return source;
            }
        }

        private static object[] Resize(this object[] source, int length, int indexFrom = 0)
        {
            if (length < 0)
            {
                return new object[0];
            }
            object[] result = new object[length];
            if (source.Length - indexFrom > result.Length)
            {
                for (int i = 0; i < length; i++)
                {
                    result[i] = source[i + indexFrom];
                }
            }
            else
            {
                source.CopyTo(result, indexFrom);
            }
            return result;
        }
        #endregion        
    }
}
