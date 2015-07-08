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
		private int _binCounter = 1, _textTimerInSeconds = 10;
		private long _nextTriviaMoment, _buttonTimeOut = 0;
		private bool _leveled = false;

		public MenuFinishStage (Game1 game, ViewController viewController, Boolean mouseVisible, Bin[] bins, 
			Model.GameRules.Category[] categories) : base (game, viewController, mouseVisible)
		{
			_bins = bins;
			_categories = categories;

			Model.Rat.exp += Model.GameRules.points;
			Model.GameRules.points = 0;
			if (Model.Rat.exp >= Model.Rat.levelExp) {
				Model.Rat.exp = Model.Rat.exp - Model.Rat.levelExp;
				Model.Rat.level++;

				_leveled = true;
			}

			if (Model.Stage.CurrentPlaying == Model.Stage.Reached)
				Model.Stage.Reached++;
			
			Model.Stage.CurrentPlaying++;
            _game.saveGame.SaveGame();

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

			_nextTriviaMoment = Model.Time.CurrentGameTick + Model.Time.OneSecondOfTicks * _textTimerInSeconds;
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

			if (_leveled) {
				frameObjects.Add(new Text(new Vector2(30, 300), _game, this, "Aero Matics Display-24", "Je bent nu level " + Model.Rat.level + "!",
					Color.White));
			}

			frameObjects.Add (new Button (ContentHandler.GetTexture ("Button_Next"), 
				new Vector2 (center.X - ContentHandler.GetTexture("Button_Next").Width / 2, 400), _game, this, buttonPress));

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
                "Wist je dat we door papierrecycling we in Nederland per jaar genoeg hout besparen om een 2 meter hoog hek te maken tussen Amsterdam en Parijs?",
                "Wist je dat in 2013 in Nederland 2,350 miljard kilo oud papier is ingezameld?",
                "Wist je dat wij nu per jaar 7 miljoen bomen kunnen laten staan door het recyclen van papier?",

                "Wist je dat wij in Nederland per jaar 3.200 vrachtwagens vol GFT afval inzamelen?",
                "Wist je dat 1 GFT verwerkingsbedrijf genoeg groene stroom opwekt voor het bedrijf zelf en nog eens 4000 huizen?",
                "Wist je dat van overgebleven GFT afval onder andere Compost wordt gemaakt, wat planten beter laat groeien?",

                "Wist je dat wij chemisch afval apart inschakelen, omdat deze producten ongezond zijn voor de vuilnismannen?",
                "Wist je dat jij ongeveer 2 tot 2,5 kilo chemisch afval weggooit?",

                "Wist je dat plastic gemaakt wordt van aardolie, en er met ons huidige gebruik nog maar voor 40 jaar aardolie beschikbaar is?",
                "Wist je dat jij per jaar ongeveer 15 kilo aan plastic verpakkingen weggooit?",
                "Wist je dat je door het recyclen van 1 plastic flesje, je een lamp 6 uur lang kan laten branden?",
                "Wist je dat als je bioplastic gebruikt, dat dit 20% minder schadelijk is voor het milieu dan gewoon plastic?",

                "Wist je dat je een boete van 140 euro kan krijgen voor het gooien van afval op straat?",
                "Wist je dat er in Nederland per jaar ongeveer 9 miljard peuken op de grond worden gegooid?",
                "Wist je dat er tussen de 50 miljoen en 300 miljoen kilo afval op straat wordt gegooid per jaar?",
                "Wist je dat het ongeveer 250 miljoen euro per jaar kost om het zwerfafval in Nederland op te ruimen?",
                "Wist je dat het een jaar duurt voordat een bananenschil is verteerd?",
                "Wist je dat het 20 jaar duurt voordat een kauwgompje verteerd is?",
                "Wist je dat het 12 jaar kan duren voordat de natuur een sigaret heeft opgeruimd.",
                "Wist je dat het 50 jaar duurt voordat een blikje is weggeroest?",
                "Wist je dat roestvrijstalen en glazen voorwerpen duizenden jaren in de natuur kunnen blijven rondslingeren?",
                "Wist je dat Nederlanders zich meer ergeren aan vervuiling dan aan files en sigarettenrook?",
                "Wist je dat jongeren van 12 tot 24 jaar meer zwerfafval achterlaten dan de gemiddelde Nederlander?",
                "Wist je dat het grootste deel van het zwerfafval zich in zee bevindt?",
                "Wist je dat in de Grote Oceaan afvalhopen drijven van wel 100 miljard kilo, die even groot zijn als 34 keer Nederland?",
                "Wist je dat elke Nederlander per jaar zorgt voor 5000 kilo afval?"
			};
			return StringBuilderHandler.CreateStringWithNewLines (s[r.Next(0, s.Length)], width, font);
		}

		private void checkForNextTrivia()
		{
			if (_nextTriviaMoment < Model.Time.CurrentGameTick) {
				setRandomTrivia ();

				_nextTriviaMoment = Model.Time.CurrentGameTick + Model.Time.OneSecondOfTicks * _textTimerInSeconds;
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
				_viewController.SetView (new MenuChooseStage (_game, _viewController, true));
			}
		}

		public override void Update ()
		{
			base.Update ();
			checkForNextTrivia ();
		}
	}
}