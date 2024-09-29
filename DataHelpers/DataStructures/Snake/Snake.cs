using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHelpers
{
    /// <summary>
    /// Represents a Snake data structure, which is a collection of nodes connected in sequence.
    /// </summary>
    /// <typeparam name="T">The type of elements stored in the Snake.</typeparam>
    public class Snake<T>
    {
        /// <summary>
        /// The head node of the Snake.
        /// </summary>
        private Node<T> _Head;

        /// <summary>
        /// Gets the number of nodes in the Snake.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Initializes a new Snake with two elements.
        /// </summary>
        /// <param name="value1">The value of the head node.</param>
        /// <param name="value2">The value of the second node.</param>
        public Snake(T value1, T value2)
        {
            Count = 1;
            this._Head = new Node<T>(value1);
            this.AddNode(value2);
        }

        /// <summary>
        /// Initializes a new Snake with default values for two elements.
        /// </summary>
        public Snake()
        {
            Count = 1;
            this._Head = new Node<T>(default);
            this.AddNode(default);
        }

        /// <summary>
        /// Sets the value of the head node.
        /// </summary>
        /// <param name="value">The value to set as the head.</param>
        public void Head(T value)
        {
            this._Head.Value = value;
        }

        /// <summary>
        /// Gets the value of the head node.
        /// </summary>
        /// <returns>The value of the head node.</returns>
        public T Head()
        {
            return _Head.Value;
        }

        /// <summary>
        /// Sets the value of the tail node (the last node in the Snake).
        /// </summary>
        /// <param name="value">The value to set as the tail.</param>
        public void Tail(T value)
        {
            Node<T> temp = this._Head;

            while (temp.Back != null)
                temp = temp.Back;

            temp.Value = value;
        }

        /// <summary>
        /// Gets the value of the tail node (the last node in the Snake).
        /// </summary>
        /// <returns>The value of the tail node.</returns>
        public T Tail()
        {
            Node<T> temp = this._Head;

            while (temp.Back != null)
                temp = temp.Back;

            return temp.Value;
        }

        /// <summary>
        /// Checks whether the Snake contains a specific value.
        /// </summary>
        /// <param name="value">The value to check for.</param>
        /// <returns>True if the value exists in the Snake, otherwise false.</returns>
        public bool Contains(T value)
        {
            Node<T> temp = this._Head;

            if (_Head.Value.Equals(value)) return true;

            while (temp.Back != null)
            {
                temp = temp.Back;
                if (temp.Value.Equals(value)) return true;
            }
            return false;
        }

        /// <summary>
        /// Adds a new node with the specified value to the end of the Snake.
        /// </summary>
        /// <param name="value">The value to add.</param>
        public void AddNode(T value)
        {
            Node<T> temp = this._Head;
            while (temp.Back != null)
                temp = temp.Back;
            temp.Back = new Node<T>(value);
            Count++;
        }

        /// <summary>
        /// Removes the last node from the Snake.
        /// Throws an exception if there are two or fewer nodes in the Snake.
        /// </summary>
        /// <exception cref="Exception">Thrown when there are two or fewer nodes.</exception>
        public void RmvNode()
        {
            if (Count <= 2) throw new Exception("No nodes to remove");

            Node<T> temp = this._Head;
            while (temp.Back.Back != null)
                temp = temp.Back;
            temp.Back = null;
            Count--;
        }

        /// <summary>
        /// Converts the Snake to an array of values.
        /// </summary>
        /// <returns>An array of the values in the Snake.</returns>
        public T[] ToArray()
        {
            T[] arr = new T[this.Count];

            Node<T> temp = this._Head;
            int counter = 0;
            while (temp.Back != null)
            {
                arr[counter] = temp.Value;
                counter++;
                temp = temp.Back;
            }

            arr[counter] = temp.Value;

            return arr;
        }

        /// <summary>
        /// Returns a string representation of the Snake.
        /// </summary>
        /// <returns>A string that represents the Snake.</returns>
        public override string ToString()
        {
            return $"(:{_Head.ToString()}";
        }

        /// <summary>
        /// Represents a node in the Snake, containing a value and a reference to the next node.
        /// </summary>
        /// <typeparam name="T">The type of value stored in the node.</typeparam>
        private class Node<T>
        {
            /// <summary>
            /// Gets or sets the value of the node.
            /// </summary>
            public T Value { get; set; }

            /// <summary>
            /// Gets or sets the reference to the next node (Back) in the Snake.
            /// </summary>
            public Node<T> Back { get; set; }

            /// <summary>
            /// Initializes a new node with the specified value.
            /// </summary>
            /// <param name="value">The value of the node.</param>
            public Node(T value)
            {
                this.Value = value;
                this.Back = null;
            }

            /// <summary>
            /// Returns a string representation of the node.
            /// </summary>
            /// <returns>A string that represents the node.</returns>
            public override string ToString()
            {
                if (this.Back != null) return $"{Value}={Back}";
                return $"{Value}";
            }
        }
    }
}
