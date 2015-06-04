using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

namespace Ratcycle
{
	public class Model
	{
        private long _currentGameTick;

        /// <summary>
        /// Returns the tick the game is currently on.
        /// </summary>
        public long CurrentGameTick
        {
            get
            {
                return _currentGameTick;
            }
        }

        /// <summary>
        /// Model constructor.
        /// </summary>
		public Model()
		{
		}

        /// <summary>
        /// Sets _currentGameTick to the current tick.
        /// </summary>
        public void UpdateCurrentGameTick()
        {
            _currentGameTick = DateTime.Now.Ticks;
        }

        /// <summary>
        /// Updates the Model.
        /// </summary>
        public void Update()
        {
            UpdateCurrentGameTick();
        }
	}
}