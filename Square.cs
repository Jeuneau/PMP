using System; // Console
using System.Numerics; // Vector2
using Raylib_cs; // Color

namespace Movement
{
    class Square : SpriteNode
    {
        Texture2D texture;

        
        // constructor + call base constructor
        public Square() : base("resources/Target_rec.png")
        {
            Image rect = Raylib.LoadImage("resources/Target_rec.png");  // Load image data into CPU memory (RAM)
		    texture = Raylib.LoadTextureFromImage(rect);       // Image converted to texture, GPU memory (RAM -> VRAM)
            Raylib.UnloadImage(rect);
			Position = new Vector2(50,150);
        }

        
    }
} // namespace