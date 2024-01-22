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
    private Component? rootComponent { get; set; } // Root component that contains all other components. 


    /* ------------------------------------------------------------------------------------------------------------- */
    /* ------------------------------------------------- GAME LOOP ------------------------------------------------- */

    // Load.
    public void Load()
    {
        //this.rootComponent?.Load();
    }
    // Update.
    public void Update(double deltaTime)
    {
        this.rootComponent?.Update(deltaTime);
    }
    // Draw.
    public void Draw(double deltaTime)
    {
        this.rootComponent?.Draw(deltaTime);
    }


    /* ------------------------------------------------------------------------------------------------------------- */
    /* ------------------------------------------ ROOT COMPONENT HANDLING ------------------------------------------ */

    // Set root component.
    public void SetRootComponent(Component c)
    {
        this.rootComponent = c;
        this.Load();
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

}
