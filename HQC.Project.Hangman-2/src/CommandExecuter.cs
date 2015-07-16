namespace HQC.Project.Hangman2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CommandExecuter
    {
        public static void RevealTheNextLetter(string word)
        {
            char firstUnrevealedLetter = '$';

            for (int i = 0; i < word.Length; i++)
            {
                if (WordInitializator.allGuessedLetters[i].Equals('$'))
                {
                    firstUnrevealedLetter = word[i];
                    break;
                }
            }

            Console.WriteLine("OK, I reveal for you the next letter {0}.", firstUnrevealedLetter);
            WordInitializator.InitializationAfterTheGuess(word, firstUnrevealedLetter);

            //// flag - not in the chart
            WordInitializator.flag = true;
        }

        public static void Start()
        {
            string word = WordSelector.SelectRandomWord();
            //// Console.WriteLine(word);
            WordInitializator.BegginingOfTheGameInitialization(word);
            WordGuesser wg = new WordGuesser() { Word = word };

            while (WordInitializator.guessedLetters < word.Length && WordGuesser.IsExited == false)
            {
                wg.GuessLetter();
            }
        }

        //public static void TopResults()
        //{
        //    Console.WriteLine();
        //    for (int i = 0; i < 5; i++)
        //    {
        //        if (scoreboard[i] != null)
        //        {
        //            Console.WriteLine("{0}. {1} ---> {2}", i + 1, scoreboard[i].Name, scoreboard[i].Mistakes);
        //        }
        //    }

        //    Console.WriteLine();
        //}

        public static void Exit()
        {
            Console.WriteLine("Good bye!");
            WordGuesser.IsExited = true;

            Environment.Exit(0);
        }
    }
}
