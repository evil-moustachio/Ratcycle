using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace Ratcycle
{
	public static class Model
	{
		private static long _currentGameTick;

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

        /// <summary>
        /// Sets _currentGameTick to the current tick.
        /// </summary>
		private static void UpdateCurrentGameTick()
        {
            _currentGameTick = DateTime.Now.Ticks;
        }

        /// <summary>
        /// Updates the Model.
        /// </summary>
		public static void Update()
        {
            UpdateCurrentGameTick();
        }
	}
}