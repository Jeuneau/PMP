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
		public bool canMove = true;
		
	
	

		// constructor + call base constructor
		public Ball() : base("resources/ball.png")
		{
			texture = ResourceManager.Instance.
			GetTexture("resources/ball.png");
			Position = new Vector2(600, 450);
			Color = Color.BLUE;
			Velocity = new Vector2(500, 700);
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
			Velocity.Y *= -1;
			Velocity.Y += 50;
			Velocity.X += 42.5f;
		}

	
		
	}
}


