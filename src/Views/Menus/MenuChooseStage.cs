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
			_gameObjects.Add (new AtlasObject(ContentHandler.GetTexture("background_ratCycle"), new Vector2(0,0), _game, 
				this, Color.White, 1, 1, 1, false));
			_gameObjects.Add (new AtlasObject(ContentHandler.GetTexture("GrayBackground"), new Vector2(0,0), _game, this, 
				Color.White, 1, 1, 1, false));

			//Orange background
			_gameObjects.Add (new AtlasObject (ContentHandler.GetTexture ("OrangeBG"), new Vector2 (0), _game, this, 
				Color.White, 1, 1, 1, false));

			//Select level text
			_gameObjects.Add (new Text(new Vector2(188.2f, 90.4f), _game, this, "Aero Matics Display-48", 
				"Selecteer level", Color.White));

			//Select-level add/substract buttons
			_subButton = new Button (ContentHandler.GetTexture ("LeftButton"), new Vector2 (76.8f, 335.3f), _game, this, subsLevel);
			_addButton = new Button (ContentHandler.GetTexture ("RightButton"), new Vector2 (697f, 335.3f), _game, this, addLevel);
			_gameObjects.Add (_subButton);
			_gameObjects.Add (_addButton);

			//Select level buttons and text
			float[] xCoordinatesButtons = {109, 226, 343, 460, 577};
			float[] xCoordinatesText = {157, 274, 389, 509, 622};
			for (int i = 0; i < 5; i++) {
				_levelCounterText [i] = new Text (new Vector2 (xCoordinatesText [i], _lowText), _game, this, "Aero Matics Display-28", "0", Color.White);
				_stageButtons [i] = new Button (ContentHandler.GetTexture ("PC_ChooseLevelButtons-0" + (i + 1)), new Vector2 (xCoordinatesButtons [i], _lowButton), _game, this, 3, setCurrentStage, i + 1);
				_gameObjects.Add (_levelCounterText[i]);
				_gameObjects.Add(_stageButtons[i]);
			}

			updateStages ();
			
			//Next button
			_gameObjects.Add (new Button(ContentHandler.GetTexture("startbutton_ratCycle"), new Vector2(277.5f, 444), 
				_game, this, nextView));
		}

		private void addLevel() 
		{
			//add subButton when you scroll to next 5 levels
			if (_bottomCount >= 1 && !_gameObjects.Contains(_subButton)) {
				_gameObjects.Add (_subButton);
			}

			Model.Stage.Current = _bottomCount + 5;
			_firstTimeLoadingStages = true;
			updateStages ();

			//remove addButton when end of list reached
			if (_bottomCount + 5 > Model.Stage.Reached && _gameObjects.Contains(_addButton)) {
				_gameObjects.Remove (_addButton);
			}
		}

		private void subsLevel()
		{
			if (!_gameObjects.Contains (_addButton)) {
				_gameObjects.Add (_addButton);
			}

			Model.Stage.Current = _bottomCount - 5;
			_firstTimeLoadingStages = true;
			updateStages ();

			if (_bottomCount == 1 && _gameObjects.Contains(_subButton)) {
				_gameObjects.Remove (_subButton);
			}
		}

		private void setCurrentStage(int i)
		{
			
			int tmpCurrent = _bottomCount + i - 1;
			if (tmpCurrent <= Model.Stage.Reached) {
				Model.Stage.Current = tmpCurrent;
				updateStages ();
			}
		}

		private void nextView()
		{
			if(Model.Stage.Current <= Model.Stage.Reached)
				Console.WriteLine ("YUSH");
				_viewController.SetView(new Stage(_game, _viewController, false));
		}

		private void updateStages()
		{
			_bottomCount = Model.Stage.Current;
			while (_bottomCount % 5 > 1) 
			{
				_bottomCount--;
			}
			if (Model.Stage.Current % 5 == 0) {
				_bottomCount = Model.Stage.Current - 4;
			}

			if (_bottomCount + 5 >= Model.Stage.Reached && _bottomCount < Model.Stage.Reached && _firstTimeLoadingStages)
				Model.Stage.Current = Model.Stage.Reached;
			
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
					_stageButtons [i].ChangeFrame (2, 0);
					_levelCounterText [i].Position = new Vector2 (_levelCounterText [i].Position.X, _lowText);
					_stageButtons [i].Position = new Vector2(_stageButtons[i].Position.X, _lowButton);
				} 

				if (_bottomCount + i == Model.Stage.Current) {
					_stageButtons [i].ChangeFrame (0, 0);
					_levelCounterText [i].Position = new Vector2 (_levelCounterText [i].Position.X, _highText);
					_stageButtons [i].Position = new Vector2(_stageButtons[i].Position.X, _highButton);
				}
			}
		}
	}
}

