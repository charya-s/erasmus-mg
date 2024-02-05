using ErasmusMG.Graphics;
using ErasmusMG.Logic;
using ErasmusMG.Tree;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace ErasmusTest.Source;
public class PlayerIdle : State
{
    private Player player { get; set; } = null; // Since this is a player-exclusive state.

    // Constructor.
    public PlayerIdle(Component owner, StateMachine machine) : base(owner, machine)
    {
        this.player = (Player)owner;
    }


    // Enter, exit and update state.
    public override void Enter()
    {
        this.player.GetChild<AnimatedSprite>("Sprite").PlayAnimation("Idle");
        this.player.Velocity = Vector2.Zero;
    }

    public override void Exit()
    {

    }

    public override void Update(double deltaTime)
    {
        // Falling.
        if (player.Velocity.Y > 0.1f) this.machine.SetState("Fall");

        // Jumping.
        if (Keyboard.GetState().IsKeyDown(Keys.Space) && this.player.IsOnGround) this.machine.SetState("Jump");

        // Movement.
        if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.D)) this.machine.SetState("Move");

        // Apply gravity.
        this.player.ApplyGravity(this.player.Gravity, this.player.JumpSpeed);
    }
}
