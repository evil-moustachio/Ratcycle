﻿using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace Ratcycle
{
	public static class Model
	{
        // Counter used to show difference in update cycles in Console.WriteLine ()'s.
		public static int counter = 0;

        /// <summary>
        /// Updates the Model.
        /// </summary>
		public static void Update()
        {
			counter++;
			Time.Update ();
        }

		public static class Debug
		{
			public static bool debug = true;

			public static View DefaultStartClass(Game1 game, ViewController viewController){
				if(debug)
					return new Ratcycle.Stage (game, viewController, false);
				return new MenuStart (game, viewController, true);
			}
		}

		public static class Layout
		{
			public enum ButtonStates { Inactive, Hover, Focus };
			public static string standartFontName = "Aero Matics Display-14";
		}

		/// <summary>
		/// All time vars
		/// </summary>
		public static class Time
		{
			static long _currentGameTick;

			public static int OneSecondOfTicks = 10000000;

			/// <summary>
			/// Returns the tick the game is currently on.
			/// </summary>
			public static long CurrentGameTick
			{
				get
				{
					return _currentGameTick;
				}
			}

			public static void Update()
			{
				_currentGameTick = DateTime.Now.Ticks;
			}
		}

		/// <summary>
		/// All level vars
		/// </summary>
		public static class Level
		{
			public static int Current = 0;
			public static int Reached = 12;
		}

		/// <summary>
		/// All stage vars
		/// </summary>
		public static class Stage
		{
			public static int currentStage;
		}

		public static class GameRules
		{
			/// <summary>
			/// Types of garbage
			/// </summary>
			public enum Types { Plastic, Paper, Chemical, Green, Other }
		}
	}
}