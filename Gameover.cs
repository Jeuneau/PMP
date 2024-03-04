using System; // Console
using System.Numerics; // Vector2
using Raylib_cs; // Color



namespace Movement
{
    class Gameover : SpriteNode
    {
        public Gameover() : base("resources/Spaceman_gameover.png") {

            Position = new Vector2(Settings.ScreenSize.X / 2, Settings.ScreenSize.Y / 2);

        }
    }



}