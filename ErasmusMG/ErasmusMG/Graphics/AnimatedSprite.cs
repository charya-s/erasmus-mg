﻿using ErasmusMG.Importers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace ErasmusMG.Graphics;
public class AnimatedSprite : Sprite
{
    // Properties.
    public Animation CurrentAnimation { get; set; }
    private Dictionary<string, Animation> animations { get; set; } = new();


    // Constructor.
    public AnimatedSprite(string name, Vector2 size, string pathToTexture) : base(name, size, pathToTexture)
    {
    }


    // Load.
    public override void Load()
    {
        base.Load();
    }


    // Update.
    public override void Update(double delta)
    {
        base.Update(delta);
        if (this.CurrentAnimation != null) sourceRect = CurrentAnimation.GetNextFrame(delta);
    }


    // Play animation.
    public void PlayAnimation(string animName)
    {
        if (!animations.ContainsKey(animName)) return; // Cancel play if animation doesn't exist.
        this.CurrentAnimation = animations[animName];
    }


    // Add animation.
    public void AddAnimation(string name, int sheetRow, int animLen, int frameRate, Animation.LoopMode loopMode)
    {
        this.animations[name] = new Animation(name, sheetRow, animLen, this.Size, frameRate, loopMode);
        if (animations.Count == 1) this.PlayAnimation(name); // If it's the first animation, set it to be the starting point.
    }
}
