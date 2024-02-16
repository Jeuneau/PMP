using System;
using System.Collections.Generic;
using Raylib_cs;
using System.Numerics;
 

namespace Movement
{
	class Scene : SceneNode
	{


		//private GUI gui;		
		

		//private float score;

		
		public Ball ball;
		public Player player;

		

        // private fields
        //private Rectangle rectangle;

		

		

		

		

		

		//private Gameover gameover;

		//private Youwon youwon;

		

		

		// constructor + call base constructor
		public Scene(String t) : base(t)
		{
			ball = new Ball();
			AddChild(ball);
			player = new Player();
		}

        // Update is called every frame
        public override void Update(float deltaTime)
		{	
			player.Draw();
			player.WrapEdges();
			base.Update(deltaTime);
			HandleInput(deltaTime);

			if (CalculateDistance(player.Position, ball.Position) < 30)
					{
						ball.Velocity = -ball.Velocity;
					}
		}

		 
		private void HandleInput(float deltaTime)
		{
			 if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
			{
                player.MoveLeft(deltaTime);
			}

            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
			{ 
                player.MoveRight(deltaTime);
			}
		}

		private float CalculateDistance(Vector2 a, Vector2 b)
        {
            return Vector2.Distance(a, b);
        }
	}
}
 // class
	
   
 // namespace
