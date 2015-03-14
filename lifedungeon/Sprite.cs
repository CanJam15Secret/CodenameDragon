using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace lifedungeon
{
    public class Sprite
    {
        public Sprite(String spriteSheetName, Point coordinates, Point size)
        {
            this.spriteSheetName = spriteSheetName;
            this.coordinates = coordinates;
            this.size = size;
        }

        public void Draw(ref Dictionary<String, Texture2D> spriteSheets, ref SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(spriteSheets[spriteSheetName], position, new Rectangle(coordinates.X, coordinates.Y, coordinates.X + size.X, coordinates.Y + size.Y), Color.White);
            int i = 0;
        }

        String spriteSheetName;
        Point coordinates;
        Point size;

    }
}
