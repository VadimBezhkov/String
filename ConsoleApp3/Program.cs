using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"\..\MyTest.txt";

            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                string[] createText = { "Hello", "My name", "Vadim" };
                File.WriteAllLines(path, createText);
            }

            //We drive the file text into an array
            string[] readText = File.ReadAllLines(path);

            //Repeating menu output
            while (true)
            {
                String myName = "Hello my name is Vadim\n";
                String myHomework = "=====Text File========\n";
                String myMenu = "M\tE\tN\tU\n";

                // Dialogue with the user
                Console.WriteLine(myName + myHomework);
                Console.WriteLine(myMenu);
                Console.WriteLine("Read The Text - Click 1");
                Console.WriteLine("Maximum Number Of Digits - Click 2");
                Console.WriteLine("Longest Word - Click 3");
                Console.WriteLine("Replace Numbers With Words - Click 4");
                Console.WriteLine("Interrogative And Exclamation Sentences - Click 5");
                Console.WriteLine("Comma-free Sentences - Click 6");
                Console.WriteLine("Comma-free Sentences - Click 7");

                String chose = Console.ReadLine();
                Console.Clear();

                // Choice of action
                switch (chose)
                {
                    //Read text from file
                    case "1":
                        File.ReadAllText(path);

                        //We read the text
                        foreach (string text in readText)
                        {
                            //Print the text to the console
                            Console.WriteLine(text);
                        }

                        break;
                        //Find the word with the maximum set of numbers
                    case "2":
                        {
                            string text = File.ReadAllText(path);
                            //We break the text into words
                            string[] tex = text.Split(' ', '.', ',', ';', '?', '!', '-', '{', '}', ':');
                            //Assign a variable with an empty value
                            string wordWithMaxNumber = string.Empty;
                            int DigitCount = 0;

                            //go over the text and break it down into words
                            foreach (var slovo in tex)
                            {
                                //creating a counter
                                int tempCount = 0;
                                bool hasLetter = false; 
                                //we break words into symbols
                                foreach (var c in slovo)
                                {
                                    //check if the word contains numbers
                                    if (char.IsDigit(c))
                                    {
                                        tempCount++;
                                    }
                                    //check if the word contains letter
                                    else if (char.IsLetter(c))
                                    {
                                        hasLetter = true;
                                    }
                                }

                                //if there are more digits then write down the word
                                if (tempCount > DigitCount && hasLetter)
                                {
                                    wordWithMaxNumber = slovo;
                                    DigitCount = tempCount;
                                }

                            }
                            Console.WriteLine($"{wordWithMaxNumber}");
                        }

                        break;
                    //Find the longest word
                    case "3":
                        {
                            string text = File.ReadAllText(path);
                            string[] tex = text.Split(' ', '.', ',', ';', '?', '!', '-', '{', '}', ':');
                            string wordWithMaxNumber = string.Empty;
                            int longestWordCount = 0;

                            for (int i = 0; i < tex.Length; i++)
                            {
                                //Looking for the longest word
                                if (tex[i].Length > wordWithMaxNumber.Length)
                                    wordWithMaxNumber = tex[i];
                            }

                            for (int i = 0; i < tex.Length; i++)
                            {
                                //Looking for is there still the same word
                                if (tex[i].Length == wordWithMaxNumber.Length)
                                {
                                    wordWithMaxNumber = tex[i];
                                    longestWordCount++;
                                }
                            }
                            Console.WriteLine($"{wordWithMaxNumber}\nLongest Word Count: \t{longestWordCount}");
                        }

                        break;
                    //Replacing numbers with words
                    case "4":
                        {
                            string tex = File.ReadAllText(path);

                            //rewriting words in text
                            tex = tex.Replace("0", "zero\t");
                            tex = tex.Replace("1", "one\t");
                            tex = tex.Replace("2", "two\t");
                            tex = tex.Replace("3", "three\t");
                            tex = tex.Replace("4", "four\t");
                            tex = tex.Replace("5", "five\t");
                            tex = tex.Replace("6", "six\t");
                            tex = tex.Replace("7", "seven\t");
                            tex = tex.Replace("8", "eight\t");
                            tex = tex.Replace("9", "nine\t");

                            File.WriteAllText(path, tex);
                            foreach (string text in readText)
                            {
                                Console.WriteLine(text);
                            }
                        }

                        break;
                    //Output first interrogative sentences then exclamation points
                    case "5":
                        {
                            string text = File.ReadAllText(path);
                            string[] question = text.Split('?');

                            foreach (string st in question)
                            {
                                string[] split = st.Split('.', '!');
                                // Displaying interrogative sentences to the console
                                Console.WriteLine(split[split.Length - 1] + "?");
                            }

                            string[] exclamation = text.Split('!');

                            foreach (string st in exclamation)
                            {
                                string[] split = st.Split('.', '?');
                                //Displaying exclamation sentences to the console
                                Console.WriteLine(split[split.Length - 1] + "!");
                            }

                            Console.ReadKey();
                        }

                        break;
                    //Display sentences without commas
                    case "6":
                        {
                            string text = File.ReadAllText(path);
                            string[] tex = text.Split(' ', '.',';', '?', '!', '-', '{', '}', ':');

                            foreach (string sentence in tex)
                            {
                                if (!sentence.Contains(','))
                                    Console.WriteLine(sentence.Trim());
                            }
                        }

                        break;
                    //Find words starting and ending with the same letter
                    case "7":
                        {
                            string text = File.ReadAllText(path);
                            string[] tex = text.Split(' ', '.', ',', ';', '?', '!', '-', '{', '}');

                            foreach (string te in tex)
                            {
                                var temp = te.ToUpperInvariant();
                                if (temp.Length > 1 && temp[0] == te[temp.Length - 1])
                                {
                                    Console.WriteLine(temp);
                                }
                            }
                        }

                        break;
                    //If no menu item is selected
                    default:
                        {
                            Console.WriteLine("Error.Make your choice");
                        }

                        break;
                }
                Console.WriteLine("Press any button to continue!!!");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
