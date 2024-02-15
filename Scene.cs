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

		
		public BouncingBall ball;
		public Player player;

		

        // private fields
        //private Rectangle rectangle;

		

		

		

		

		

		//private Gameover gameover;

		//private Youwon youwon;

		

		

		// constructor + call base constructor
		public Scene(String t) : base(t)
		{
			ball = new BouncingBall();
			AddChild(ball);
			player = new Player();
			AddChild(player);
		}

        // Update is called every frame
        public override void Update(float deltaTime)
		{	
			base.Update(deltaTime);
			HandleInput(deltaTime);
		}

		private void HandleInput(float deltaTime)
		{
		
		}
	}
}
 // class
	
   
 // namespace
