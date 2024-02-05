using ErasmusMG.Graphics;
using ErasmusMG.Logic;
using ErasmusMG.Tree;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace ErasmusTest.Source;
public class PlayerJump : State
{
    private Player player { get; set; } = null; // Since this is a player-exclusive state.

    // Constructor.
    public PlayerJump(Component owner, StateMachine machine) : base(owner, machine)
    {
        this.player = (Player)owner;
    }


    // Enter, exit and update state.
    public override void Enter()
    {
        this.player.GetChild<AnimatedSprite>("Sprite").PlayAnimation("Jump");
        this.player.Velocity = new Vector2(this.player.Velocity.X, -this.player.JumpSpeed);
    }

    public override void Exit()
    {

    }

    public override void Update(double deltaTime)
    {
        // Falling.
        if (player.Velocity.Y > 0.1f) this.machine.SetState("Fall");

        // Idling.
        if (player.IsOnGround) this.machine.SetState("Idle");

        // Apply gravity.
        this.player.ApplyGravity(this.player.Gravity, this.player.JumpSpeed);
    }
}
