using System;
using Microsoft.Xna.Framework;

namespace Ratcycle
{
	public class MenuChooseStage : Menu
	{
		private Button[] _stageButtons = new Button[5];
		private Button _subButton, _addButton;
		private Text[] _levelCounterText = new Text[5];
		private int _bottomCount, _highButton = 301, _lowButton = 321, _highText = 258, _lowText = 278;
		private bool _firstTimeLoadingStages = true;

		public MenuChooseStage (Game1 game, ViewController viewController, Boolean mouseVisible) : base(game, viewController, mouseVisible)
		{
			//Background
			_gameObjects.Add (new AtlasObject(ContentHandler.GetTexture("Background-01"), new Vector2(0,0), _game, 
				this, Color.White, 1, 1, 1, false));
			_gameObjects.Add (new AtlasObject(ContentHandler.GetTexture("BackgroundGray"), new Vector2(0,0), _game, this, 
				Color.White, 1, 1, 1, false));

			//Orange background
			_gameObjects.Add (new AtlasObject (ContentHandler.GetTexture ("BackgroundOrange"), new Vector2 (0), _game, this, 
				Color.White, 1, 1, 1, false));

			//Select level text
			_gameObjects.Add (new Text(new Vector2(188.2f, 90.4f), _game, this, "Aero Matics Display-48", 
				"Selecteer level", Color.White));

			//Select level buttons and text
			float[] xCoordinatesButtons = {109, 226, 343, 460, 577};
			float[] xCoordinatesText = {157, 274, 389, 509, 622};
			for (int i = 0; i < 5; i++) {
				_levelCounterText [i] = new Text (new Vector2 (xCoordinatesText [i], _lowText), _game, this, "Aero Matics Display-28", "0", Color.White);
				_stageButtons [i] = new Button (ContentHandler.GetTexture ("Button_ChooseLevel-0" + (i + 1)), new Vector2 (xCoordinatesButtons [i], _lowButton), _game, this, 2, setCurrentStage, i + 1);
				_gameObjects.Add (_levelCounterText[i]);
				_gameObjects.Add(_stageButtons[i]);
			}

			updateStages ();

			//Select-level add/substract buttons
			_subButton = new Button (ContentHandler.GetTexture ("Button_Left"), new Vector2 (76.8f, 335.3f), _game, this, subsLevel);
			_addButton = new Button (ContentHandler.GetTexture ("Button_Right"), new Vector2 (697f, 335.3f), _game, this, addLevel);
			if(_bottomCount != 1)
				_gameObjects.Add (_subButton); 
			
			if(_bottomCount + 4 < Model.Stage.Reached)
				_gameObjects.Add (_addButton);

			//Next button
			_gameObjects.Add (new Button (ContentHandler.GetTexture ("Button_Next"), new Vector2 (220.942f, 444), 
				_game, this, nextView));

            //music
            _game.ChangeMusic("MainTheme");
		}

		/// <summary>
		/// Goes forward 5 stages, and checks for button visibility.
		/// </summary>
		private void addLevel() 
		{
			//add subButton when you scroll to next 5 levels
			if (_bottomCount >= 1 && !_gameObjects.Contains(_subButton)) {
				_gameObjects.Add (_subButton);
			}

			Model.Stage.CurrentPlaying = _bottomCount + 5;
			_firstTimeLoadingStages = true;
			updateStages ();

			//remove addButton when end of list reached
			if (_bottomCount + 5 > Model.Stage.Reached && _gameObjects.Contains(_addButton)) {
				_gameObjects.Remove (_addButton);
			}
		}

		/// <summary>
		/// Goes back 5 stages, and checks for button visibility.
		/// </summary>
		private void subsLevel()
		{
			if (!_gameObjects.Contains (_addButton)) {
				_gameObjects.Add (_addButton);
			}

			Model.Stage.CurrentPlaying = _bottomCount - 5;
			_firstTimeLoadingStages = true;
			updateStages ();

			if (_bottomCount == 1 && _gameObjects.Contains(_subButton)) {
				_gameObjects.Remove (_subButton);
			}
		}

		/// <summary>
		/// Sets the current stage, as long as it is reached.
		/// </summary>
		/// <param name="i">The index.</param>
		private void setCurrentStage(int i)
		{

			int tmpCurrent = _bottomCount + i - 1;
			if (tmpCurrent <= Model.Stage.Reached) {
				Model.Stage.CurrentPlaying = tmpCurrent;
				updateStages ();
			}
		}

		/// <summary>
		/// Updates the stage buttons and numbers.
		/// </summary>
		private void updateStages()
		{
			_bottomCount = Model.Stage.CurrentPlaying;
			while (_bottomCount % 5 > 1) 
			{
				_bottomCount--;
			}
			if (Model.Stage.CurrentPlaying % 5 == 0) {
				_bottomCount = Model.Stage.CurrentPlaying - 4;
			}

			//Set currentstage if it is in view (only when it's the first time).
			if (_bottomCount + 4 >= Model.Stage.Reached && _bottomCount < Model.Stage.Reached && _firstTimeLoadingStages)
				Model.Stage.CurrentPlaying = Model.Stage.Reached;
			_firstTimeLoadingStages = false;

			for (int i = 0; i < 5; i++) {
				_levelCounterText [i].setString ((_bottomCount + i).ToString());

				if (_bottomCount + i <= Model.Stage.Reached) 
				{
					_stageButtons [i].ChangeFrame (0, 0);
					_levelCounterText [i].Position = new Vector2 (_levelCounterText [i].Position.X, _lowText);
					_stageButtons [i].Position = new Vector2(_stageButtons[i].Position.X, _lowButton);
				} 
				else
				{
					_stageButtons [i].ChangeFrame (1, 0);
					_levelCounterText [i].Position = new Vector2 (_levelCounterText [i].Position.X, _lowText);
					_stageButtons [i].Position = new Vector2(_stageButtons[i].Position.X, _lowButton);
				}

				//if this is the clicked stage.
				if (_bottomCount + i == Model.Stage.CurrentPlaying) {
					//set global Current stage value.
					Model.Stage.Current = i + 1;

					//Change the position and frame to blink out.
					_stageButtons [i].ChangeFrame (0, 0);
					_levelCounterText [i].Position = new Vector2 (_levelCounterText [i].Position.X, _highText);
					_stageButtons [i].Position = new Vector2(_stageButtons[i].Position.X, _highButton);
				}
			}
		}

		/// <summary>
		/// Goes to the stage, as long as it is reached.
		/// </summary>
		private void nextView()
		{
			if(Model.Stage.CurrentPlaying <= Model.Stage.Reached)
				_viewController.SetView(new Stage(_game, _viewController, false));
		}
	}
}

