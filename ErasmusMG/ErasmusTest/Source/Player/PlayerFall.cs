using ErasmusMG.Graphics;
using ErasmusMG.Logic;
using ErasmusMG.Tree;
using Microsoft.Xna.Framework;

namespace ErasmusTest.Source;
public class PlayerFall : State
{
    private Player player { get; set; } = null; // Since this is a player-exclusive state.

    // Constructor.
    public PlayerFall(Component owner, StateMachine machine) : base(owner, machine)
    {
        this.player = (Player)owner;
    }


    // Enter, exit and update state.
    public override void Enter()
    {
        this.player.GetChild<AnimatedSprite>("Sprite").PlayAnimation("Fall");
    }

    public override void Exit()
    {

    }

    public override void Update(double deltaTime)
    {
        // Idling.
        if (player.IsOnGround) this.machine.SetState("Idle");

        // Apply gravity.
        this.player.ApplyGravity(this.player.Gravity, this.player.JumpSpeed);
    }
}
