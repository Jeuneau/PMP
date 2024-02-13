using System.Numerics;

namespace Movement;

class GUI : SpriteNode  {
private int health;




     public GUI() : base("resources/Spaceship_health.png")
    {
       
        Position= new Vector2(120,80);
        Pivot= new Vector2(0,0);
    }

    void Update() {
    
    }


    

}
   