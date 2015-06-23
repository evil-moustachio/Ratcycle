using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Text;

namespace Ratcycle
{
	public class MenuFinishStage : Menu
	{
		private Bin[] _bins;
		private Frame _frame;
		private Model.GameRules.Category[] _categories;
		private Text _trivia;
		private Random r = new Random();
		private int _binCounter = 1;
		private long _nextTriviaMoment, _buttonTimeOut = 0;

		public MenuFinishStage (Game1 game, ViewController viewController, Boolean mouseVisible, Bin[] bins, 
			Model.GameRules.Category[] categories) : base (game, viewController, mouseVisible)
		{
			_bins = bins;
			_categories = categories;

			if (Model.Stage.CurrentPlaying == Model.Stage.Reached)
				Model.Stage.Reached++;
			
			Model.Stage.CurrentPlaying++;

			createView ();
		}

		private void createView()
		{
			//Background
			_gameObjects.Add (new AtlasObject(ContentHandler.GetTexture("Background-0" + Model.Stage.Current), 
				new Vector2(0,0), _game, this, Color.White, 1, 1, 1, false));
			_gameObjects.Add (new AtlasObject(ContentHandler.GetTexture("BackgroundGray"), new Vector2(0,0), _game, this, 
				Color.White, 1, 1, 1, false));

			_frame = CreateBinInfo (_bins [0]);
			_gameObjects.Add (_frame);

			_gameObjects.Add (CreateBigBit ());

			_nextTriviaMoment = Model.Time.CurrentGameTick + Model.Time.OneSecondOfTicks * 6;
		}

		private Frame CreateBinInfo(Bin bin)
		{
			List<GameObject> frameObjects = new List<GameObject> ();
			Dictionary<Model.GameRules.Category, int> catCount = new Dictionary<Model.GameRules.Category, int> ();
			Dictionary<Model.GameRules.Category, string> catNames = new Dictionary<Model.GameRules.Category, string> ();
			int[] heights = { 110, 140 };
			int heightIndex = 0;
			float points = 0;
			catCount.Add (Model.GameRules.Category.Chemical, 0);
			catCount.Add (Model.GameRules.Category.Green, 0);
			catCount.Add (Model.GameRules.Category.Other, 0);
			catCount.Add (Model.GameRules.Category.Paper, 0);
			catCount.Add (Model.GameRules.Category.Plastic, 0);
			catNames.Add (Model.GameRules.Category.Chemical, "Chemisch");
			catNames.Add (Model.GameRules.Category.Green, "GFT");
			catNames.Add (Model.GameRules.Category.Other, "Rest");
			catNames.Add (Model.GameRules.Category.Paper, "Papier");
			catNames.Add (Model.GameRules.Category.Plastic, "Plastic");

			for (int i = bin.Contents.Count - 1; i >= 0; i--) {
				catCount[bin.Contents[i].Category]++;
				if (bin.Category == bin.Contents [i].Category) {
					points += bin.Contents [i].Points;
				} else {
					points -= bin.Contents [i].Points / 2;
				}
			}

			if (points < 0)
				points = 0;

			frameObjects.Add(new AtlasObject (ContentHandler.GetTexture ("BackgroundOrangeSmall"), new Vector2 (), _game, 
				this, Color.White, 1, 1, 1, false));
			bin.Position = new Vector2 (86.64202f, -35.20037f);
			frameObjects.Add (bin);
		
			string text = catNames [bin.Category] + ": " + catCount [bin.Category];
			frameObjects.Add (new Text (new Vector2 (20, 80), _game, this, "Aero Matics Display-18", text, Color.Green));

			for (int i = 0; i < 3; i++) {
				if (_categories [i] != bin.Category) {
					text = catNames [_categories[i]] + ": " + catCount [_categories[i]];
					frameObjects.Add(new Text (new Vector2 (20, heights[heightIndex]), _game, this, "Aero Matics Display-18", 
						text, Color.Red));
					heightIndex++;
				}
			}


			frameObjects.Add (new Text (new Vector2 (20, 200), _game, this, "Aero Matics Display-24", "Punten: " + points, 
				Color.White));

			return new Frame (new Vector2(65.479f, 49.179f), _game, this, frameObjects);
		}

		private Frame CreateBigBit()
		{
			List<GameObject> frameObjects = new List<GameObject> ();
			Vector2 center = new Vector2(ContentHandler.GetTexture("BackgroundOrangeBig").Width/2,ContentHandler.GetTexture("BackgroundOrangeBig").Height/2);
			frameObjects.Add (new AtlasObject (ContentHandler.GetTexture ("BackgroundOrangeBig"), 
				new Vector2 (), _game, this, Color.White, 1, 1, 1, false));

			_trivia = new Text (new Vector2 (20, 20), _game, this, "Aero Matics Display-18", 
				getRandomTrivia(377, "Aero Matics Display-18"), Color.White);
			frameObjects.Add (_trivia);

			frameObjects.Add (new Button (ContentHandler.GetTexture ("Button_volgende"), 
				new Vector2 (center.X - ContentHandler.GetTexture("Button_volgende").Width / 2, 400), _game, this, buttonPress));

			return new Frame (new Vector2 (327.2122f, 49.179f), _game, this, frameObjects);
		}

		private void setRandomTrivia()
		{
			_trivia.setString(getRandomTrivia(377, "Aero Matics Display-18"));
		}

		private StringBuilder getRandomTrivia(int width, string font)
		{
			string[] s = {
				"Wist je dat 75% van het gebruikte papier gerecycled wordt?",
				"Wist je dat bijna al het karton van oud papier gemaakt wordt?",
				"Wist je dat er 1,5 tot 2 kilo hout nodig is voor 1 kilo papier?",
				"Wist je dat we door papierrecycling we in Nederland per jaar genoeg hout besparen om een 2 meter " +
				"hoog hek te maken tussen Amsterdam en Parijs?"
			};
			return StringBuilderHandler.CreateStringWithNewLines (s[r.Next(0, s.Length - 1)], width, font);
		}

		private void checkForNextTrivia()
		{
			if (_nextTriviaMoment < Model.Time.CurrentGameTick) {
				setRandomTrivia ();
				_nextTriviaMoment = Model.Time.CurrentGameTick + Model.Time.OneSecondOfTicks * 6;
			}
		}

		private void buttonPress()
		{
			if (_binCounter < 3) {
				if (_buttonTimeOut < Model.Time.CurrentGameTick) {
					_gameObjects.Remove (_frame);
					_frame = CreateBinInfo (_bins [_binCounter]);
					_gameObjects.Add (_frame);

					_binCounter++;
					_buttonTimeOut = Model.Time.CurrentGameTick + Model.Time.OneSecondOfTicks * 1;
				}
			} else {
				_viewController.SetView (new MenuStart (_game, _viewController, true));
			}
		}

		public override void Update ()
		{
			base.Update ();
			checkForNextTrivia ();
		}
	}
}