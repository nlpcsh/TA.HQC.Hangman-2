namespace HQC.Project.Hangman.Common
{
    using System;

    public static class Validator
    {
        public static void CheckIfNull(object obj, string message = null)
        {
            if (obj == null)
            {
                throw new NullReferenceException(message);
            }
        }

        public static void CheckIfStringIsNullOrEmpty(string text, string message = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(message);
            }
        }

        public static void CheckIfLessSymbols(string text, int lessThan, string message = null)
        {
            if (text.Length < lessThan)
            {
                throw new ArgumentOutOfRangeException(message);
            }
        }

        public static void CheckIfLessThanZero(decimal variable, string message = null)
        {
            if (variable <= 0)
            {
                throw new ArgumentOutOfRangeException(message);
            }
        }
    }
}
