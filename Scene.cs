using System;
using System.Collections.Generic;
using Raylib_cs;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;



namespace Movement
{
	class Scene : SceneNode
	{	
		public Ball ball;
		public Player player;
		List<Tile> tiles;
        private Tile tile;
        private Tile tile2;
        private Tile tile3;

		private Tile tile4;
		private Tile tile5;

		private Tile tile6;
        private Tile tile7;
        private Tile tile8;

		private Tile tile9;
		private Tile tile10;
		public float radius = 16;
		
		

		// constructor + call base constructor
		public Scene(String t) : base(t)
		{
			ball = new Ball();
			AddChild(ball);
			player = new Player();
			tiles = new List<Tile>();
			tile = new Tile();
			tile2 = new Tile();
			tile3 = new Tile();
			tile4 = new Tile();
			tile5 = new Tile();
			tile6 = new Tile();
			tile7 = new Tile();
			tile8 = new Tile();
			tile9 = new Tile();
			tile10 = new Tile();

			
			AddChild(tile);
			AddChild(tile2);
			AddChild(tile3);
			AddChild(tile4);
			AddChild(tile5);
			AddChild(tile6);
			AddChild(tile7);
			AddChild(tile8);
			AddChild(tile9);
			AddChild(tile10);
			
			tiles.Add(tile);
			tiles.Add(tile2);
			tiles.Add(tile3);
			tiles.Add(tile4);
			tiles.Add(tile5);
			tiles.Add(tile6);
			tiles.Add(tile7);
			tiles.Add(tile8);
			tiles.Add(tile9);
			tiles.Add(tile10);

			tile.Position = new Vector2(200,75);
			tile2.Position= new Vector2(600,75);
			tile3.Position= new Vector2(1000,75);
			tile4.Position = new Vector2(200,175);
			tile5.Position = new Vector2(600,175);
			tile6.Position = new Vector2(1000,175);
			tile7.Position= new Vector2(200,275);
			tile8.Position= new Vector2(600,275);
			tile9.Position = new Vector2(1000,275);
			tile10.Position = new Vector2(200,375);
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
			
			if (Raylib.CheckCollisionCircleRec(new Vector2(ball.Position.X, ball.Position.Y), radius, new Rectangle(player.Position.X, player.Position.Y, player.texture.width, player.texture.height)))
			{
				Console.WriteLine("collide");
				ball.Bounce();
				Console.WriteLine("Ball position: " + ball.Position);
			}
			for (int i = 0; i < tiles.Count; i++)
			{
				if (Raylib.CheckCollisionCircleRec(new Vector2(ball.Position.X, ball.Position.Y), radius, new Rectangle(tiles[i].Position.X, tiles[i].Position.Y, tile.texture.width, tile.texture.height)))
				{
					RemoveChild(tiles[i]);
					tiles.RemoveAt(i);
					eliminated_tiles++;
				}
			}
		}
	}
}
 // class
	
   
 // namespace
