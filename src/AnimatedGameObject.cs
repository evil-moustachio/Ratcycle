using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ratcycle
{
	public class AnimatedGameObject : TexturedGameObject
	{
		protected int _currentXFrame;
		protected int _frameColumns;
		private long _ticksPerFrame;
		private long _nextFrameTick;

		/// <summary>
		/// Initializes a new instance of the <see cref="Ratcycle.AnimatedGameObject"/> class.
		/// </summary>
		/// <param name="position">Position.</param>
		/// <param name="game">Game.</param>
		/// <param name="view">View.</param>
		/// <param name="texture">Texture.</param>
		/// <param name="frameRows">Frame rows.</param>
		/// <param name="frameColumns">Frame columns.</param>
		/// <param name="fps">Fps.</param>
		public AnimatedGameObject (Vector2 position, Game1 game, View view, Texture2D texture, 
			int frameRows, int frameColumns, int fps) : base (position, game, view, texture, frameRows)
		{
			_frameColumns = frameColumns;

			_currentXFrame = 0;
			_frameWidth = _texture.Width / _frameColumns;

			_ticksPerFrame = 10000000 / fps;
			_nextFrameTick = DateTime.Now.Ticks + _ticksPerFrame;
		}

		/// <summary>
		/// Updates the object.
		/// </summary>
		public override void Update()
		{
			base.Update ();
			AnimationHandler();
		}

		/// <summary>
		/// Updates the sourceRectangle when it's time for the next frame.
		/// </summary>
		private void AnimationHandler()
		{
			if (Model.CurrentGameTick > _nextFrameTick)
			{
				var nextFrame = _currentXFrame + 1;
				if (nextFrame > _frameColumns)
				{
					nextFrame = 0;
				}
				ChangeToFrame( nextFrame, _currentYFrame);
				_nextFrameTick = Model.CurrentGameTick + _ticksPerFrame;
			}
		}

		/// <summary>
		/// Changes the sourceRectangle's position to the desired frame.
		/// Top row is 0, first column is 0.
		/// </summary>
		/// <param name="frameColumn"></param>
		/// <param name="frameRow"></param>
		public void ChangeToFrame(int frameColumn, int frameRow)
		{
			//Catch null, used if you don't want to set the column/row
			if(frameColumn < 0) {
				frameColumn = _currentXFrame;
			}
			if(frameRow < 0){
				frameRow = _currentYFrame;
			}

			// Update _currentFrame
			_currentXFrame = frameColumn;
			_currentYFrame = frameRow;

			// Update _sourceRectangle
			_sourceRectangle.X = _frameWidth * _currentXFrame;
			_sourceRectangle.Y = _frameHeight * _currentYFrame;
		}
	}
}

