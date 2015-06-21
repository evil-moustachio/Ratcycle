using System;

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

		/// <summary>
		/// All debug functions and vars
		/// </summary>
		public static class Debug
		{
			public static bool debug = false;

			public static View DefaultStartClass(Game1 game, ViewController viewController){
				if(debug)
					return new Ratcycle.Stage (game, viewController, false);
				return new MenuStart (game, viewController, true);
			}
		}

		public static class Layout
		{
			public enum ButtonStates { Inactive, Hover, Focus };

			public static class Font
			{
				public static string Small = "Aero Matics Display-14";
				public static string Medium = "Aero Matics Display-18";
				public static string MediumLarge = "Aero Matics Display-24";
				public static string Large = "Aero Matics Display-28";
				public static string ExtraLarge = "Aero Matics Display-36";
				public static string ExtraExtraLarge = "Aero Matics Display-48";
			}

		}

		/// <summary>
		/// All time vars and functions.
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
		/// All stage vars.
		/// </summary>
		public static class Stage
		{
			public static int CurrentPlaying = 1;
			public static int Current;
			public static int Reached = 1;
		}

		/// <summary>
		/// All gamerules vars and functions.
		/// </summary>
		public static class GameRules
		{
			/// <summary>
			/// Types of garbage
			/// </summary>
            public static int points;
			public enum Type { Normal, Strong }
			public enum Category { Plastic, Paper, Chemical, Green, Other }
		}

		/// <summary>
		/// All settings that affect the presentation of the game.
		/// </summary>
		public static class Settings
		{
			public static float MusicVolume = 0.5f;
			public static float SoundEffectVolume = 1f;
		}
	}
}