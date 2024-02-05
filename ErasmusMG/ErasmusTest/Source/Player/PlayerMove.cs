using ErasmusMG.Graphics;
using ErasmusMG.Logic;
using ErasmusMG.Tree;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ErasmusTest.Source;
public class PlayerMove : State
{
    private Player player { get; set; } = null; // Since this is a player-exclusive state.

    // Constructor.
    public PlayerMove(Component owner, StateMachine machine) : base(owner, machine)
    {
        this.player = (Player)owner;
    }


    // Enter, exit and update state.
    public override void Enter()
    {
        this.player.GetChild<AnimatedSprite>("Sprite").PlayAnimation("Move");
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
        Vector2 moveDir = Vector2.Zero;
        if (Keyboard.GetState().IsKeyDown(Keys.A)) moveDir += new Vector2(-1, 0);
        if (Keyboard.GetState().IsKeyDown(Keys.D)) moveDir += new Vector2(1, 0);
        if (moveDir == Vector2.Zero) this.machine.SetState("Idle");
        else
        {
            this.player.Velocity = moveDir * 250f;
            // Flip to move dir.
            if (this.player.Velocity.X > 0) this.player.GetChild<AnimatedSprite>("Sprite").FlipH(1);
            else if (this.player.Velocity.X < 0) this.player.GetChild<AnimatedSprite>("Sprite").FlipH(-1);
        }

        // Apply gravity.
        this.player.ApplyGravity(this.player.Gravity, this.player.JumpSpeed);
        }
}
