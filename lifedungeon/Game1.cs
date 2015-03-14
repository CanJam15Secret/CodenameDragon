using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

using System;

namespace lifedungeon
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D slime;
        Texture2D wall;
        Texture2D floor;

        Vector2 offset;
        Vector2 rand;
        Vector2 plyPos;

        RNG rng;
        Random numRand;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);

            graphics.PreferredBackBufferWidth = 800;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 600;   // set this value to the desired height of your window
            graphics.ApplyChanges();

            float tileSize = 32;
            offset = new Vector2( ( 1f/2f ) * tileSize, ( 0.75f/2f ) * tileSize );

            rng = RNG.Instance;
            rng.seed = 1337;

            for (int i = 0; i < 100; i++)
            {
                System.Console.WriteLine(rng.diceRoll(100));
            }

            plyPos = new Vector2(400f, 300f);
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

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(this.GraphicsDevice);

            floor = Content.Load<Texture2D>("floor");
            wall = Content.Load<Texture2D>("wall");
            slime = Content.Load<Texture2D>("slime");


            rand.X = new System.Random().Next(0,800-64);
            rand.Y = new System.Random().Next(0,600-64);

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
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                this.plyPos.Y--;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                this.plyPos.Y++;
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                this.plyPos.X--;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                this.plyPos.X++;
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);

            // TODO: Add your drawing code here
            spriteBatch.Begin( SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

            for (int i = 0; i < 12; ++i)
            {
                for (int j = 0; j < 9; ++j)
                {
                    spriteBatch.Draw(floor, new Vector2(offset.X + i*64, offset.Y + j*64), null, Color.White, 0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0f);
                    if (i == 0 || i == 11 || j == 0 || j == 8)
                    {
                        spriteBatch.Draw(wall, new Vector2(offset.X + i * 64, offset.Y + j * 64), null, Color.White, 0f, Vector2.Zero, 1.0f, SpriteEffects.None, 1f);
                    }
                    
                    spriteBatch.Draw(slime, new Vector2(plyPos.X - 16, plyPos.Y - 16), null, Color.White, 0f, Vector2.Zero, 2.0f, SpriteEffects.None, 1f);
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
