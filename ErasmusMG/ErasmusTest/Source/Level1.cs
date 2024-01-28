using ErasmusMG.Tree;
using Microsoft.Xna.Framework;

namespace ErasmusTest.Source;
public class Level1 : Component
{


    public Level1(string name) : base(name)
    {
        Player player = new Player("Player");
        this.AddChild(player);


        Enemy enemy = new Enemy("Enemy");
        this.AddChild(enemy);
        enemy.GlobalPosition = new Vector2(200, 350);
        enemy.CanMove = false;
    }
}
