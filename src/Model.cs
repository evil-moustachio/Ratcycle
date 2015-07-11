
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ratcycle
{
	public static class Model
	{
        // Counter used to show difference in update cycles in Console.WriteLine ()'s.
		public static int counter = 0;

		public static void Init()
		{
			Layout.Init ();
		}

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

		public static class Rat 
		{
			public static long level = 1;
			public static float exp = 0;
			public static float levelExp {
				get {
					float xp = 100;
					for (int i = 0; i <= level; i++) {
						xp += xp / 2;
					}

					return xp;
				}
			}
		}

		public static class Layout
		{
			public enum ButtonStates { Inactive, Hover, Focus };

            public static Vector2 Center(Game1 game)
            {
                return new Vector2(
                    game.GraphicsDevice.Viewport.Width / 2,
                    game.GraphicsDevice.Viewport.Height / 2
                );
            }

			public static class Font
			{
				public static string Small = "Aero Matics Display-14";
				public static string Medium = "Aero Matics Display-18";
				public static string MediumLarge = "Aero Matics Display-24";
				public static string Large = "Aero Matics Display-28";
				public static string ExtraLarge = "Aero Matics Display-36";
				public static string ExtraExtraLarge = "Aero Matics Display-48";
			}

			public static Color OrangeColor { get; private set; }

			public static void Init()
			{
				OrangeColor = new Color (251, 176, 59);
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
			public static int Current = 1;
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
            public static float points;
			public enum Type { Normal, Strong }
			public enum Category { Plastic, Paper, Chemical, Green, Other }
		}

		/// <summary>
		/// All settings that affect the presentation of the game.
		/// </summary>
		public static class Settings
		{
			public static float MusicVolume = 0.3f;
			public static float SoundEffectVolume = 1f;
            public static string Version = "0.1.0";

			/// <summary>
			/// Key settings.
			/// </summary>
			public static class Key
			{
				public enum KeyTypes { Left, Right, Up, Down, PickUp, Attack, Null }
				public static Keys Left = Keys.A, Right = Keys.D, Up = Keys.W, Down = Keys.S, PickUp = Keys.F, Attack = Keys.Space;
			}
		}
	}
}