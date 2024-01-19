


using ErasmusMG.Globals;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace ErasmusMG.Tree;
public class Component
{
    // Properties.
    public string Name { get; set; } = string.Empty; // This component's name.
    private List<Component> children { get; set; } = new(); // List of child components.
    private Component? parent { get; set; } // This component's parent. Can be null if root component.
    private List<string> groups; // List of groups this component belongs to.


    // Constructor.
    public Component(string name) 
    { 
        this.Name = name;
    }


    /* ------------------------------------------------------------------------------------------------------------- */
    /* ------------------------------------------------- GAME LOOP ------------------------------------------------- */

    // Load.
    public virtual void Load()
    {

    }
    // Update.
    public virtual void Update(GameTime gameTime)
    {

    }
    // Draw.
    public virtual void Draw(GameTime gameTime)
    {

    }


    /* ------------------------------------------------------------------------------------------------------------- */
    /* ------------------------------------------- PARENT/CHILD HANDLING ------------------------------------------- */

    // Set parent (called when added to a component as a child).
    public void SetParent(Component parent) 
    { 
        this.parent = parent; 
    }
    // Add child to self.
    public void AddChild(Component child)
    {
        child.SetParent(this); // Set child's parent as self.
        children.Add(child);
    }
    // Get child by name.
    public T GetChild<T>(string childName) where T : Component
    {
        foreach (Component child in this.children)
        {
            if (child.Name == childName) return child as T; // If child found, return it.
        }
        return null; // Child doesn't exist.
    }
    // Get list of children.
    public List<Component> GetChildren()
    {
        return this.children;
    }


    /* ------------------------------------------------------------------------------------------------------- */
    /* ------------------------------------------- GROUPS HANDLING ------------------------------------------- */

    // Add to group.
    public void AddToGroup(string groupName)
    {
        this.groups.Add(groupName);
        Engine.Root.AddComponentToGroup(this, groupName); // Remove from group in engine.
    }
    // Remove from group.
    public void RemoveFromGroup(string groupName)
    {
        if (!this.groups.Contains(groupName)) return; // Component does not belong to group.
        this.groups.Remove(groupName);
        Engine.Root.RemoveComponentFromGroup(this, groupName); // Remove from group in engine.
    }
    // Return list of groups this component belongs to.
    public List<string> GetGroups()
    {
        return this.groups;
    }
}
