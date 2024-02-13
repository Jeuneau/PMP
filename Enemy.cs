using System;
using System.Numerics;
using Raylib_cs;

namespace Movement;


class Enemy : MoverNode
{
	private float topspeed= 250;

    public static object plasmarounds { get; internal set; }

	

    //Vector2 Velocity;
    //Vector2 Acceleration;	
    //private float topspeed= 1000;
    public Enemy() : base("resources/Alien.png")
    {
	  
    }

     public override void Update(float deltaTime) {
    	Move(deltaTime);
        WrapEdges();
		// Follow(deltaTime);
		if((Velocity.Length()>topspeed))
		{
			Velocity= Vector2.Normalize(Velocity)* topspeed;
		}
		
	}  

	public void Follow(float deltaTime, Vector2 followpos)
		{
			// Vector2 mouse = Raylib.GetMousePosition();
			Vector2 mouse = followpos;
			// Console.WriteLine(mouse);
			Acceleration= mouse - Position;
			Acceleration= Vector2.Normalize(Acceleration);
			
			Velocity+= Acceleration;

		
			

			
			//Position = mouse; // incorrect!!

			// TODO implement
			// Position += Velocity * deltaTime;
			Position+= Velocity* deltaTime;
		}

		public Plasmaround Shoot() {
			Plasmaround p= new Plasmaround();
			p.Position.X = this.Position.X + (float)Math.Cos(Rotation);
			p.Position.Y = this.Position.Y +  (float)Math.Sin(Rotation);
			p.Velocity = new Vector2(1700 * (float)Math.Cos(Rotation), 1700 * (float)Math.Sin(Rotation));
			//new Vector2 direction -> normalize -> multiply met afstand middelpunt-neus
			/*direction= new Vector2((this.Position.X + (float)Math.Cos(Rotation)), (this.Position.Y +  (float)Math.Sin(Rotation)));
			direction_normal = Vector2.Normalize(direction);
			direction= direction_normal *32; */
			//new Vector2( Position.X, Position.Y );
			return p;
		}

   
}