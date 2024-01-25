


using ErasmusMG.Globals;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace ErasmusMG.Tree;
public class Component
{
    // Properties.
    public string Name { get; set; } = string.Empty; // This component's name.
    private List<Component> children { get; set; } = new(); // List of child components.
    private Component? parent { get; set; } // This component's parent. Can be null if root component.
    private List<string> groups = new(); // List of groups this component belongs to.


    // Physical properties.
    private Vector2 position = Vector2.Zero; // Position relative to parent.
    private Vector2 globalPosition = Vector2.Zero; // Position relative to window.
    public float Rotation { get; set; } = 0.0f;
    private Vector2 scale { get; set; } = Vector2.One;
    public float LayerDepth { get; set; } = 0.0f;


    // Constructor.
    public Component(string name) 
    { 
        this.Name = name;
    }


    /* ------------------------------------------------------------------------------------------------------------ */
    /* -------------------------------------------- PROPERTY SETTERS ---------------------------------------------- */

    // Position.
    public Vector2 Position
    {
        get { return this.position; }
        set
        {
            this.position = value;
            // Adjust global pos based on parent's global pos and own pos.
            this.globalPosition = this.parent == null ? this.Position : this.Position + this.parent.GlobalPosition;
        }
    }
    // Global Position.
    public Vector2 GlobalPosition
    {
        get { return this.globalPosition; }
        set
        {
            this.globalPosition = value;
            // Adjust pos based on parent's global pos and own global pos.
            this.position = this.parent == null ? this.GlobalPosition : this.GlobalPosition - this.parent.GlobalPosition;
        }
    }
    // Scale.
    public virtual Vector2 Scale
    {
        get { return this.scale; }
        set { this.scale = value; }
    }


    /* ------------------------------------------------------------------------------------------------------------- */
    /* ------------------------------------------------- GAME LOOP ------------------------------------------------- */

    // Load.
    public virtual void Load()
    {
        foreach (Component c in this.children) c.Load();
    }
    // Update.
    public virtual void Update(double deltaTime)
    {
        foreach (Component c in this.children)
        {
            c.Position = c.Position; // Update global positions of children (offsetting based on parent is done in the setter).
            c.Update(deltaTime);
        }
    }
    // Draw.
    public virtual void Draw(double deltaTime)
    {
        foreach (Component c in this.children) c.Draw(deltaTime);
    }


    /* ------------------------------------------------------------------------------------------------------------- */
    /* ------------------------------------------- PARENT/CHILD HANDLING ------------------------------------------- */

    // Set parent (called when added to a component as a child).
    public void SetParent(Component parent) 
    { 
        this.parent = parent; 
    }
    // Get parent as component.
    public Component GetParent()
    {
        if (this.parent == null) return null; // No parent.
        return this.parent;
    }
    // Add child to self.
    public void AddChild(Component child)
    {
        child.SetParent(this); // Set child's parent as self.
        children.Add(child);
        child.Load(); // Run loading method.
    }
    // Get child by name as specified type.
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
