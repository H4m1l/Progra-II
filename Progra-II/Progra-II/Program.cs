using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progra_II
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //prioridad de los operadores aritmeticos.
            //ejercicio de obtener la nota final de la materia de programación II.
            Console.WriteLine("lab1:");
            double lab1 = double.Parse(Console.ReadLine()); //8

            Console.WriteLine("lab2:");
            double lab2 = double.Parse(Console.ReadLine()); //9

            Console.WriteLine("parcial1:");
            double parcial1 = double.Parse(Console.ReadLine()); //7

            //8+30%= 2.4
            //9*30%= 2.7
            //7*40%= 2.8
            //c1   = 7.9

            double c1 = lab1 * 30 / 100 + lab2 * 30 / 100 + parcial1 * 40 / 100;
            Console.WriteLine("La nota de c1 es: {0}", c1);
            //pausa
            Console.ReadLine();
        }
    }
}
