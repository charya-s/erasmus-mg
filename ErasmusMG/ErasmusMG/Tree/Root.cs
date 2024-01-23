using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace ErasmusMG.Tree;
public class Root
{
    // Properties.
    private Dictionary<string, List<Component>> groups { get; set; } = new(); // Groups that components can be assigned to.
    private Component rootComponent { get; set; } // Root component that contains all other components. 
    private Queue<float> fpsValues = new(); // Last 100 FPS values.
    public float GameFPS { get; private set; } = 0.0f;


    // Constructor.
    public Root()
    {
        this.rootComponent = new Component("Root");
    }


    /* ------------------------------------------------------------------------------------------------------------- */
    /* ------------------------------------------------- GAME LOOP ------------------------------------------------- */

    // Load.
    public void Load()
    {
    }
    // Update.
    public void Update(double deltaTime)
    {
        this.GetAvgFps(deltaTime);
        this.rootComponent.Update(deltaTime);
    }
    // Draw.
    public void Draw(double deltaTime)
    {
        this.rootComponent.Draw(deltaTime);
    }


    /* ------------------------------------------------------------------------------------------------------------- */
    /* ------------------------------------------ ROOT COMPONENT HANDLING ------------------------------------------ */

    // Set root component.
    public void AddToRoot(Component c)
    {
        this.rootComponent.AddChild(c);
    }
    // Get root component.
    public Component GetRoot()
    {
        return this.rootComponent;
    }


    /* ------------------------------------------------------------------------------------------------------------- */
    /* ---------------------------------------------- GROUPS HANDLING ---------------------------------------------- */

    // Add component to group (create new group if it's the first component).
    public void AddComponentToGroup(Component c, string gName)
    {
        if (this.groups.ContainsKey(gName)) this.groups[gName].Add(c);
        else this.groups.Add(gName, new List<Component>() { c });
    }
    // Remove component from group.
    public void RemoveComponentFromGroup(Component c, string gName)
    {
        if (!this.groups.ContainsKey(gName)) return; // Group does not exist.
        if (!this.groups[gName].Contains(c)) return; // Selected group does not contain component.
        this.groups[gName].Remove(c);
        if (this.groups[gName].Count == 0) this.groups.Remove(gName); // If group becomes empty, remove it from dictionary of groups.
    }
    // Get list of components in a specific group.
    public List<T> GetComponentsInGroup<T>(string gName) where T : Component
    {
        if (!this.groups.ContainsKey(gName)) return null; // Group does not exist.
        return this.groups[gName].Cast<T>().ToList();
    }



    // Calculate average fps.
    private void GetAvgFps(double deltaTime)
    {
        float currFps = 1 / (float)deltaTime;
        fpsValues.Enqueue(currFps); // Save current fps to queue.
        if (fpsValues.Count > 100)
        {
            fpsValues.Dequeue();
            this.GameFPS = fpsValues.Average(); // If queue is full, get average of it.
        }
        else this.GameFPS = currFps;            // Else, just get current fps.

    }
}
