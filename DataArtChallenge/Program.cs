using System;
using System.Collections.Generic;

namespace DataArtChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            stack.Push(3);
            stack.Push(5);
            stack.Push(1);

            PrintStack(stack, "ORIGINAL STACK");

            SortStack(stack);
            PrintStack(stack, "SORTED STACK");
        }

        private static void SortStack(Stack<int> stack)
        {
            if (stack == null)
                throw new ArgumentNullException(nameof(stack));

            if (stack.Count > 0)
            {
                int tempElement = stack.Pop();
                SortStack(stack);
                PushSorted(stack, tempElement);
            }
        }

        private static void PushSorted(Stack<int> stack, int element)
        {
            if (stack == null)
                throw new ArgumentNullException(nameof(stack));

            if (stack.Count == 0 || element > stack.Peek())
            {
                stack.Push(element);
            }
            else
            {
                int tempElement = stack.Pop();
                PushSorted(stack, element);
                stack.Push(tempElement);
            }
        }

        private static void PrintStack(Stack<int> stack, string title)
        {
            if (stack == null)
                throw new ArgumentNullException(nameof(stack));

            Console.WriteLine("------------------------------------");
            Console.WriteLine(title);
            Console.WriteLine("------------------------------------");

            foreach (int element in stack)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine();
        }
    }
}
