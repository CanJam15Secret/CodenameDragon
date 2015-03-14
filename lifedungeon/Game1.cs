using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;

namespace lifedungeon
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        Rendering rendering;
        Random random;

        public Game1()
            : base()
        {
            rendering = new Rendering(this, 800, 600);
            random = new Random();

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
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            rendering.spriteBatch = new SpriteBatch(GraphicsDevice);

            // Create a new SpriteBatch, which can be used to draw textures.
            rendering.loadSpriteSheet(this, "Sprites/GoldCoin", new Point(32, 32));
            //rendering.loadSpriteSheet(this, "Sprites/testSpriteSheet", new Point(32, 32));
            rendering.loadSpriteSheet(this, "Sprites/FloorTile", new Point(32, 32));
                
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            rendering.Begin();
                // Include user-render content.
                // Can call other systems such as lighting.

            for(int i = 0; i < rendering.tileCount.X; ++i)
            {
                for (int j = 0; j < rendering.tileCount.Y; ++j)
                {
                    rendering.DrawSprite("Sprites/GoldCoin", 1, 1, new Vector2((i * rendering.tileSize.X), (j * rendering.tileSize.Y)));
                }
            }

            rendering.End();

            base.Draw(gameTime);
        }
    }
}
