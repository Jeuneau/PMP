using System;
using System.Collections.Generic;
using Raylib_cs;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Threading;




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
		public Sound hit;
		public Sound hit2;
		public Music bgm;
		float scr_width = Settings.ScreenSize.X;
		float scr_height = Settings.ScreenSize.Y;
		public bool input = true;

		public int eliminated_tiles = 0;
		public float playtime = 40.0f;
		public float current_time = 0f;
		public Gameover gameover;
		public Youwon youwon;
		public Background bg;
		
		

		// constructor + call base constructor
		public Scene(String t) : base(t)
		{
			bg = new Background();
			ball = new Ball();
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

			tile.Position = new Vector2(200,50);
			tile2.Position= new Vector2(600,100);
			tile3.Position= new Vector2(950,50);
			tile4.Position = new Vector2(700,300);
			tile5.Position = new Vector2(400,200);
			tile6.Position = new Vector2(800,50);
			tile7.Position= new Vector2(1000,200);
			tile8.Position= new Vector2(80,200);
			tile9.Position = new Vector2(75,400);
			tile10.Position = new Vector2(400,300);

			Raylib.InitAudioDevice(); 
			hit = Raylib.LoadSound("resources/ball_hits_paddle.wav");
			hit2 = Raylib.LoadSound("resources/clown_horn.wav");
			bgm = Raylib.LoadMusicStream("resources/Arkanoid_bgm.mp3");
		}

        // Update is called every frame
        public override void Update(float deltaTime)
		{	
			bg.Draw();
			AddChild(ball);
			player.Draw();
			player.WrapEdges();
			tiles.ForEach(tile => tile.Draw());
			base.Update(deltaTime);
			HandleInput(deltaTime);
			Collide();
			Play_bgm();
			Miss();
			ShowScore();
			CountDown();
			Win();
			Restart();
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
				ball.Bounce();
				Raylib.PlaySound(hit);     
			}
			for (int i = 0; i < tiles.Count; i++)
			{
				if (Raylib.CheckCollisionCircleRec(new Vector2(ball.Position.X, ball.Position.Y), radius, new Rectangle(tiles[i].Position.X, tiles[i].Position.Y, tile.texture.width, tile.texture.height)))
				{
					RemoveChild(tiles[i]);
					tiles.RemoveAt(i);
					eliminated_tiles++;
					Raylib.PlaySound(hit2);
					ball.Bounce();
				}
			} 
		}

		private void Play_bgm()
		{
			if(current_time > 0)
			{
				Raylib.PlayMusicStream(bgm);
			}	
		}

		public void Miss()
		{
			float spr_height = ball.texture.height;
			if (Position.Y > scr_height - spr_height/2)
			{
				State = State.Lost;
				playtime = 0;
				gameover = new Gameover();
				AddChild(gameover);
				input = false;
			}
		}

		public void ShowScore()
		{
			Raylib.DrawText("Score: "+ eliminated_tiles, 1150, 30, 20, Color.BLUE);
		}

		private void CountDown()
		{
			current_time = Raylib.GetFrameTime();
			playtime -= current_time;
			
			if(playtime <= 0)
			{
				State = State.Lost;
				playtime = 0;
				gameover = new Gameover();
				AddChild(gameover);
				input = false;
			}
			Raylib.DrawText($"Time: {playtime:0.00}", 1150, 50, 20, Color. RED);
		}

		public void Win()
		{
			if(eliminated_tiles == 10)
			{
				State = State.Won;
				youwon = new Youwon();
				AddChild(youwon);
				input = false;
			}
		}

		public void Restart()
		{
			if (Raylib.IsKeyPressed(KeyboardKey.KEY_R))
			{
				Game game = new Game();
				game.Play();
			}
		}
	}
}
 // class
	
   
 // namespace
