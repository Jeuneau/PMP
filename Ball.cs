using System;
using System.Numerics; // Vector2
using Microsoft.VisualBasic;
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
		public double angle;
		float scr_width;
		float scr_height;
		float spr_width;
		float spr_height;
		public bool canMove = true;
		public Player player;
		public float speed;
		public double bounceAngle;
		public float hitPoint;
		public double bounceAngleInRadians;
		public float radius;	
	

		// constructor + call base constructor
		public Ball() : base("resources/ball.png")
		{
			texture = ResourceManager.Instance.
			GetTexture("resources/ball.png");
			Position = new Vector2(600, 450);
			Color = Color.BLUE;
			angle = Math.Atan2(Velocity.Y, Velocity.X);
			float scr_width = Settings.ScreenSize.X;
			float scr_height = Settings.ScreenSize.Y;
			float spr_width = TextureSize.X;
			float spr_height = TextureSize.Y;
			bounceAngle = 45.0* Math.PI / 180.0;
			speed = 200.0f;
			radius = 17;
		}	


		// Update is called every frame
		public override void Update(float deltaTime)
		{
			if(canMove)
			{
				Move(deltaTime);
				BounceEdges();
			}
			
			
		}

		// your own private methods
		public void Bounce() 
		{
			//Position.Y = texture.height * (float)1.4 + radius;
			Velocity.Y *= -1;
			Velocity.Y += 25;
			Velocity.X += 45;
		}
	}
}


