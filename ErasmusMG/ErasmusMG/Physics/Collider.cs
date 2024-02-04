using ErasmusMG.Globals;
using ErasmusMG.Helpers;
using ErasmusMG.Tree;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ErasmusMG.Physics;
public class Collider : Component
{
    // Properties.
    private Vector2 size { get; set; } // Size pre-scaling.
    public Rectangle ColliderBounds { get; private set; }   // The collision rectangle itself.
    public bool active = true; // Is this collider active.
    private List<int> collisionMasks { get; set; } = new() { 1 }; // The layers this collider looks to collide with.
    private List<int> collisionLayers { get; set; } = new() { 1 }; // The layers this collider is in for other colliders to collide with it.
    public Vector2 Origin { get; set; } = Vector2.Zero;
    public bool VisibleCollider { get; set; } = false;
    private Texture2D visibleCollider { get; set; } = new Texture2D(Engine.Graphics.GraphicsDevice, 1, 1); // Draw a box according to the collider bounds.


    // Constructors.
    public Collider(string name, Vector2 size) : base(name)
    {
        this.size = size;
        this.ColliderBounds = new Rectangle((int)this.GlobalPosition.X, (int)this.GlobalPosition.Y, (int)this.size.X, (int)this.size.Y);
        this.Active = true;

        this.visibleCollider = new Texture2D(Engine.Graphics.GraphicsDevice, 1, 1);
        this.visibleCollider.SetData(new Color[] { Color.LightGreen });
    }

    /* ------------------------------------------------------------------------------------------------------------ */
    /* -------------------------------------------- PROPERTY SETTERS ---------------------------------------------- */

    // Active status.
    public bool Active
    {
        get { return this.active; }
        set
        {
            this.active = value;
            if (value) Engine.Root.ActiveColliders.Add(this);   // Add to global collider list when activated.
            else Engine.Root.ActiveColliders.Remove(this);      // Remove from global collider list when deactivated.
        }
    }
    // Overriden scale setter (auto-updates ScaledSize).
    public override Vector2 Scale
    {
        get { return this.scale; }
        set
        {
            this.scale = value;
            this.ColliderBounds = new Rectangle((int)this.GlobalPosition.X - (int)this.Origin.X, 
                                                (int)this.GlobalPosition.Y - (int)this.Origin.Y, 
                                                (int)this.size.X * (int)this.Scale.X,
                                                (int)this.size.Y * (int)this.Scale.Y); //  Change size to match scale.
        }
    }


    /* ------------------------------------------------------------------------------------------------------------- */
    /* ------------------------------------------------- GAME LOOP ------------------------------------------------- */

    // Load method.
    public override void Load()
    {
        // Set position on load.
        this.ColliderBounds = new Rectangle((int)this.GlobalPosition.X - (int)this.Origin.X, (int)this.GlobalPosition.Y - (int)this.Origin.Y, 
                                            this.ColliderBounds.Width, this.ColliderBounds.Height);
        base.Load();
    }

    // Update method.
    public override void Update(double deltaTime)
    {
        // Update collider position.
        this.ColliderBounds = new Rectangle((int)this.GlobalPosition.X - (int)this.Origin.X, (int)this.GlobalPosition.Y - (int)this.Origin.Y, 
                                            this.ColliderBounds.Width, this.ColliderBounds.Height);

        // Get current collisions.
        //this.GetCollisions();

        base.Update(deltaTime);
    }

    // Draw method.
    public override void Draw(double deltaTime)
    {
        if (this.VisibleCollider) // Draw a visible bounding box is enabled.
        {
            Engine.SpriteBatch.Draw(    this.visibleCollider, 
                                        new Vector2(this.ColliderBounds.X, this.ColliderBounds.Y),
                                        new Rectangle(0, 0, this.ColliderBounds.Width, this.ColliderBounds.Height),
                                        Color.White*0.5f,
                                        this.Rotation,
                                        Vector2.Zero,   // Origin is applied to the bounding box directly.
                                        Vector2.One,    // Scale is applied to the bounding box directly.
                                        SpriteEffects.None,
                                        this.LayerDepth);
        }
        base.Draw(deltaTime);
    }


    /* -------------------------------------------------------------------------------------------------------------- */
    /* -------------------------------------------- COLLISION HANDLING ---------------------------------------------- */

    // Get collisions that would occur with the given motion.
    public Dictionary<Collider, Vector2> GetCollisions(Vector2 motion) 
    {
        //this.Collisions.Clear(); // Clear list of collisions at start of check.

        Dictionary<Collider, Vector2> collisions = new(); // List of collisions.

        // Get future collider rect as if we moved one unit in X and Y in the direction of motion.
        Rectangle movedBounds = new Rectangle(this.ColliderBounds.X + Math.Sign(motion.X), this.ColliderBounds.Y + Math.Sign(motion.Y), this.ColliderBounds.Width, this.ColliderBounds.Height);

        if (!this.Active) return null; // Skip if self inactive.

        // Loop through each active collider...
        foreach (Collider c in Engine.Root.ActiveColliders)
        {
            if (c == this) continue; // Skip self.
            if (!c.Active) continue; // Skip if target collider inactive.
            if (Mather.DistanceBetweenRects(movedBounds, c.ColliderBounds) > movedBounds.Width*10f) continue; // Don't bother checking collisions on objects far away.
            if (!c.ColliderBounds.Intersects(movedBounds)) continue; // No collision.
            if (!c.collisionLayers.Intersect(this.collisionMasks).Any()) continue; // The target collider is not on any layers this one watches.
            
            // All checks pass and collision has occured, so get the direction of collision.
            Vector2 collDir = Vector2.Zero;

            //Debug.WriteLine(c.ColliderBounds + " : " + movedBounds);

            // Collision can only occur from direction at a time.
            if (movedBounds.Y + movedBounds.Height > c.ColliderBounds.Y && // Check if future pos intersects target.
                this.ColliderBounds.Y + this.ColliderBounds.Height < c.ColliderBounds.Y + 1) // Check if target is on the correct side of the current box.
            {
                collDir = new Vector2(collDir.X, -1); // Collision on bottom.
            }
            else if (movedBounds.Y < c.ColliderBounds.Y + c.ColliderBounds.Height &&
                this.ColliderBounds.Y - 1 > c.ColliderBounds.Y + c.ColliderBounds.Height)
            {
                collDir = new Vector2(collDir.X, 1); // Collision on top.
            }

            if (movedBounds.X < c.ColliderBounds.X + c.ColliderBounds.Width &&
                this.ColliderBounds.X - 1 > c.ColliderBounds.X + c.ColliderBounds.Width)
            {
                collDir = new Vector2(-1, collDir.Y); // Collision on left.
            }
            else if (movedBounds.X + movedBounds.Width > c.ColliderBounds.X &&
                this.ColliderBounds.X + this.ColliderBounds.Width < c.ColliderBounds.X + 1)
            {
                Debug.WriteLine(c.ColliderBounds + " : " + movedBounds);
                collDir = new Vector2(1, collDir.Y); // Collision on right.
            }

            collisions.Add(c, collDir);
        }
        return collisions;
    }
}
