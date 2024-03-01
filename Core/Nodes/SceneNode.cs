using System.Runtime.CompilerServices;
using Raylib_cs;

namespace Movement
{
	enum State
	{
		Quit,
		Playing,
		Lost,
		Won
	}

	abstract class SceneNode : Node
	{
		public bool input = true;

		public int eliminated_squares = 0;
		public float playtime = 60.0f;
		public float current_time = 0f;
		public Gameover gameover;
		public Youwon youwon;
		public bool collide_ = true;


		
		public State State { get; set; }

		private string scenetitle;
		public string SceneTitle {
			get { return scenetitle; }
			set { scenetitle = value; }
		}

		protected SceneNode(string title) : base()
		{
			SceneTitle = title;
			State = State.Playing;
		}

		public override void Update(float deltaTime)
		{
			ShowFrameRate(deltaTime);
			ShowTitle();
			ShowScore();
			CountDown();
			Win();
		}

		private float timer = 0;
		private int framecounter = 0;
		private int showcounter = 0;
		private void ShowFrameRate(float deltaTime)
		{
			timer += deltaTime;
			framecounter++;
			if (timer > 1.0f) {
				timer = 0.0f;
				showcounter = framecounter;
				framecounter = 0;
			}

			Raylib.DrawText("fps: "+showcounter, 1150, 10, 20, Color.GREEN);
			// Raylib.DrawText("fps: "+Raylib.GetFPS(), 1150, 10, 20, Color.GREEN);
		}

		private void ShowScore()
		{

			//score = aantal dode enemies programmeren
				
				
			Raylib.DrawText("Score: "+ eliminated_squares, 1150, 30, 20, Color.BLUE);
			// Raylib.DrawText("fps: "+Raylib.GetFPS(), 1150, 10, 20, Color.GREEN);
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
			if(eliminated_squares == 10)
			{
				State = State.Won;
				youwon = new Youwon();
				AddChild(youwon);
				input = false;
			}
			
		}

		private void ShowTitle()
		{
			Raylib.DrawText(SceneTitle, 10, 10, 20, Color.WHITE);
		}
	}
}
