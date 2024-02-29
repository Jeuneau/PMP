using System;
using System.Collections.Generic;
using Raylib_cs;
using System.Numerics;
 

namespace Movement
{
	class Scene : SceneNode
	{	
		public Ball ball;
		public Player player;
		public Square square;
		

		// constructor + call base constructor
		public Scene(String t) : base(t)
		{
			ball = new Ball();
			AddChild(ball);
			player = new Player();
			square = new Square();
			AddChild(square);
			
			
		}

        // Update is called every frame
        public override void Update(float deltaTime)
		{	
			player.Draw();
			player.WrapEdges();
			square.Draw();
			base.Update(deltaTime);
			HandleInput(deltaTime);

			Rectangle player_rec = new Rectangle(player.Position.X, player.Position.Y, player.texture.width, player.texture.height);
            Rectangle ball_rec = new Rectangle(ball.Position.X, ball.Position.Y, ball.texture.width, ball.texture.height);
                    if(Raylib.CheckCollisionRecs(player_rec, ball_rec)) {
						ball.Bounce();
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
	}
}
 // class
	
   
 // namespace
