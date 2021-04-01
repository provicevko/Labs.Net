using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab2.Components;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Operator operatorPlus = new('+');
            Operator operatorSubstract = new('-');
            Operator operatorMultiply = new('*');
            operatorSubstract.Add(new Constant(8), new Variable("abra"));
            operatorMultiply.Add(operatorSubstract, new Constant(546));
            operatorPlus.Add(operatorMultiply, new Variable("x"));

            Console.WriteLine(operatorSubstract.ExpressionBuild());
            Console.WriteLine(operatorMultiply.ExpressionBuild());
            Console.WriteLine(operatorPlus.ExpressionBuild());
        }










        //GetTree(operatorPlus);
        //private static void GetTree(Operator opOperator)
        //{
        //    Console.WriteLine($"(operator {opOperator.Value})");
        //    foreach (var element in opOperator)
        //    {
        //        if (element is Operator op)
        //            GetTree(op);
        //        else if (element is Variable variable)
        //            Console.Write(variable.Value + " ");
        //        else if (element is Constant constant)
        //            Console.Write(constant.Value + " ");
        //    }
        //    Console.WriteLine();
        //}
    }
}
