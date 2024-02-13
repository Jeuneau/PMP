using System;
using System.Collections.Generic;
using Raylib_cs;

namespace Movement
{
	class Game
	{
		// private fields
		private Core core;
		private List<SceneNode> scenes;

		// constructor...
		public Game()
		{
			core = new Core("Movement");
			scenes = new List<SceneNode>();

			
			scenes.Add(new Scene("PMP"));
			
		}

		// public methods
		public void Play()
		{
			int scene_id = 0;
			bool running = true;
			while (running)
			{
				// handle scene_id
				if (Raylib.IsKeyReleased(KeyboardKey.KEY_LEFT_BRACKET)) { scene_id--; }
				if (Raylib.IsKeyReleased(KeyboardKey.KEY_RIGHT_BRACKET)) { scene_id++; }
				if (scene_id <= 0) { scene_id = 0; }
				if (scene_id >= scenes.Count) { scene_id = scenes.Count-1; }

				// run current scene
				SceneNode current = scenes[scene_id];
				running = core.Run(current);
			}

			Console.WriteLine("Thank you for playing!");
		}
	}
}
