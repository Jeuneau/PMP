using System; // Console
using System.Numerics; // Vector2
using Raylib_cs; // Color

namespace Movement
{
    class Tile : SpriteNode
    {
        public Texture2D texture;

        
        // constructor + call base constructor
        public Tile() : base("resources/Target_rec.png")
        {
            texture = ResourceManager.Instance.GetTexture("resources/Target_rec.png");
            Pivot= new Vector2(0,0);
        }

        
    }
} // namespace