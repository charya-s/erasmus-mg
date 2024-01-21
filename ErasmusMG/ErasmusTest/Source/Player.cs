using Microsoft.Xna.Framework;
using ErasmusMG.Graphics;
using ErasmusMG.Physics;
using Microsoft.Xna.Framework.Input;

namespace ErasmusTest.Source;
public class Player : PhysicsBody
{


    public Player(string name) : base(name)
    {
        this.AddToGroup("Player");  // Add to player group.
        this.AddToGroup("Characters"); // Add to characters group.

        // Set properties.
        this.GlobalPosition = new Vector2(200, 100);
        this.Gravity = 0.10f;

        // Components.
        AnimatedSprite sprite = new("Sprite", new Vector2(56, 56), "player.png");
        this.AddChild(sprite);
        sprite.AddAnimation("Idle", 0, 6, 5, Animation.LoopMode.Loop);
        sprite.AddAnimation("Move", 2, 8, 10, Animation.LoopMode.Loop);
        sprite.Play("Move");
        sprite.Position = new Vector2(0, 0);
        sprite.Scale = new Vector2(2, 2);
    }


    // Update method.
    public override void Update(double deltaTime)
    {
        base.Update(deltaTime);
        this.MoveAndCollide(deltaTime);
    }
}
