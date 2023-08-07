using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CharacterRankingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o caminho completo do arquivo de texto sem ASPAS ex:(C:\\Users\\arquivos\\textoaserlido.txt):");
            string filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Arquivo não encontrado.");
                return;
            }

            string content = File.ReadAllText(filePath);
            Dictionary<char, int> charCount = CountCharacters(content);

            Console.WriteLine("Ranking de caracteres:");
            foreach (var kvp in charCount.OrderByDescending(kvp => kvp.Value))
            {
                Console.WriteLine($"Caractere: '{kvp.Key}', Quantidade: {kvp.Value}");
            }
        }

        static Dictionary<char, int> CountCharacters(string text)
        {
            Dictionary<char, int> charCount = new Dictionary<char, int>();

            foreach (char c in text)
            {
                if (char.IsLetterOrDigit(c))
                {
                    if (charCount.ContainsKey(c))
                    {
                        charCount[c]++;
                    }
                    else
                    {
                        charCount[c] = 1;
                    }
                }
            }

            return charCount;
        }
    }
}
