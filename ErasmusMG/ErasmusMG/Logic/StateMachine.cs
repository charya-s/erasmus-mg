using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.ComponentModel;

namespace ErasmusMG.Logic;
public class StateMachine
{
    // Properties.
    protected Component owner { get; private set; }         // The component this machine controls.
    private Dictionary<string, State> statesList = new();   // List of states with names.
    private State currState = null;                         // Current state.


    // Constructor.
    public StateMachine(Component owner)
    {
        this.owner = owner;
    }


    // Update.
    public void Update(GameTime gameTime)
    {
        this.currState?.Update(gameTime);
    }


    // Change state.
    public void SetState(string newStateName)
    {
        if (!this.statesList.ContainsKey(newStateName)) return; // State does not exist in list, so return.
        this.currState?.Exit(); // Exit current state if it exists.
        this.currState = this.statesList[newStateName]; // Set new current state.
        this.currState.Enter(); // Enter newly set current state.
    }
}
