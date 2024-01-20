using Microsoft.Xna.Framework;
using System.ComponentModel;

namespace ErasmusMG.Logic;
public abstract class State
{
    // Properties.
    protected Component owner { get; private set; }         // The component this state controls.
    protected StateMachine machine { get; private set; }    // The FSM this state belongs to.


    // Constructor.
    public State(Component owner, StateMachine machine)
    {
        this.owner = owner;
        this.machine = machine;
    }


    // Enter, exit and update state.
    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update(GameTime gameTime);
}
