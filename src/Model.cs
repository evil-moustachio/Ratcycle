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

        public long CurrentGameTick
        {
            get
            {
                return _currentGameTick;
            }
        }

		public Model()
		{
		}

        // Sets _currentGameTick to the current tick
        public void UpdateCurrentGameTick()
        {
            _currentGameTick = DateTime.Now.Ticks;
        }

        public void Update()
        {
            UpdateCurrentGameTick();
        }
	}
}

