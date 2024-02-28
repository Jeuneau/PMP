using System.Numerics; // Vector2
using Raylib_cs; // Color

/*
In this class, we have the properties:

- Vector2  Position
- float    Rotation
- Vector2  Scale

- Vector2 TextureSize
- Vector2 Pivot
- Color Color

Methods:

- AddChild(Node child)
- RemoveChild(Node child, bool keepAlive = false)
*/

namespace Movement
{
	class Ball : MoverNode
	{
		// your private fields here (add Velocity, Acceleration, addForce method)
		public Texture2D texture;

		// constructor + call base constructor
		public Ball() : base("resources/ball.png")
		{
			Image ball = Raylib.LoadImage("resources/ball.png");  // Load image data into CPU memory (RAM)
			texture = Raylib.LoadTextureFromImage(ball);       // Image converted to texture, GPU memory (RAM -> VRAM)
            Raylib.UnloadImage(ball);
			Position = new Vector2(Settings.ScreenSize.X / 6, Settings.ScreenSize.Y / 4);
			Color = Color.BLUE;
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			Move(deltaTime);
			BounceEdges();
		}

		// your own private methods
		
		

		

	}
}
