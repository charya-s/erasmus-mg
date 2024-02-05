using ErasmusMG.Tree;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ErasmusMG.Logic;
public class StateMachine : Component
{
    // Properties.
    private Dictionary<string, State> statesList = new();   // List of states with names.
    private State currState = null;                         // Current state.


    // Constructor.
    public StateMachine(string name) : base(name)
    {

    }


    // Update.
    public override void Update(double deltaTime)
    {
        this.currState?.Update(deltaTime);
        base.Update(deltaTime);
    }


    // Add state to machine.
    public void AddState(string newStateName, State newState)
    {
        if (this.statesList.ContainsValue(newState)) return; // State is already added.
        this.statesList.Add(newStateName, newState);
        if (this.statesList.Count == 1) this.SetState(newStateName); // If it's the first state added, make it the default starting state.
    }


    // Change state.
    public void SetState(string newStateName)
    {
        if (!this.statesList.ContainsKey(newStateName)) return; // State does not exist in list, so return.
        this.currState?.Exit(); // Exit current state if it exists.
        this.currState = this.statesList[newStateName]; // Set new current state.
        this.currState.Enter(); // Enter newly set current state.
    }

    // Get current state name.
    public string GetCurrentState()
    {
        foreach (KeyValuePair<string, State> state in this.statesList)
        {
            if (this.currState == state.Value) return state.Key;
        }
        return null;
    }
}
