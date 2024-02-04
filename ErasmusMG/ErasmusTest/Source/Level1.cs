using ErasmusMG;
using ErasmusMG.Tree;
using Microsoft.Xna.Framework;

namespace ErasmusTest.Source;
public class Level1 : Component
{


    public Level1(string name) : base(name)
    {
        Map map = new Map("Map", "map.tmx", "map.tsx", "map.png");
        this.AddChild(map);
        map.GlobalPosition = new Vector2(100, 150);
        map.SetCollisionLayer("CollisionLayer");
        map.VisibleCollider = true;

        Player player = new Player("Player");
        this.AddChild(player);

        Enemy enemy = new Enemy("Enemy");
        this.AddChild(enemy);
        enemy.GlobalPosition = new Vector2(300, 0);
        enemy.CanMove = false;
    }
}
