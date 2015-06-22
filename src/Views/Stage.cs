using System;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Ratcycle
{
    public class Stage : View
    {
		private Rat _rat;
		private StageHUD _hud;
		private Boolean _isPaused;
        private int _totalMonsters;
        private Model.GameRules.Category[] _stageCategories;
        private Bin[] _bins;
        private List<Monster> _currentMonsters;
        private int _deadMonsters = 0;
        private const float _waveTime = 5;
        private float _remainingWaveTime = _waveTime;
		private List<PlayerFeedback> _playerFeedbackList;

		public Vector2 RatBase { get { return new Vector2(_rat.HitBox.Center.X, _rat.HitBox.Bottom); } }
		public Rectangle RatHitBox { get { return _rat.HitBox; } }

        /// <summary>
        /// Constructs the stage.
        /// </summary>
        /// <param name="game"></param>
        /// <param name="viewController"></param>
		/// <param name="mouseVisible"></param>
		public Stage(Game1 game, ViewController viewController, Boolean mouseVisible) 
			: base (game, viewController, mouseVisible)
        {
            _totalMonsters = ((9 + (3 * Model.Stage.CurrentPlaying)) - _deadMonsters);
            RandomizeCategories();
            MakeBins();
            MakeMonsters();

			_rat = new Rat(ContentHandler.GetTexture ("Entity_rat"), new Vector2 (200, 200), game, this, 
				new Vector2 (5, 5), 100, 45);
			_hud = new StageHUD(_game, _viewController, false, _rat, this);

            _gameObjects.Add(_rat);

			_playerFeedbackList = new List<PlayerFeedback>();

			_game.ChangeMusic ("GameTheme");
        }

        public void RandomizeCategories()
        {
            Model.GameRules.Category[] allCategories = (Model.GameRules.Category[]) Enum.GetValues(typeof(Model.GameRules.Category));
            Model.GameRules.Category[] stageCategories = new Model.GameRules.Category[3];

            allCategories.Shuffle();

            for (int i = 0; i < 3; i++)
            {
                stageCategories[i] = allCategories[i];
                Console.WriteLine(stageCategories[i]);
            }

            _stageCategories = stageCategories;
        }

        public void MakeBins()
        {
            Bin[] bins = new Bin[3];
            Vector2[] binPositions = new Vector2[3]
            {
                new Vector2(150, 136),
                new Vector2(400, 136),
                new Vector2(650, 136)
            };

            for (int i = 0; i < 3; i++)
            {
                switch (_stageCategories[i])
                {
                    case Model.GameRules.Category.Chemical:
                        bins[i] = new ChemicalBin(binPositions[i], _game, this);
                        break;
                    case Model.GameRules.Category.Green:
                        bins[i] = new GreenBin(binPositions[i], _game, this);
                        break;
                    case Model.GameRules.Category.Other:
                        bins[i] = new OtherBin(binPositions[i], _game, this);
                        break;
                    case Model.GameRules.Category.Paper:
                        bins[i] = new PaperBin(binPositions[i], _game, this);
                        break;
                    case Model.GameRules.Category.Plastic:
                        bins[i] = new PlasticBin(binPositions[i], _game, this);
                        break;
                }

                _gameObjects.Add(bins[i]);
            }

            _bins = bins;
        }

        public void MakeMonsters()
        {
            if (_totalMonsters != 0)
            {
                int i = 0;
                int maxMonsters = 3;
                Random r = new Random();
                List<Monster> currentMonsters = new List<Monster>();

                while (currentMonsters.Count != maxMonsters)
                {
                    switch (_stageCategories[i])
                    {
                        case Model.GameRules.Category.Chemical:
                            if (r.Next(0, 1) == 0)
                            {
                                currentMonsters.Add(new NormalChemical(_game, this));
                            }
                            else
                            {
                                currentMonsters.Add(new StrongChemical(_game, this));
                            }
                            break;
                        case Model.GameRules.Category.Green:
                            if (r.Next(0, 1) == 0)
                            {
                                currentMonsters.Add(new NormalGreen(_game, this));
                            }
                            else
                            {
                                currentMonsters.Add(new StrongGreen(_game, this));
                            }
                            break;
                        case Model.GameRules.Category.Other:
                            if (r.Next(0, 1) == 0)
                            {
                                currentMonsters.Add(new NormalOther(_game, this));
                            }
                            else
                            {
                                currentMonsters.Add(new StrongOther(_game, this));
                            }
                            break;
                        case Model.GameRules.Category.Paper:
                            if (r.Next(0, 1) == 0)
                            {
                                currentMonsters.Add(new NormalPaper(_game, this));
                            }
                            else
                            {
                                currentMonsters.Add(new StrongPaper(_game, this));
                            }
                            break;
                        case Model.GameRules.Category.Plastic:
                            if (r.Next(0, 1) == 0)
                            {
                                currentMonsters.Add(new NormalPlastic(_game, this));
                            }
                            else
                            {
                                currentMonsters.Add(new StrongPlastic(_game, this));
                            }
                            break;
                    }

                    _gameObjects.Add(currentMonsters[i]);
                    i++;
                }

                _currentMonsters = currentMonsters;
            }
        }

       
		/// <summary>
		/// Checks if Entity collides with any other entity
		/// </summary>
		/// <returns><c>true</c>, if colliding was noted, <c>false</c> otherwise.</returns>
		/// <param name="entity">Entity.</param>
		/// <param name="fhb">FutureHitBox.</param>
		/// <param name="minc">MinCoord.</param>
		/// <param name="maxc">MaxCoord.</param>
        public bool NotColliding(Entity entity, Rectangle fhb, Vector2 minc, Vector2 maxc)
        {
            Rectangle futureHitBox = fhb;

            if ((entity is Monster && futureHitBox.Y > minc.Y)|| (futureHitBox.Y < maxc.Y && futureHitBox.X > minc.X && futureHitBox.X < maxc.X && futureHitBox.Y > minc.Y))
            {
                for (int i = _gameObjects.Count - 1; i >= 0; i--)
                {
                    if (_gameObjects[i] is Entity && _gameObjects[i] != entity && futureHitBox.Intersects(((AtlasObject)_gameObjects[i]).HitBox))
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool AttackHandler (Entity attacker, float attackerDamage, Rectangle AttackBox)
        {
            bool attacked = false;

            for (int i = _gameObjects.Count - 1; i >= 0; i--)
            {
                if (_gameObjects[i] is Entity && attacker != _gameObjects[i] && AttackBox.Intersects(((Entity)_gameObjects[i]).HitBox) && !(attacker is Monster && _gameObjects[i] is Monster))
                {
					((Entity)_gameObjects[i]).Damage(attackerDamage);
                    attacked = true;
                }
            }

            return attacked;
        }

        public Garbage GarbageHandler (Garbage inventory)
        {
            Garbage garbage;

            for (int i = _gameObjects.Count - 1; i >= 0; i--)
            {
				if (_gameObjects[i] is Garbage && _rat.AttackBox.Intersects(((Garbage)_gameObjects[i]).HitBox) && _rat.Inventory == null)
                {
                    _game.soundEffect = new SoundHandler("PickupMonster", Model.Settings.SoundEffectVolume);
                    _game.soundEffect.Play();
                    garbage = (Garbage)_gameObjects[i];
					_hud.DrawGarbage (garbage.Category, garbage.Type);
					garbage.PickUp();
                    return garbage;
                }
                else if (_gameObjects[i] is Bin && _rat.BodyBox.Intersects(((Bin)_gameObjects[i]).HitBox) && _rat.Inventory != null)
                {
                    _hud.RemoveGarbage();
                    ((Bin)_gameObjects[i]).AddGarbage(_rat.Inventory);
                    _gameObjects.Remove(_rat.Inventory);
                    return null;
                }
            }

            return inventory;
        }

        public void MonsterToGarbage(Monster monster, Texture2D texture)
        {            
			Garbage garbage = new Garbage(texture, monster.Position, _game, this, new Color(Color.Black, 0.7f), monster.Category, monster.Type, 1);

            _totalMonsters--;
            _gameObjects.Remove(monster);
            _currentMonsters.Remove(monster);
			_gameObjects.Add(garbage);

			Console.WriteLine (_totalMonsters + " Monsters left.");
        }

        public void CheckFinished()
        {
            if (_currentMonsters.Count == 0)
            {
				if (_totalMonsters != 0)
                	WaitForWave();
				else
					GameOver();
            }
        }

        public void WaitForWave()
        {
            var timer = (float) _game.GameTime.ElapsedGameTime.TotalSeconds;

            _remainingWaveTime -= timer;

            if (_remainingWaveTime <= 0)
            {
                MakeMonsters();
                _remainingWaveTime = _waveTime;
            }
        }

		public void UpdatePlayerFeedback()
		{
			for (int i = _playerFeedbackList.Count - 1; i >= 0; i--)
			{
				_playerFeedbackList[i].Update();
			}
		}

		public void DrawPlayerNotification(SpriteBatch spriteBatch)
		{
			for (int i = _playerFeedbackList.Count - 1; i >= 0; i--)
			{
				_playerFeedbackList[i].Draw(spriteBatch);
			}
		}

		public void removePlayerFeedback(PlayerFeedback playerFeedback)
		{
			_playerFeedbackList.Remove(playerFeedback);
		}

		/// <summary>
		/// Creates a upward moving string that notifies the user of something.
		/// </summary>
		/// <param name="text">The string that will be displayed.</param>
		/// <param name="color">Color of the notification.</param>
		/// <param name="position">Where the notification will start it's movement.</param>
		/// <param name="distance">The amount of Y the notification will travel.</param>
		/// <param name="duration">The amount of updates the notification will take to travel.</param>
		public void NewPlayerFeedback(string text, Color color, Vector2 position, float distance, float duration)
		{
			_playerFeedbackList.Add (new PlayerFeedback (position, distance, duration, text, color, _game, this, "Aero Matics Display-48"));
		}

        /// <summary>
        /// Updates the stage, also invokes CheckObjectCollision before base.Update() so collision check is done before objects are updated.
        /// </summary>
        public override void Update()
        {
			if (!_isPaused) 
			{
				base.Update();
				UpdatePlayerFeedback();
				CheckFinished();
			}
			

			if (KeyHandler.checkNewKeyPressed (Keys.Escape)) 
				Pause();
			_hud.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ContentHandler.GetTexture("Background-01"), new Vector2());

			// Draw garbage first
			for (int i = _orderedList.Count - 1; i >= 0; i--) 
			{
				if (_orderedList[i] is Garbage)
				{
					_orderedList[i].Draw(spriteBatch);
					_orderedList.Remove(_orderedList[i]);
				}
			}

            base.Draw(spriteBatch);
			DrawPlayerNotification (spriteBatch);

			_hud.Draw(spriteBatch);
        }

		public void GameOver()
		{
			if (_rat.IsAlive) 
			{
				// Got to results
				NextView();
			}
			else 
			{
				_game.ChangeMusic("DeathTheme");

				_isPaused = true;
				_hud.GameOver();
			}
		}

		public void Pause()
		{
			if (_isPaused) 
            {
				_game.ChangeMusic("GameTheme");
				
				_isPaused = false;
				_hud.UnPause();
			} 
            else 
            {
				_game.ChangeMusic("DeathTheme");
				
				_isPaused = true;
				_hud.Pause();
			}
		}

		public void NextView()
		{
			NewPlayerFeedback ("Stage Cleared", Color.Green, _rat.Position, 30f, 100f);
//			_viewController.SetView (new MenuFinishStage(_game, _viewController, true, _bins));
		}
    }
}
