

using ErasmusMG.Importers;
using ErasmusMG.Tree;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace ErasmusMG.Physics;
public class PhysicsBody : Component
{
    // Properties.
    public Vector2 Velocity { get; set; } = Vector2.Zero;
    public float Gravity { get; set; } = 0.0f;


    // Constructor.
    public PhysicsBody(string name) : base(name)
    {
    }


    // Update method.
    public override void Update(double deltaTime)
    {
        base.Update(deltaTime);
    }


    // Move and collide.
    public void MoveAndCollide(double deltaTime)
    {
        Vector2 adjustedVelocity = this.Velocity * (float)deltaTime;
        this.Position = new Vector2(this.Position.X + adjustedVelocity.X, this.Position.Y + adjustedVelocity.Y);
    }
}
