using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpUnityClass_0206
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("숫자 2개를 입력해 주세요.");
            int numberA = System.Convert.ToInt32(System.Console.ReadLine());
            int numberB = System.Convert.ToInt32(System.Console.ReadLine());

            System.Console.WriteLine($"{numberA} + {numberB} = {numberA + numberB}");
            System.Console.WriteLine($"{numberA} - {numberB} = {numberA - numberB}");
            System.Console.WriteLine($"{numberA} * {numberB} = {numberA * numberB}");
            System.Console.WriteLine($"{numberA} / {numberB} = {numberA / numberB}");
            System.Console.WriteLine($"{numberA} % {numberB} = {numberA % numberB}\n");

            System.Console.WriteLine("숫자 1개를 입력해 주세요.");
            int numberC = System.Convert.ToInt32(System.Console.ReadLine());

            System.Console.WriteLine($"{numberC} += 3 -> {numberC += 3}");
            System.Console.WriteLine($"{numberC} -= 3 -> {numberC -= 3}");
            System.Console.WriteLine($"{numberC} *= 3 -> {numberC *= 3}");
            System.Console.WriteLine($"{numberC} /= 3 -> {numberC /= 3}");
            System.Console.WriteLine($"{numberC} %= 3 -> {numberC %= 3}\n");

            System.Console.WriteLine($"number   = {numberC}");
            System.Console.WriteLine($"++number = {++numberC}");
            System.Console.WriteLine($"number++ = {numberC++}");
            System.Console.WriteLine($"number   = {numberC}");
            System.Console.WriteLine($"--number = {--numberC}");
            System.Console.WriteLine($"number-- = {numberC--}");
            System.Console.WriteLine($"number   = {numberC}");
        }
    }
}
