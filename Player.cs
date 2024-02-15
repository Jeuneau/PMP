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
	
        


		
        // constructor + call base constructor
        public Player() : base("resources/Player.png")
		{
            Position = new Vector2(640,690);
			
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			
		}

		// your own private methods





		

		

		

		

		

		
    }
}
