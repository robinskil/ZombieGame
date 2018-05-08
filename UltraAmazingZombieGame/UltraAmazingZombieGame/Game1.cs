using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using UltraAmazingZombieGame.Entity;
using UltraAmazingZombieGame.Map;

namespace UltraAmazingZombieGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        MapCreator map;
        Player player;
        Camera2D camera;
        ButtonState oldState;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //Mouse visible set here
            this.IsMouseVisible = true;
            this.TargetElapsedTime = TimeSpan.FromSeconds(1.0f / 60.0f);
            this.IsFixedTimeStep = true;
            base.Initialize();
            camera = new Camera2D(GraphicsDevice);

            //Generate the map here
            this.map = new MapCreator();
            //Generate Player
            this.player = new Player(this.map.GenerateSpawnPosition(), "Robin");

            //setting camera position at start of game;
            camera.Zoom = 2.0F;
            camera.Position = new Vector2(player.position.X - GraphicsDevice.Viewport.Width / 2, player.position.Y - GraphicsDevice.Viewport.Height / 2);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            this.font = Content.Load<SpriteFont>("FontVerdana");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here
            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.A))
            {
                player.MoveLeft();
                foreach (MapObject item in map.MapGrid)
                {
                    if (item.Collision(new RectangleF(this.player.position.X, this.player.position.Y, this.player.size.Width, this.player.size.Height)) == true)
                    {
                        player.MoveRight();
                        break;
                    }

                }
                //camera.Move(new Vector2(-amountMove, 0));
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                player.MoveDown();
                foreach (MapObject item in map.MapGrid)
                {
                    if (item.Collision(new RectangleF(this.player.position.X, this.player.position.Y, this.player.size.Width, this.player.size.Height)) == true)
                    {
                        player.MoveUp();
                        break;
                    }

                }
                //camera.Move(new Vector2(0, amountMove));
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                player.MoveRight();
                foreach (MapObject item in map.MapGrid)
                {
                    if (item.Collision(new RectangleF(this.player.position.X, this.player.position.Y, this.player.size.Width, this.player.size.Height)) == true)
                    {
                        player.MoveLeft();
                        break;
                    }

                }
                //camera.Move(new Vector2(amountMove, 0));
            }
            if (keyboardState.IsKeyDown(Keys.W))
            {
                player.MoveUp();
                foreach (MapObject item in map.MapGrid)
                {
                    if (item.Collision(new RectangleF(this.player.position.X, this.player.position.Y, this.player.size.Width, this.player.size.Height)) == true)
                    {
                        player.MoveDown();
                        break;
                    }

                }
                //camera.Move(new Vector2(0, -amountMove));
            }
            var newState = Mouse.GetState().LeftButton;
            var mousePos = Mouse.GetState();
            if(newState == ButtonState.Released && this.oldState == ButtonState.Pressed){
                this.player.shoot(new Vector2(mousePos.X + camera.Position.X,mousePos.Y + camera.Position.Y));
            }
            this.oldState = newState;
            //Correcting camera position
            camera.Position = new Vector2(player.position.X - GraphicsDevice.Viewport.Width / 2, player.position.Y - GraphicsDevice.Viewport.Height / 2);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            var transformMatrix = camera.GetViewMatrix();
            //Start Drawing
            spriteBatch.Begin(transformMatrix: transformMatrix);
            base.Draw(gameTime);
            map.DrawMap(spriteBatch);
            player.Draw(spriteBatch);
            //end drawing
            spriteBatch.End();

            // draw hud for player incl wall hud of buyign gun
            player.DrawHud(spriteBatch,this.font,GraphicsDevice);
            //CHANGE THIS, BAD PROGRAMING PRACTICE
            foreach (MapObject item in map.MapGrid)
            {
                if(item.GetType() == typeof(WallWeaponObject))
                {
                    var item2 = (WallWeaponObject)item;
                    
                    bool val = (item2.buyCollision(new RectangleF(this.player.position.X, this.player.position.Y, this.player.size.Width, this.player.size.Height), spriteBatch, font, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
                    //Console.WriteLine(val);
                    if (val)
                    {
                        if (Keyboard.GetState().IsKeyDown(Keys.F))
                        {
                            //Console.WriteLine("Bougt glock 17");
                            if (this.player.PickUpWeapon(item2.weaponBought()) == true) Console.WriteLine("Bought a Glock 17");
                        }
                    }
                }
            }
        }
    }
}
