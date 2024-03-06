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
		public float intersectX;
		public float max_bounceAngle;
		public float speed;
		public float bounceAngle;
		public float relativeIntersectX;
		public float normalizedRelativeIntersectionX;

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
			/*intersectX = 140.0f;
			max_bounceAngle = 5 * (float)Math.PI / 12;
			relativeIntersectX = player.Position.X + (player.texture.width/2) - intersectX;
			normalizedRelativeIntersectionX = relativeIntersectX/(player.texture.width/2);
			bounceAngle = normalizedRelativeIntersectionX * max_bounceAngle;
			speed = 500.0f;*/
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
		public void Bounce() {
			Velocity.X =  speed *(float)Math.Cos(bounceAngle);
			Velocity.Y = speed * - (float)Math.Sin(bounceAngle);
		}
	}
}
