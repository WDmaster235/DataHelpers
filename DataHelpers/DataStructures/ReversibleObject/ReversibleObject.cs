using System;
using System.Collections.Generic;

namespace ConsoleApp9
{
    /// <summary>
    /// Acts like a regular variable, but saves every change it goes through so you can reverse it to its previous value.
    /// </summary>
    /// <typeparam name="T">The type of the value stored in the ReversibleObject.</typeparam>
    public class ReversibleObject<T>
    {
        private Stack<T> _stack;
        private T _previous;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReversibleObject{T}"/> class.
        /// </summary>
        public ReversibleObject()
        {
            _stack = new Stack<T>();
            _previous = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReversibleObject{T}"/> class with an initial value.
        /// </summary>
        /// <param name="variable">The initial value to store.</param>
        public ReversibleObject(T variable) : this() { _stack.Push(variable); }

        /// <summary>
        /// Sets the value of the ReversibleObject, saving the current value to allow for reversal.
        /// </summary>
        /// <param name="variable">The new value to set.</param>
        public void Set(T variable)
        {
            if (_stack.Count > 0)
            {
                _previous = _stack.Peek();
            }
            _stack.Push(variable);
        }

        /// <summary>
        /// Reverses the value of the ReversibleObject to the previous value.
        /// </summary>
        public void ReverseToPrevious()
        {
            if (_stack.Count > 1)
            {
                _stack.Pop();
                T temp = _previous;
                _previous = _stack.Pop();
                _stack.Push(temp);
            }
        }

        /// <summary>
        /// Gets the current value of the ReversibleObject.
        /// </summary>
        /// <returns>The current value stored in the object.</returns>
        public T Get() => _stack.Peek();

        /// <summary>
        /// Gets the previous value of the ReversibleObject before the last change.
        /// </summary>
        /// <returns>The previous value stored in the object.</returns>
        public T GetPrevious() => _previous; 

        /// <summary>
        /// A way for the user to access the previous value stored in the object.
        /// </summary>
        public T Previous => _previous;
    }
}
