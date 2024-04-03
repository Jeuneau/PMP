using System; // Console
using System.Numerics; // Vector2
using Raylib_cs; // Color

namespace Movement
{
    class Background : SpriteNode
    {
        public Texture2D texture;

        
        // constructor + call base constructor
        public Background() : base("resources/circus_source.png")
        {
            texture = ResourceManager.Instance.GetTexture("resources/circus_source.png");
            Position = new Vector2(500,500);
        }

        public new void Draw()
        {
            Raylib.DrawTexture(texture, (int)Position.X, (int)Position.Y, Color.WHITE);
        }	
    }
}