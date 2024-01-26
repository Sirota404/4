using System;
using System.Collections.Generic;

namespace clas
{
    public class Program
    {

        private static void Main()
        {
            var s = new Stack("a", "b", "c");
            // size = 3, Top = 'c'
            Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");
            var deleted = s.Pop();
            // Извлек верхний элемент 'c' Size = 2
            Console.WriteLine($"Извлек верхний элемент '{deleted}' Size = {s.Size}");
            s.Add("d");
            // size = 3, Top = 'd'
            Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");
            s.Pop();
            s.Pop();
            s.Pop();
            // size = 0, Top = null
            Console.WriteLine($"size = {s.Size}, Top = {(s.Top == null ? "null" : s.Top)}");
            s.Pop();

            s = new Stack("a", "b", "c");
            s.Merge(new Stack("1", "2", "3"));
            Stack.Print(s);
            s = Stack.Concat(new Stack("a", "b", "c"), new Stack("1", "2", "3"), new Stack("А", "Б", "В"));
            Stack.Print(s);
        }
        public class Stack
        {
            public List<string> stack = new List<string>();


            //Конструктор
            public Stack(params string[] inputs)
            {
                for (int i = 0; i < inputs.Length; i++)
                {
                    stack.Add(inputs[i]);
                }
            }
            public void Add(string c)
            {
                stack.Add(c);
            }
            public string Pop()
            {
                if (stack.Count != 0)
                {
                    var c = stack[stack.Count - 1];
                    stack.RemoveAt(stack.Count - 1);
                    return c;
                }
                else
                {
                    throw new Exception("Список пуст!");
                }
            }
            public int Size
            {
                get
                {
                    return stack.Count;
                }

            }
            public string Top
            {
                get
                {
                    if (stack.Count != 0)
                    {
                        return stack[stack.Count - 1];
                    }
                    else
                    { return null; }


                }

            }
            public static Stack Concat(params Stack[] inputs)
            {
                var a = new Stack();
                for (int i = 0; i < inputs.Length; i++)
                {
                    a.Merge(inputs[i]);
                }
                return a;
            }
            public static void Print(Stack stack)
            {
                for (int i = 0; i < stack.Size; i++)
                {
                    Console.Write(stack.stack[i]);
                }
                Console.WriteLine();
            }
        }
       

    }
    public static class StackExtensions
    {
        public static void Merge(this Program.Stack stack, Program.Stack c)
        {
            var j = c.Size;
            c.stack.Reverse(c.stack.Count, 0);
            for (int i = 0; i < j; i++)
            {
                stack.Add(c.Top);
                c.stack.RemoveAt(c.stack.Count - 1);
            }
        }
    }

}
