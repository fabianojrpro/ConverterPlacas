using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string inputFilePath = @"C:\Users\faris\Documents\ConversorPlacasMerco\placas.txt";
        string outputFilePath = Path.Combine(Path.GetDirectoryName(inputFilePath), "PlacasConvertidas.txt");

        List<string> placas = ReadPlatesFromFile(inputFilePath);

        List<string> placas_convertidas = ConvertPlates(placas);

        SavePlatesToFile(placas_convertidas, outputFilePath);

        Console.WriteLine("Conversão concluída! Arquivo de saída: " + outputFilePath);
    }

    static List<string> ReadPlatesFromFile(string filePath)
    {
        List<string> placas = new List<string>();

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                placas.Add(line);
            }
        }

        return placas;
    }

    static List<string> ConvertPlates(List<string> placas)
    {
        List<string> placas_convertidas = new List<string>();

        foreach (string placa in placas)
        {
            string quinto_caractere = placa.Substring(4, 1);

            if (Char.IsDigit(quinto_caractere, 0))
            {
                Dictionary<char, char> digitos = new Dictionary<char, char> {
                    {'0', 'A'}, {'1', 'B'}, {'2', 'C'}, {'3', 'D'}, {'4', 'E'},
                    {'5', 'F'}, {'6', 'G'}, {'7', 'H'}, {'8', 'I'}, {'9', 'J'}
                };

                char quinto_caractere_convertido = digitos[quinto_caractere[0]];
                string placa_convertida = placa.Substring(0, 4) + quinto_caractere_convertido +
                    placa.Substring(5);

                placas_convertidas.Add(placa_convertida);
            }
            else
            {
                placas_convertidas.Add(placa);
            }
        }

        return placas_convertidas;
    }

    static void SavePlatesToFile(List<string> placas, string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (string placa in placas)
            {
                writer.WriteLine(placa);
            }
        }
    }
}

