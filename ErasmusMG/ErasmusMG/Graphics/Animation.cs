using Microsoft.Xna.Framework;

namespace ErasmusMG.Graphics;
public class Animation
{
    // Properties.
    public string Name { get; set; } = "";
    private int row { get; set; } = 0;
    private int animationLength { get; set; } = 0;
    private Vector2 frameSize { get; set; } = Vector2.Zero;
    private int frameRate { get; set; } = 5; // In frames per second.
    public enum LoopMode { Once, Loop }
    private LoopMode loopMode { get; set; } = LoopMode.Loop;
    public bool IsAnimFinished { get; set; } = false;


    // Internal variables.
    private Rectangle frameRect;
    private int currFrameIndex;
    private float timeSinceLastFrame = 10000;


    // Constructor.
    public Animation(string name, int row, int animLen, Vector2 spriteSize, int frameRate, LoopMode loopMode)
    {
        this.row = row;
        this.Name = name;
        this.animationLength = animLen;
        this.frameSize = spriteSize;
        this.frameRect = new Rectangle(0, (int)this.frameSize.Y * this.row, (int)frameSize.X, (int)frameSize.Y);
        this.frameRate = frameRate;
        this.loopMode = loopMode;
    }


    // Update method.
    public virtual Rectangle Update(double delta)
    {
        // If not enough time has passed since last frame, don't update.
        if (this.timeSinceLastFrame < 1000 / this.frameRate)
        {
            this.timeSinceLastFrame += (float)delta * 1000;
            return this.frameRect;
        }
        this.timeSinceLastFrame = 0; // Reset time elapsed when updating.

        this.IsAnimFinished = false; // Reset animation finished flag.

        // Set frame rectangle based on the frame index and row.
        this.frameRect = new Rectangle((int)this.frameSize.X * this.currFrameIndex, (int)this.frameSize.Y * this.row, this.frameRect.Width, this.frameRect.Height);

        if (currFrameIndex == this.animationLength - 1) // If on last frame...
        {
            this.IsAnimFinished = true; // Set animation finished flag.
            if (this.loopMode == LoopMode.Loop) // If looping, loop back to 0.
            {
                currFrameIndex = 0;
            }
            // Else, stay on last frame.
        }
        else currFrameIndex++; // If mid-anim, increment frame index.

        return frameRect;
    }
}
