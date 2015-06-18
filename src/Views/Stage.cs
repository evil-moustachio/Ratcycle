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
                new Vector2(150, 60),
                new Vector2(400, 60),
                new Vector2(650, 60)
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
                    if ((_gameObjects[i] is Entity || _gameObjects[i] is Bin) && _gameObjects[i] != entity && futureHitBox.Intersects(((AtlasObject)_gameObjects[i]).HitBox))
                    {
                        Console.WriteLine(entity.GetType());
                        Console.WriteLine("I am colliding!!! " + Model.counter);
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
                    ((Entity)_gameObjects[i]).Health -= attackerDamage;
                    attacked = true;
                }
            }

            return attacked;
        }

        public Garbage GarbageHandler ()
        {
            Garbage garbage;

            for (int i = _gameObjects.Count - 1; i >= 0; i--)
            {
				if (_gameObjects[i] is Garbage && _rat.AttackBox.Intersects(((Garbage)_gameObjects[i]).HitBox) && _rat.Inventory == null)
                {
                    garbage = (Garbage)_gameObjects[i];
					_hud.DrawGarbage (garbage.Category, garbage.Type);
					garbage.PickUp ();
                    return garbage;
                }
                else if (_gameObjects[i] is Bin && _rat.AttackBox.Intersects(((Bin)_gameObjects[i]).HitBox) && _rat.Inventory != null)
                {
                    _hud.RemoveGarbage();
                    ((Bin)_gameObjects[i]).AddGarbage(_rat.Inventory);
                    _gameObjects.Remove(_rat.Inventory);
                    return null;
                }
            }

            return null;
        }

        public void MonsterToGarbage(Monster monster, Texture2D texture)
        {            
			Garbage garbage = new Garbage(texture, monster.Position, _game, this, new Color(Color.Black, 0.7f), monster.Category, monster.Type, 1);

            _totalMonsters--;
            _gameObjects.Remove(monster);
            _currentMonsters.Remove(monster);
			_gameObjects.Add(garbage);
        }

        public void CheckFinished()
        {
            if (_currentMonsters.Count == 0 && _totalMonsters != 0)
            {
                WaitForWave();
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

        /// <summary>
        /// Updates the stage, also invokes CheckObjectCollision before base.Update() so collision check is done before objects are updated.
        /// </summary>
        public override void Update()
        {
			if (!_isPaused) 
				base.Update();

			if (KeyHandler.checkNewKeyPressed (Keys.Escape)) 
				Pause();
            CheckFinished();
			_hud.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ContentHandler.GetTexture("Background-01"), new Vector2());
            base.Draw(spriteBatch);

			_hud.Draw(spriteBatch);
        }

		public void Pause()
		{
			if (_isPaused) 
            {
				_isPaused = false;
				_hud.UnPause ();
			} 
            else 
            {
				_isPaused = true;
				_hud.Pause ();
			}
		}

		public void NextView()
		{
//			_viewController.SetView (new MenuFinishStage(_game, _viewController, true, _bins));
		}
    }
}
