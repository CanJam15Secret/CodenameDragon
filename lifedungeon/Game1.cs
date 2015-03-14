using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Artemis;
using Artemis.Blackboard;
using Artemis.System;

using System;

using lifedungeon.Components;
//using lifedungeon.Systems;

namespace lifedungeon
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        EntityWorld world;
        Random rng;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        

        public Game1()
            : base()
        {
            // Set content root direction
            Content.RootDirectory = "Content";

            // Create world
            world = new EntityWorld();

            // RNG
            rng = new Random();

            // Graphics device
            graphics = new GraphicsDeviceManager(this);

            // Create test entity
            Entity player = world.CreateEntity();
            player.AddComponent<TransformComponent>(new TransformComponent(new Vector2(0f, 0f)));
            player.AddComponent<RenderComponent>(new RenderComponent("Sprites/GoldCoin", 1));
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Sprite batch
            spriteBatch = new SpriteBatch(GraphicsDevice);

            EntitySystem.BlackBoard.SetEntry("graphicsDevice", graphics);
            EntitySystem.BlackBoard.SetEntry("spriteBatch", spriteBatch);
            EntitySystem.BlackBoard.SetEntry("ContentManager", Content);
            EntitySystem.BlackBoard.SetEntry("windowWidth", 800);
            EntitySystem.BlackBoard.SetEntry("windowHeight", 600);
            EntitySystem.BlackBoard.SetEntry("rng", rng);

            world.InitializeAll(true);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            world.SystemManager.GetSystem<Rendering>().loadSpriteSheet(this, "Sprites/GoldCoin", new Point(32, 32));
            world.SystemManager.GetSystem<Rendering>().loadSpriteSheet(this, "Sprites/FloorTile", new Point(32, 32));
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

            // Update entity system
            world.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // Draw entity system
            world.Draw();

            base.Draw(gameTime);
        }
    }
}
