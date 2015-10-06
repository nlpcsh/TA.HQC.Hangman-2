// <copyright file="Validator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman.Common
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;

    /// <summary>
    /// ???
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// ???
        /// </summary>
        /// <param name="obj">???</param>
        /// <param name="message">???</param>
        public static void CheckIfNull(object obj, string message = null)
        {
            if (obj == null)
            {
                throw new NullReferenceException(message);
            }
        }

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="text">???</param>
        /// <param name="message">???</param>
        public static void CheckIfStringIsNullOrEmpty(string text, string message = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(message);
            }
        }

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="text">???</param>
        /// <param name="lessThan">???</param>
        /// <param name="message">???</param>
        public static void CheckIfLessSymbols(string text, int lessThan, string message = null)
        {
            if (text.Length < lessThan)
            {
                throw new ArgumentOutOfRangeException(message);
            }
        }

        /// <summary>
        /// ???
        /// </summary>
        /// <param name="variable">???</param>
        /// <param name="message">???</param>
        public static void CheckIfLessThanZero(decimal variable, string message = null)
        {
            if (variable <= 0)
            {
                throw new ArgumentOutOfRangeException(message);
            }
        }

        public static bool IsValidFilename(string fileName)
        {
            bool isContainsABadCharacter = fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0;
            if (isContainsABadCharacter) 
            { 
                return false; 
            }

            return true;
        }
    }
}
