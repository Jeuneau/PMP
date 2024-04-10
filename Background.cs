using System; // Console
using System.Numerics; // Vector2
using Raylib_cs; // Color

namespace Movement
{
    class Background : SpriteNode
    {
        private Texture2D texture;

        
        // constructor + call base constructor
        public Background() : base("resources/carnival2.png")
        {
            texture = ResourceManager.Instance.GetTexture("resources/carnival2.png");
            Position = new Vector2(0,0);
        }

        public new void Draw()
        {
            Raylib.DrawTexture(texture, (int)Position.X, (int)Position.Y, Color.WHITE);
        }	
    }
}