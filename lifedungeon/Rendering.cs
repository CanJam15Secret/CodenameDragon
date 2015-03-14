using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;

namespace lifedungeon
{
    // Content
    // Tilemaps
    // Lighting
    // UI
    public class Rendering
    {
        public Rendering(Game game, int width, int height)
        {
            tileSize = new Point(32, 32); // Note: get this gmap

            graphics = new GraphicsDeviceManager(game);
            spriteSheets = new Dictionary<String, Texture2D>();
            sprites = new Dictionary<String, List<Sprite>>();
            //spriteBatch = new SpriteBatch(game.GraphicsDevice);
            
            // Resize window
            resizeWindow(width, height);
        }

        public void Begin()
        {
            spriteBatch.Begin();
        }

        public void End()
        {
            spriteBatch.End();
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
        public void DrawSprite(System.String spriteSheetName, int sprite, int frame, Vector2 position)
        {
            sprites[spriteSheetName][sprite - 1].Draw(ref spriteSheets, ref spriteBatch, position);
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
