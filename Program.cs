using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace triplets
{
    class Program
    {

        public static void printTriplets(String input)
        {
            String[] words = input.Split(' ');

            String[] wordsWithoutPunctuation = new String[words.Length];
            int counter = 0;
            //Strip punctuation and throw words into an array
            foreach (String word in words)
            {
                String nopunctuation = System.Text.RegularExpressions.Regex.Replace(word, @"[^\w]", String.Empty);
                wordsWithoutPunctuation[counter] = nopunctuation;
                counter++;
            }

            //Populate triplets array, each phrase contains two words
            String[] triplets = new String[words.Length - 1];
            for (int i = 0; i<wordsWithoutPunctuation.Length; i++)
            {
                if((i + 1) < wordsWithoutPunctuation.Length)
                {
                    triplets[i] = wordsWithoutPunctuation[i] + " " + wordsWithoutPunctuation[i + 1];
                }
            }

            //remove duplicates from triplets array and loop to find any matches
            String[] tempArray = triplets.Distinct().ToArray();
            for (int i = 0; i < tempArray.Length; i++)
            {
                int count = 1;
                for(int j = 0; j < triplets.Length; j++)
                {
                    if(tempArray[i] == triplets[j])
                    {
                        //The the searched phrase is found, increase the counter
                        count++;
                    }
                }
                //Print the phrase and the number of times it was found
                if(count > 2)
                {
                    Console.WriteLine(tempArray[i] + " = " + (count -1));
                }
            }

            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            // This is a triplet program.  It accepts a sentence including punctuation and whitespace.

            Console.WriteLine("Input a sentence");

            printTriplets(Console.ReadLine());
            
        }
    }
}
