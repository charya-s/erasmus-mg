using Microsoft.Xna.Framework;
using ErasmusMG.Graphics;
using ErasmusMG.Physics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System;

namespace ErasmusTest.Source;
public class Player : PhysicsBody
{


    public Player(string name) : base(name)
    {
        this.AddToGroup("Player");  // Add to player group.
        this.AddToGroup("Characters"); // Add to characters group.

        // Set properties.
        this.GlobalPosition = new Vector2(200, 100);
        this.Gravity = 0.0f;


        // Components.
        AnimatedSprite sprite = new("Sprite", new Vector2(56, 56), "player.png");
        this.AddChild(sprite);
        sprite.AddAnimation("Idle", 0, 6, 5, Animation.LoopMode.Loop);
        sprite.AddAnimation("Move", 2, 8, 10, Animation.LoopMode.Loop);
        sprite.AddAnimation("Jump", 3, 8, 5, Animation.LoopMode.Loop);
        sprite.AddAnimation("Fall", 4, 5, 5, Animation.LoopMode.Loop);
        sprite.PlayAnimation("Idle");
        sprite.Position = new Vector2(0, 0);
        sprite.Scale = new Vector2(2, 2);
        sprite.Origin = new Vector2(sprite.Size.X / 2, sprite.Size.Y / 2);

        Collider collider = new("Collider", new Vector2(sprite.ScaledSize.X/2, sprite.ScaledSize.Y));
        this.AddChild(collider);
        collider.VisibleCollider = true;
        collider.Origin = new Vector2(collider.ColliderBounds.Width/2, collider.ColliderBounds.Height/2);

        TextLabel text = new("PlayerLabel", "font.ttf", "Player");
        this.AddChild(text);
        text.Position = new Vector2(0, -sprite.ScaledSize.Y / 4);
        text.Tint = Color.Blue;
        text.Scale = new Vector2(0.5f, 0.5f);
        text.Origin = new Vector2(text.Size.X / 2, text.Size.Y / 2);
    }


    // Update method.
    public override void Update(double deltaTime)
    {
        base.Update(deltaTime);

        // Keyboard movement.
        if (Keyboard.GetState().IsKeyDown(Keys.A)) this.Velocity = new Vector2(-250f, 0);
        else if (Keyboard.GetState().IsKeyDown(Keys.D)) this.Velocity = new Vector2(250f, 0);
        else if (Keyboard.GetState().IsKeyDown(Keys.S)) this.Velocity = new Vector2(0, 100f);
        else if (Keyboard.GetState().IsKeyDown(Keys.W)) this.Velocity = new Vector2(0, -100f);
        else this.Velocity = new Vector2(0, 0);

        // Moving and idle anims.
        if (MathF.Abs(this.Velocity.X) > 0.1f) this.GetChild<AnimatedSprite>("Sprite").PlayAnimation("Move");
        else this.GetChild<AnimatedSprite>("Sprite").PlayAnimation("Idle");

        // Flip to move dir.
        if (this.Velocity.X > 0) this.GetChild<AnimatedSprite>("Sprite").FlipH(1);
        else if (this.Velocity.X < 0) this.GetChild<AnimatedSprite>("Sprite").FlipH(-1);

        // Apply gravity.
        this.Velocity = new Vector2(this.Velocity.X, this.Velocity.Y + this.Gravity * (float)deltaTime);


        // Apply physics motion.
        this.MoveAndCollide(deltaTime);
    }
}
