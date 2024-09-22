using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataHelpers
{
    /// <summary>
    /// Represents a node in a binary tree.
    /// </summary>
    /// <typeparam name="T">The type of the value stored in the node.</typeparam>
    public class BinaryTreeNode<T>
    {
        /// <summary>
        /// Gets the left child of the node.
        /// </summary>
        public BinaryTreeNode<T>? Left { get; private set; }

        /// <summary>
        /// Gets the right child of the node.
        /// </summary>
        public BinaryTreeNode<T>? Right { get; private set; }

        /// <summary>
        /// Gets the value stored in the node.
        /// </summary>
        public T? Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryTreeNode{T}"/> class with a specified value and optional left and right children.
        /// </summary>
        /// <param name="value">The value to be stored in the node.</param>
        /// <param name="left">The left child of the node (default is null).</param>
        /// <param name="right">The right child of the node (default is null).</param>
        public BinaryTreeNode(T value, BinaryTreeNode<T>? left = null, BinaryTreeNode<T>? right = null)
        {
            this.Value = value;
            this.Left = left;
            this.Right = right;
        }

        /// <summary>
        /// Sets the left child of the node.
        /// </summary>
        /// <param name="value">The left child to set.</param>
        public void SetLeft(BinaryTreeNode<T> value) => this.Left = value;

        /// <summary>
        /// Sets the right child of the node.
        /// </summary>
        /// <param name="value">The right child to set.</param>
        public void SetRight(BinaryTreeNode<T> value) => this.Right = value;

        /// <summary>
        /// Sets the value of the node.
        /// </summary>
        /// <param name="value">The value to set.</param>
        public void SetValue(T value) => this.Value = value;

        /// <summary>
        /// Determines whether the node has both left and right children.
        /// </summary>
        /// <returns><c>true</c> if the node has both children; otherwise, <c>false</c>.</returns>
        public bool HasChildren()
        {
            return this.Left != null && this.Right != null;
        }

        /// <summary>
        /// Gets the maximum depth of the tree starting from this node.
        /// </summary>
        /// <returns>The maximum depth of the tree.</returns>
        public int GetMaxTreeDepth()
        {
            return GetMaxDepth(this); // Start from the current node
        }

        /// <summary>
        /// Calculates the maximum depth of the tree recursively.
        /// </summary>
        /// <param name="node">The current node being evaluated.</param>
        /// <returns>The maximum depth of the subtree rooted at the specified node.</returns>
        private static int GetMaxDepth(BinaryTreeNode<T>? node)
        {
            if (node == null)
            {
                return 0; // Base case: empty node contributes 0 depth
            }

            int leftDepth = GetMaxDepth(node.Left);
            int rightDepth = GetMaxDepth(node.Right);

            return Math.Max(leftDepth, rightDepth) + 1;
        }
    }
}
