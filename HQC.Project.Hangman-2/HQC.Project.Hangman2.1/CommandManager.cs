// <copyright file="CommandManager.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HQC.Project.Hangman
{
    using System;
    using HQC.Project.Hangman.Common;

    /// <summary>
    /// ???
    /// </summary>
    public class CommandManager
    {
        private string input;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandManager"/> class.
        /// </summary>
        public CommandManager()
        {
            this.input = string.Empty;
        }

        /// <summary>
        /// ???
        /// </summary>
        public string Input
        {
            get
            {
                return this.input;
            }

            set
            {
                this.input = value;
            }
        }

        /// <summary>
        /// ???
        /// </summary>
        /// <returns>???</returns>
        public string ReadInput()
        {
            Console.SetCursorPosition(Globals.LeftPositionCommandInput, Globals.TopPositionCommandInput);
            this.Input = Console.ReadLine();
            return this.Input.ToLower();
        }
    }
}