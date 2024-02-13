using System; // Console
using System.Numerics; // Vector2
using Raylib_cs; // Color



namespace Movement
{
    class Youwon : MoverNode
    {
        public Youwon() : base("resources/Spaceman_YouWon.png") {

            Position = new Vector2(Settings.ScreenSize.X / 2, Settings.ScreenSize.Y / 2);

        }
    }



}