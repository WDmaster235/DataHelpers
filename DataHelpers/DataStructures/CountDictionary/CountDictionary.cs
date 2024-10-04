using System;
using System.Collections.Generic;

namespace DataHelpers
{
    /// <summary>
    /// A specialized dictionary that tracks the number of times a key is added.
    /// Supports only string and primitive types for both keys and values.
    /// </summary>
    /// <typeparam name="T">Type of the key (primitive or string).</typeparam>
    /// <typeparam name="K">Type of the value (primitive or string).</typeparam>
    public class CountDictionary<T, K>
    {
        private Dictionary<T, K> Dict;
        private Dictionary<T, int> CountDict;
        public HashSet<T> Keys { get; private set; }
        public HashSet<K> Values { get; private set; }
        public int Count { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CountDictionary{T, K}"/> class.
        /// Throws an exception if the types are not string or primitive types.
        /// </summary>
        public CountDictionary()
        {
            if (!((typeof(T).IsPrimitive || typeof(T) == typeof(string)) && (typeof(K).IsPrimitive || typeof(K) == typeof(string))))
                throw new DataHelpersException("CountDictionary only supports string and primitive types");

            Dict = new Dictionary<T, K>();
            CountDict = new Dictionary<T, int>();
            Keys = new HashSet<T>();
            Values = new HashSet<K>();
            Count = 0;
        }

        /// <summary>
        /// Adds a key-value pair to the dictionary.
        /// If the key already exists, increments the count of the existing entry.
        /// Throws an exception if the key exists with a different value.
        /// </summary>
        /// <param name="key">The key to add.</param>
        /// <param name="value">The value associated with the key.</param>
        public void Add(T key, K value)
        {
            if (Dict.ContainsKey(key) && !Dict[key].Equals(value))
                throw new DataHelpersException("You can't add a new value to an existing key");

            if (Dict.ContainsKey(key))
            {
                CountDict[key]++;
            }
            else
            {
                Count++;
                Dict.Add(key, value);
                Keys.Add(key);
                Values.Add(value);
                CountDict.Add(key, 1);
            }
        }

        /// <summary>
        /// Forces the addition or update of a key-value pair. 
        /// If the key already exists, increments the count.
        /// </summary>
        /// <param name="key">The key to add or update.</param>
        /// <param name="value">The new value to associate with the key.</param>
        public void ForceAdd(T key, K value)
        {
            if (Dict.ContainsKey(key))
            {
                CountDict[key]++;
            }
            else
            {
                Count++;
                Dict.Add(key, value);
                Keys.Add(key);
                Values.Add(value);
                CountDict.Add(key, 1);
            }
        }

        /// <summary>
        /// Adds a key-value pair. 
        /// If the key already exists, replaces the value and increments the count.
        /// </summary>
        /// <param name="key">The key to add or update.</param>
        /// <param name="value">The new value to associate with the key.</param>
        public void OverrideAdd(T key, K value)
        {
            if (Dict.ContainsKey(key))
            {
                CountDict[key]++;
                Values.Remove(Dict[key]);
                Values.Add(value);
                Dict.Remove(key);
                Dict.Add(key, value);
            }
            else
            {
                Count++;
                Dict.Add(key, value);
                Keys.Add(key);
                Values.Add(value);
                CountDict.Add(key, 1);
            }
        }

        /// <summary>
        /// Removes a key and its associated value from the dictionary.
        /// If the key has been added multiple times, decrements its count.
        /// Throws an exception if the key does not exist.
        /// </summary>
        /// <param name="key">The key to remove.</param>
        public void Remove(T key)
        {
            if (Dict.ContainsKey(key))
            {
                CountDict[key]--;

                if (CountDict[key] == 0)
                {
                    Values.Remove(Dict[key]);
                    Dict.Remove(key);
                    Keys.Remove(key);
                    CountDict.Remove(key);
                    Count--;
                }
            }
            else
                throw new DataHelpersException("You can't remove by key that does not exist, instead you can try using the function CountDictionary.TryRemove()");
        }

        /// <summary>
        /// Tries to remove a key from the dictionary.
        /// If the key exists, decrements its count or removes it entirely.
        /// </summary>
        /// <param name="key">The key to try removing.</param>
        /// <returns>True if the key was found and removed, false otherwise.</returns>
        public bool TryRemove(T key)
        {
            if (Dict.ContainsKey(key))
            {
                CountDict[key]--;

                if (CountDict[key] == 0)
                {
                    Values.Remove(Dict[key]);
                    Dict.Remove(key);
                    Keys.Remove(key);
                    CountDict.Remove(key);
                    Count--;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// Throws an exception if the key does not exist.
        /// </summary>
        /// <param name="key">The key whose value to retrieve.</param>
        /// <returns>The value associated with the key.</returns>
        public K GetValue(T key)
        {
            if (Dict.ContainsKey(key))
                return Dict[key];
            throw new DataHelpersException("This dictionary does not contain this key");
        }

        /// <summary>
        /// Clears all entries from the dictionary.
        /// </summary>
        public void Clear()
        {
            Dict = new Dictionary<T, K>();
            CountDict = new Dictionary<T, int>();
            Keys = new HashSet<T>();
            Values = new HashSet<K>();
            Count = 0;
        }

        /// <summary>
        /// Determines if the dictionary contains the specified key.
        /// </summary>
        /// <param name="key">The key to locate in the dictionary.</param>
        /// <returns>True if the dictionary contains the key, false otherwise.</returns>
        public bool ContainsKey(T key)
        {
            return Keys.Contains(key);
        }

        /// <summary>
        /// Determines if the dictionary contains the specified value.
        /// </summary>
        /// <param name="value">The value to locate in the dictionary.</param>
        /// <returns>True if the dictionary contains the value, false otherwise.</returns>
        public bool ContainsValue(K value)
        {
            return Values.Contains(value);
        }

        /// <summary>
        /// Gets the number of times the specified key has been added.
        /// Throws an exception if the key does not exist.
        /// </summary>
        /// <param name="key">The key to get the entry count for.</param>
        /// <returns>The number of times the key has been added.</returns>
        public int GetEntryAmount(T key)
        {
            if (!Dict.ContainsKey(key))
                throw new DataHelpersException("This dictionary does not contain this key");
            return CountDict[key];
        }

        /// <summary>
        /// Tries to get the number of times the specified key has been added.
        /// If the key does not exist, returns 0.
        /// </summary>
        /// <param name="key">The key to get the entry count for.</param>
        /// <returns>The number of times the key has been added, or 0 if the key does not exist.</returns>
        public int TryGetEntryAmount(T key)
        {
            if (!Dict.ContainsKey(key))
                return 0;
            return CountDict[key];
        }
    }
}