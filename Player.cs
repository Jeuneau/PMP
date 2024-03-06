using System; // Console
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
	class Player : MoverNode
	{
		// your private fields here (rotSpeed, thrustForce)
		 private float horSpeed= 650.0f;
		 public Vector2 position;
		 public Texture2D texture;
		 public Vector2 velocity;
		 public float window_width = 1280;
		 public float window_height = 720;
		 public int playerwidth= 64;
		 public int playerheight= 199;


		
        // constructor + call base constructor
        public Player() : base("resources/Player.png")
		{
			texture = ResourceManager.Instance.GetTexture("resources/Player.png");
			Position = new Vector2(640,650);
		}

		 public void MoveLeft(float deltaTime) 
        {
            Position.X -= horSpeed * deltaTime;
        }

        public  void MoveRight(float deltaTime) 
        {
            Position.X += horSpeed * deltaTime;
        }

		public void Draw()
        {
            Raylib.DrawTexture(texture, (int)Position.X, (int)Position.Y, Color.WHITE);
        }

		public void WrapEdges()
		{
			float scr_width = window_width;
			float scr_height = window_height;
			float spr_width = playerwidth;
			float spr_height = playerheight;
            
			if (Position.X > scr_width) {
                Position.X = 0;
            }
            if (Position.X < 0) {
                Position.X = scr_width;
            }
            if (Position.Y > scr_height) {
                Position.Y = 0;
            }
            if (Position.Y < 0) {
                Position.Y = scr_height;
            }
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			
		}

		// your own private methods





		

		

		

		

		

		
    }
}
