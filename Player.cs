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
		 private float horSpeed= 1150.0f;
		 public Texture2D texture;
		


		
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

		public new void Draw()
        {
            Raylib.DrawTexture(texture, (int)Position.X, (int)Position.Y, Color.WHITE);
        }		
    }
}
