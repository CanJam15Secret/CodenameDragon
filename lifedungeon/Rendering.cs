using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;

using System;
using System.Collections.Generic;

using lifedungeon.Components;

namespace lifedungeon
{
    // Content
    // Tilemaps
    // Lighting
    // UI
    [ArtemisEntitySystem(GameLoopType = GameLoopType.Draw, Layer = 0)]
    public class Rendering : EntityComponentProcessingSystem<TransformComponent, RenderComponent>
    {
        public Rendering()
        {
            tileSize = new Point(32, 32); // Note: get this gmap
            spriteSheets = new Dictionary<String, Texture2D>();
            sprites = new Dictionary<String, List<Sprite>>();
        }

        protected override void Begin()
        {
            spriteBatch.Begin();
        }

        protected override void End()
        {
            spriteBatch.End();
        }

        public override void LoadContent()
        {
            graphics = BlackBoard.GetEntry<GraphicsDeviceManager>("graphicsDevice");
            spriteBatch = BlackBoard.GetEntry<SpriteBatch>("spriteBatch");
            width = BlackBoard.GetEntry<int>("windowWidth");
            height = BlackBoard.GetEntry<int>("windowHeight");

            // Resize window
            resizeWindow(width, height);
        }

        public void loadSpriteSheet(Game game, System.String spriteSheetName, Point spriteSize)
        {
            // Add sprite sheet to arraylist
            spriteSheets.Add(spriteSheetName, game.Content.Load<Texture2D>(spriteSheetName));

            Point spriteCount = new Point(spriteSheets[spriteSheetName].Bounds.Width / spriteSize.X, spriteSheets[spriteSheetName].Bounds.Height / spriteSize.Y);

            if (!sprites.ContainsKey(spriteSheetName)) sprites.Add(spriteSheetName, new List<Sprite>());

            // Cut up sprite sheet
            for (int i = 0; i < spriteCount.X; ++i)
            {
                for (int j = 0; j < spriteCount.Y; ++j)
                {
                    // Create sprite
                    sprites[spriteSheetName].Add(new Sprite(spriteSheetName, new Point(i * spriteSize.X, j * spriteSize.Y), spriteSize));
                }
            }
        }

        public override void Process(Entity entity, TransformComponent transformComponent, RenderComponent renderComponent)
        {
            if (transformComponent != null && renderComponent != null)
            {
                sprites[renderComponent.spriteSheet][renderComponent.spriteNo - 1].Draw(ref spriteSheets, ref spriteBatch, transformComponent.position);
            }
        }

        public void resizeWindow(int windowWidth, int windowHeight)
        {
            // Set new height & width
            width = windowWidth;
            height = windowHeight;
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;
            graphics.ApplyChanges();

            // Recalculate tileCount
            tileCount = new Point(width / tileSize.X + (width % tileSize.X > 0 ? 1 : 0), height / tileSize.Y + (height % tileSize.Y > 0 ? 1 : 0));
        }

        public int width { get; private set; }
        public int height { get; private set; }
        public Point tileCount { get; private set; }
        public Point tileSize { get; private set; }

        private GraphicsDeviceManager graphics;
        private Dictionary<String, Texture2D> spriteSheets;
        private Dictionary<String, List<Sprite>> sprites;
        public SpriteBatch spriteBatch;
    }

}
