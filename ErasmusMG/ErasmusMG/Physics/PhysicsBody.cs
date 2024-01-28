using ErasmusMG.Tree;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ErasmusMG.Physics;
public class PhysicsBody : Component
{
    // Properties.
    private Vector2 velocity { get; set; } = Vector2.Zero;
    public float Gravity { get; set; } = 0.0f;
    public bool CanMove { get; set; } = true;
    public bool IsOnGround { get; private set; } = false; // Is this body on the ground (colliding on bottom).


    // Constructor.
    public PhysicsBody(string name) : base(name)
    {
    }


    // Update method.
    public override void Update(double deltaTime)
    {
        base.Update(deltaTime);
    }


    // Velocity getter and setter (checks for collider before changing velocity).
    public Vector2 Velocity
    {
        get { return this.velocity; }
        set
        {
            if (!this.GetChildren().OfType<Collider>().Any() || !this.CanMove) // No collider attached or cannot move, velocity to 0.
            {
                this.velocity = Vector2.Zero; 
                return;
            }
            this.velocity = value;
        }
    }


    // Move and collide.
    public void MoveAndCollide(double deltaTime)
    {
        if (!this.GetChildren().OfType<Collider>().Any() || !this.CanMove) return; // No collider attached or cannot move.

        Vector2 adjustedVelocity = this.Velocity * (float)deltaTime;
        Vector2 movedPos = new Vector2(this.Position.X + adjustedVelocity.X, this.Position.Y + adjustedVelocity.Y); // Look ahead a frame.

        foreach (KeyValuePair<Collider, Vector2> collision in this.GetChild<Collider>("Collider").Collisions)
        {
            // Top and bottom.
            if (collision.Value.Y == -1) // Collision on bottom, prevent move futher +Y.
            {
                movedPos = new Vector2(movedPos.X, MathF.Min(this.Position.Y, movedPos.Y));
                if (this.Velocity.Y > 0) this.Velocity = new Vector2(this.Velocity.X, 0); // Clamp at zero if velocity tries to continue in +Y.
                this.IsOnGround = true; // Bottom collision = is on ground (metaphorically LOL).
            }
            else if (collision.Value.Y == 1) // Collision on top, prevent move futher -Y. 
            {
                movedPos = new Vector2(movedPos.X, MathF.Max(this.Position.Y, movedPos.Y));
                if (this.Velocity.Y < 0) this.Velocity = new Vector2(this.Velocity.X, 0); // Clamp at zero if velocity tries to continue in -Y.
            }

            // Left and right.
            if (collision.Value.X == -1) // Collision on left, prevent move futher -X.
            {
                movedPos = new Vector2(MathF.Max(this.Position.X, movedPos.X), movedPos.Y);
                if (this.Velocity.X < 0) this.Velocity = new Vector2(0, this.Velocity.Y); // Clamp at zero if velocity tries to continue in -X.
            }
            else if (collision.Value.X == 1) // Collision on right, prevent move futher +X.
            {
                movedPos = new Vector2(MathF.Min(this.Position.X, movedPos.X), movedPos.Y);
                if (this.Velocity.X > 0) this.Velocity = new Vector2(0, this.Velocity.Y); // Clamp at zero if velocity tries to continue in +X.
            }
        }
        
        this.Position = movedPos; // No collisions, simply move.
    }
}
