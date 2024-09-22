using System;
using System.Collections;
using System.Collections.Generic;

namespace DataHelpers
{
    /// <summary>
    /// A stack data structure that behaves like a circular buffer. 
    /// Once it reaches its maximum capacity, it will overwrite the oldest elements.
    /// </summary>
    /// <typeparam name="T">The type of elements in the stack.</typeparam>
    public class CircularStack<T> : IEnumerable<T>
    {
        private readonly T[] _array;
        private int _top;
        private int _count;

        /// <summary>
        /// Initializes a new instance of the <see cref="CircularStack{T}"/> class with the specified capacity.
        /// </summary>
        /// <param name="capacity">The maximum number of elements the stack can hold.</param>
        public CircularStack(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be greater than zero.");

            _array = new T[capacity];
            _top = -1;
            _count = 0;
        }

        /// <summary>
        /// Gets the maximum capacity of the circular stack.
        /// </summary>
        public int Capacity => _array.Length;

        /// <summary>
        /// Gets the current number of elements in the stack.
        /// </summary>
        public int Count => _count;

        /// <summary>
        /// Adds an item to the top of the stack. If the stack has reached its capacity, it will overwrite the oldest item.
        /// </summary>
        /// <param name="item">The item to add to the stack.</param>
        public void Push(T item)
        {
            _top = (_top + 1) % Capacity; // Move the pointer to the next index
            _array[_top] = item;

            if (_count < Capacity)
                _count++;
        }

        /// <summary>
        /// Removes and returns the top item from the stack.
        /// </summary>
        /// <returns>The item removed from the top of the stack.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the stack is empty.</exception>
        public T Pop()
        {
            if (_count == 0)
                throw new InvalidOperationException("The stack is empty.");

            T item = _array[_top];
            _array[_top] = default; // Clear the reference
            _top = (_top - 1 + Capacity) % Capacity;
            _count--;

            return item;
        }

        /// <summary>
        /// Returns the top item from the stack without removing it.
        /// </summary>
        /// <returns>The item at the top of the stack.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the stack is empty.</exception>
        public T Peek()
        {
            if (_count == 0)
                throw new InvalidOperationException("The stack is empty.");

            return _array[_top];
        }

        /// <summary>
        /// Returns an enumerator that iterates through the circular stack.
        /// </summary>
        /// <returns>An enumerator for the circular stack.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                yield return _array[(_top - i + Capacity) % Capacity];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

