using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversores
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Seleccione el tipo de conversión:");
                Console.WriteLine("1. Moneda");
                Console.WriteLine("2. Tiempo");
                Console.WriteLine("3. Masa");
                Console.WriteLine("4. Volumen");
                Console.WriteLine("5. Longitud");
                Console.WriteLine("6. Almacenamiento");
                Console.WriteLine("0. Salir");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Convertirmonedas();
                        break;
                    case "2":
                        ConvertirTiempo();
                        break;
                    case "3":
                        ConvertirMasa();
                        break;
                    case "4":
                        ConvertirVolumen();
                        break;
                    case "5":
                        convertirLongitud();
                        break;
                    case "6":
                        ConversionesAlmacenamiento();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }

        static void Convertirmonedas()
        {
            string[] monedas = { "USD", "EUR", "GBP", "JPY", "CAD", "AUD", "CHF", "CNY", "SEK", "NZD" };
            double[,] monedaTarifas = {
    { 1.0, 0.85, 0.76, 110.25, 1.26, 1.34, 0.92, 6.48, 8.63, 1.44 }, // USD
    { 1.18, 1.0, 0.90, 129.80, 1.49, 1.58, 1.08, 7.64, 10.14, 1.69 }, // EUR
    { 1.32, 1.11, 1.0, 144.56, 1.66, 1.76, 1.20, 8.52, 11.31, 1.88 }, // GBP
    { 0.0091, 0.0077, 0.0069, 1.0, 0.011, 0.012, 0.0083, 0.059, 0.078, 0.013 }, // JPY
    { 0.79, 0.67, 0.60, 87.54, 1.0, 1.06, 0.72, 5.14, 6.83, 1.14 }, // CAD
    { 0.75, 0.63, 0.57, 82.76, 0.94, 1.0, 0.68, 4.83, 6.42, 1.07 }, // AUD
    { 1.09, 0.93, 0.83, 120.92, 1.39, 1.47, 1.0, 7.09, 9.42, 1.56 }, // CHF
    { 0.15, 0.13, 0.12, 16.97, 0.19, 0.21, 0.14, 1.0, 1.33, 0.22 }, // CNY
    { 0.12, 0.099, 0.088, 12.82, 0.15, 0.16, 0.11, 0.75, 1.0, 0.16 }, // SEK
    { 0.69, 0.59, 0.53, 73.24, 0.88, 0.93, 0.64, 4.53, 6.13, 1.0 }  // NZD
};

            int from = SelectOption("moneda de origen", monedas);
            int to = SelectOption("moneda de destino", monedas);

            double amount = InputAmount($"la cantidad de {monedas[from]} que desea convertir a {monedas[to]}");
            double result = amount * monedaTarifas[from, to];

            Console.WriteLine($"{amount} {monedas[from]} es igual a {result:F2} {monedas[to]}.");
            ContinuePrompt();
        }

        static void ConvertirTiempo()
        {
            string[] unidadtiempo = { "Segundos", "Minutos", "Horas", "Días", "Semanas", "Meses", "Años", "Milisegundos", "Microsegundos", "Nanosegundos" };
            double[,] tiempoConversiones = {
    { 1.0, 1.0 / 60.0, 1.0 / 3600.0, 1.0 / 86400.0, 1.0 / 604800.0, 1.0 / 2.628e6, 1.0 / 3.154e7, 1000.0, 1e6, 1e9 }, // segundos
    { 60.0, 1.0, 1.0 / 60.0, 1.0 / 1440.0, 1.0 / 10080.0, 1.0 / 43800.0, 1.0 / 525600.0, 60000.0, 6e7, 6e10 }, // minutos
    { 3600.0, 60.0, 1.0, 1.0 / 24.0, 1.0 / 168.0, 1.0 / 730.0, 1.0 / 8760.0, 3.6e6, 3.6e9, 3.6e12 }, // horas
    { 86400.0, 1440.0, 24.0, 1.0, 1.0 / 7.0, 1.0 / 30.44, 1.0 / 365.25, 8.64e7, 8.64e10, 8.64e13 }, // días
    { 604800.0, 10080.0, 168.0, 7.0, 1.0, 1.0 / 4.345, 1.0 / 52.18, 6.048e8, 6.048e11, 6.048e14 }, // semanas
    { 2.628e6, 43800.0, 730.0, 30.44, 4.345, 1.0, 1.0 / 12.0, 2.628e9, 2.628e12, 2.628e15 }, // meses
    { 3.154e7, 525600.0, 8760.0, 365.25, 52.18, 12.0, 1.0, 3.154e10, 3.154e13, 3.154e16 }, // años
    { 0.001, 1.6667e-5, 2.7778e-7, 1.1574e-8, 1.6534e-9, 3.8027e-10, 3.171e-11, 1.0, 1000.0, 1e6 }, // milisegundos
    { 1e-6, 1.6667e-8, 2.7778e-10, 1.1574e-11, 1.6534e-12, 3.8027e-13, 3.171e-14, 0.001, 1.0, 1000.0 }, // microsegundos
    { 1e-9, 1.6667e-11, 2.7778e-13, 1.1574e-14, 1.6534e-15, 3.8027e-16, 3.171e-17, 1e-6, 0.001, 1.0 }  // nanosegundos
};

            int from = SelectOption("unidad de tiempo de origen", unidadtiempo);
            int to = SelectOption("unidad de tiempo de destino", unidadtiempo);

            double amount = InputAmount($"la cantidad de {unidadtiempo[from]} que desea convertir a {unidadtiempo[to]}");
            double result = amount * tiempoConversiones[from, to];

            Console.WriteLine($"{amount} {unidadtiempo[from]} es igual a {result:F2} {unidadtiempo[to]}.");
            ContinuePrompt();
        }

        static void ConvertirMasa()
        {
            string[] UnidadMasa = { "Gramos", "Kilogramos", "Libras", "Onzas", "Toneladas", "Miligramos", "Microgramos", "Quintales", "Piedras", "Carats" };
            double[,] conversionDeMasa = {
    { 1.0, 0.001, 0.002205, 0.035274, 1e-6, 1000.0, 1e6, 1e-5, 0.00015747, 5.0 }, // gramos
    { 1000.0, 1.0, 2.20462, 35.274, 0.001, 1e6, 1e9, 0.01, 0.15747, 5000.0 }, // kilogramos
    { 453.592, 0.453592, 1.0, 16.0, 0.000453592, 453592.0, 4.536e8, 0.00453592, 0.0714286, 2267.96 }, // libras
    { 28.3495, 0.0283495, 0.0625, 1.0, 2.835e-5, 28349.5, 2.835e7, 0.000283495, 0.0044643, 141.748 }, // onzas
    { 1e6, 1000.0, 2204.62, 35274.0, 1.0, 1e9, 1e12, 10.0, 157.473, 5e6 }, // toneladas
    { 0.001, 1e-6, 2.2046e-6, 3.5274e-5, 1e-9, 1.0, 1000.0, 1e-8, 1.5747e-7, 0.005 }, // miligramos
    { 1e-6, 1e-9, 2.2046e-9, 3.5274e-8, 1e-12, 0.001, 1.0, 1e-11, 1.5747e-10, 5e-6 }, // microgramos
    { 100000.0, 100.0, 220.462, 3527.4, 0.1, 1e7, 1e10, 1.0, 15.7473, 500000.0 }, // quintales
    { 6350.29, 6.35029, 14.0, 224.0, 0.00635029, 6.35e6, 6.35e9, 0.0635029, 1.0, 31751.5 }, // piedras
    { 0.2, 0.0002, 0.000440925, 0.00705479, 2e-7, 200.0, 2e5, 0.002, 3.1745e-5, 1.0 }  // carats
};

            int from = SelectOption("unidad de masa de origen", UnidadMasa);
            int to = SelectOption("unidad de masa de destino", UnidadMasa);

            double amount = InputAmount($"la cantidad de {UnidadMasa[from]} que desea convertir a {UnidadMasa[to]}");
            double result = amount * conversionDeMasa[from, to];

            Console.WriteLine($"{amount} {UnidadMasa[from]} es igual a {result:F2} {UnidadMasa[to]}.");
            ContinuePrompt();
        }

        static void ConvertirVolumen()
        {
            string[] unidadDeVolumen = { "Litros", "Mililitros", "Galones", "Pintas", "Cubic Meter", "Cubic Centimeter", "Cubic Foot", "Cubic Inch", "Quarts", "Tablespoons" };
            double[,] ConversionDevolumen = {
    { 1.0, 1000.0, 0.264172, 2.11338, 0.001, 1000.0, 0.0353147, 61.0237, 1.05669, 67.628 }, // litros
    { 0.001, 1.0, 0.000264172, 0.00211338, 1e-6, 1.0, 3.5315e-5, 0.0610237, 0.00105669, 0.067628 }, // mililitros
    { 3.78541, 3785.41, 1.0, 8.0, 0.00378541, 3785.41, 0.133681, 231.0, 4.0, 256.0 }, // galones
    { 0.473176, 473.176, 0.125, 1.0, 0.000473176, 473.176, 0.0167101, 28.875, 0.5, 32.0 }, // pintas
    { 1000.0, 1e6, 264.172, 2113.38, 1.0, 1e6, 35.3147, 61023.7, 1056.69, 67628.0 }, // cubic meter
    { 0.001, 1.0, 0.000264172, 0.00211338, 1e-6, 1.0, 3.5315e-5, 0.0610237, 0.00105669, 0.067628 }, // cubic centimeter
    { 28.3168, 28316.8, 7.48052, 59.8442, 0.0283168, 28316.8, 1.0, 1728.0, 29.9221, 1915.01 }, // cubic foot
    { 0.0163871, 16.3871, 0.004329, 0.034632, 1.6387e-5, 16.3871, 0.000578704, 1.0, 0.017316, 1.10823 }, // cubic inch
    { 0.946353, 946.353, 0.25, 2.0, 0.000946353, 946.353, 0.0334201, 57.75, 1.0, 64.0 }, // quarts
    { 0.0147868, 14.7868, 0.00390625, 0.03125, 1.47868e-5, 14.7868, 0.000521976, 0.902344, 0.015625, 1.0 }  // tablespoons
};

            int from = SelectOption("unidad de volumen de origen", unidadDeVolumen);
            int to = SelectOption("unidad de volumen de destino", unidadDeVolumen);

            double amount = InputAmount($"la cantidad de {unidadDeVolumen[from]} que desea convertir a {unidadDeVolumen[to]}");
            double resultado = amount * ConversionDevolumen[from, to];

            Console.WriteLine($"{amount} {unidadDeVolumen[from]} es igual a {resultado:F2} {unidadDeVolumen[to]}.");
            ContinuePrompt();
        }

        static void convertirLongitud()
        {
            string[] unidadDeLonguitud = { "Metros", "Centímetros", "Kilómetros", "Millas", "Pulgadas", "Pies", "Yardas", "Millas náuticas", "Micrómetros", "Nanómetros" };
            double[,] conversionesDELonguitud = {
    { 1.0, 100.0, 0.001, 0.000621371, 39.3701, 3.28084, 1.09361, 0.000539957, 1e6, 1e9 }, // metros
    { 0.01, 1.0, 1e-5, 6.2137e-6, 0.393701, 0.0328084, 0.0109361, 5.3996e-6, 10000.0, 1e7 }, // centímetros
    { 1000.0, 100000.0, 1.0, 0.621371, 39370.1, 3280.84, 1093.61, 0.539957, 1e9, 1e12 }, // kilómetros
    { 1609.34, 160934.0, 1.60934, 1.0, 63360.0, 5280.0, 1760.0, 0.868976, 1.609e9, 1.609e12 }, // millas
    { 0.0254, 2.54, 2.54e-5, 1.5783e-5, 1.0, 0.0833333, 0.0277778, 1.3715e-5, 25400.0, 2.54e7 }, // pulgadas
    { 0.3048, 30.48, 0.0003048, 0.000189394, 12.0, 1.0, 0.333333, 0.000164579, 304800.0, 3.048e8 }, // pies
    { 0.9144, 91.44, 0.0009144, 0.000568182, 36.0, 3.0, 1.0, 0.000493737, 914400.0, 9.144e8 }, // yardas
    { 1852.0, 185200.0, 1.852, 1.15078, 72913.4, 6076.12, 2025.37, 1.0, 1.852e9, 1.852e12 }, // millas náuticas
    { 1e-6, 0.001, 1e-9, 6.2137e-10, 3.937e-5, 3.2808e-7, 1.0936e-7, 5.3996e-10, 1.0, 1000.0 }, // micrómetros
    { 1e-9, 1e-6, 1e-12, 6.2137e-13, 3.937e-8, 3.2808e-9, 1.0936e-9, 5.3996e-13, 0.001, 1.0 }  // nanómetros
};

            int from = SelectOption("unidad de longitud de origen", unidadDeLonguitud);
            int to = SelectOption("unidad de longitud de destino", unidadDeLonguitud);

            double amount = InputAmount($"la cantidad de {unidadDeLonguitud[from]} que desea convertir a {unidadDeLonguitud[to]}");
            double result = amount * conversionesDELonguitud[from, to];

            Console.WriteLine($"{amount} {unidadDeLonguitud[from]} es igual a {result:F2} {unidadDeLonguitud[to]}.");
            ContinuePrompt();
        }

        static void ConversionesAlmacenamiento()
        {
            string[] UnidadDeAlmacenamiento = { "Bytes", "Kilobytes", "Megabytes", "Gigabytes", "Terabytes", "Petabytes", "Exabytes", "Zettabytes", "Yottabytes", "Bits" };
            double[,] ConversionDeAlmacenamiento = {
    { 1.0, 0.001, 1e-6, 1e-9, 1e-12, 1e-15, 1e-18, 1e-21, 1e-24, 8.0 }, // bytes
    { 1000.0, 1.0, 0.001, 1e-6, 1e-9, 1e-12, 1e-15, 1e-18, 1e-21, 8000.0 }, // kilobytes
    { 1e6, 1000.0, 1.0, 0.001, 1e-6, 1e-9, 1e-12, 1e-15, 1e-18, 8e6 }, // megabytes
    { 1e9, 1e6, 1000.0, 1.0, 0.001, 1e-6, 1e-9, 1e-12, 1e-15, 8e9 }, // gigabytes
    { 1e12, 1e9, 1e6, 1000.0, 1.0, 0.001, 1e-6, 1e-9, 1e-12, 8e12 }, // terabytes
    { 1e15, 1e12, 1e9, 1e6, 1000.0, 1.0, 0.001, 1e-6, 1e-9, 8e15 }, // petabytes
    { 1e18, 1e15, 1e12, 1e9, 1e6, 1000.0, 1.0, 0.001, 1e-6, 8e18 }, // exabytes
    { 1e21, 1e18, 1e15, 1e12, 1e9, 1e6, 1000.0, 1.0, 0.001, 8e21 }, // zettabytes
    { 1e24, 1e21, 1e18, 1e15, 1e12, 1e9, 1e6, 1000.0, 1.0, 8e24 }, // yottabytes
    { 0.125, 0.000125, 1.25e-7, 1.25e-10, 1.25e-13, 1.25e-16, 1.25e-19, 1.25e-22, 1.25e-25, 1.0 } // bits
};

            int from = SelectOption("unidad de almacenamiento de origen", UnidadDeAlmacenamiento);
            int to = SelectOption("unidad de almacenamiento de destino", UnidadDeAlmacenamiento);

            double amount = InputAmount($"la cantidad de {UnidadDeAlmacenamiento[from]} que desea convertir a {UnidadDeAlmacenamiento[to]}");
            double result = amount * ConversionDeAlmacenamiento[from, to];

            Console.WriteLine($"{amount} {UnidadDeAlmacenamiento[from]} es igual a {result:F2} {UnidadDeAlmacenamiento[to]}.");
            ContinuePrompt();
        }

        static int SelectOption(string prompt, string[] options)
        {
            Console.WriteLine($"Seleccione la {prompt}:");
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i}. {options[i]}");
            }
            return int.Parse(Console.ReadLine());
        }

        static double InputAmount(string prompt)
        {
            Console.WriteLine($"Ingrese {prompt}:");
            return double.Parse(Console.ReadLine());
        }

        static void ContinuePrompt()
        {
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
