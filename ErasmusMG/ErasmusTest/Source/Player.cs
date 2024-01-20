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
        this.Velocity = new Vector2(100, 0);
        this.Gravity = 0.10f;

        // Components.
        Sprite sprite = new("Sprite", new Vector2(64, 64));
        this.AddChild(sprite);
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
