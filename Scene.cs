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
		List<Square> squares;
        private Square square;
        private Square square2;
        private Square square3;

		private Square square4;
		private Square square5;

		private Square square6;
        private Square square7;
        private Square square8;

		private Square square9;
		private Square square10;
		
		

		// constructor + call base constructor
		public Scene(String t) : base(t)
		{
			ball = new Ball();
			AddChild(ball);
			player = new Player();
			squares= new List<Square>();
			square= new Square();
			square2= new Square();
			square3= new Square();
			square4= new Square();
			square5= new Square();
			square6= new Square();
			square7= new Square();
			square8= new Square();
			square9= new Square();
			square10= new Square();

			
			AddChild(square);
			AddChild(square2);
			AddChild(square3);
			AddChild(square4);
			AddChild(square5);
			AddChild(square6);
			AddChild(square7);
			AddChild(square8);
			AddChild(square9);
			AddChild(square10);
			
			squares.Add(square);
			squares.Add(square2);
			squares.Add(square3);
			squares.Add(square4);
			squares.Add(square5);
			squares.Add(square6);
			squares.Add(square7);
			squares.Add(square8);
			squares.Add(square9);
			squares.Add(square10);

			square.Position = new Vector2(200,75);
			square2.Position= new Vector2(600,75);
			square3.Position= new Vector2(1000,75);
			square4.Position = new Vector2(200,175);
			square5.Position = new Vector2(600,175);
			square6.Position = new Vector2(1000,175);
			square7.Position= new Vector2(200,275);
			square8.Position= new Vector2(600,275);
			square9.Position = new Vector2(1000,275);
			square10.Position = new Vector2(200,375);
		}

        // Update is called every frame
        public override void Update(float deltaTime)
		{	
			player.Draw();
			player.WrapEdges();
			base.Update(deltaTime);
			HandleInput(deltaTime);
			Collide();
			
		}

		 
		private void HandleInput(float deltaTime)
		{
			if(input == true)
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

		private void Collide()
		{
				Rectangle player_rec = new Rectangle(player.Position.X, player.Position.Y, player.texture.width, player.texture.height);
				Rectangle ball_rec = new Rectangle(ball.Position.X, ball.Position.Y, ball.texture.width, ball.texture.height);
						if(Raylib.CheckCollisionRecs(player_rec, ball_rec)) {
							ball.Bounce();
						}
				for(int i = 0; i < squares.Count; i++) 
				{
					Rectangle square_rec = new Rectangle(squares[i].Position.X, squares[i].Position.Y, square.texture.width, square.texture.height);   
					if(Raylib.CheckCollisionRecs(square_rec, ball_rec)) {
						RemoveChild(squares[i]);
						squares.RemoveAt(i);
						eliminated_squares++;
					}
				}
		}
	}
}
 // class
	
   
 // namespace
