namespace HQC.Project.Hangman2._1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CommandExecuter
    {
        //public void RevealTheNextLetter(string word)
        //{
        //    char firstUnrevealedLetter = '$';

        //    for (int i = 0; i < word.Length; i++)
        //    {
        //        if (WordInitializator.allGuessedLetters[i].Equals('$'))
        //        {
        //            firstUnrevealedLetter = word[i];
        //            break;
        //        }
        //    }

        //    Console.WriteLine("OK, I reveal for you the next letter {0}.", firstUnrevealedLetter);
        //    WordInitializator.InitializationAfterTheGuess(word, firstUnrevealedLetter);

        //    //// flag - not in the chart
        //    WordInitializator.flag = true;
        //}

        //public void Start()
        //{
        //    string word = WordSelector.SelectRandomWord();
        //    //// Console.WriteLine(word);
        //    WordInitializator.BegginingOfTheGameInitialization(word);
        //    WordGuesser wg = new WordGuesser() { Word = word };

        //    while (WordInitializator.guessedLetters < word.Length && WordGuesser.IsExited == false)
        //    {
        //        wg.GuessLetter();
        //    }
        //}


        //public void Exit()
        //{
        //    Console.WriteLine("Good bye!");
        //    WordGuesser.IsExited = true;

        //    Environment.Exit(0);
        //}
    }
}
