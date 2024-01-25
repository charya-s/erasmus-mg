---
#layout: home
---

{% include navbar.html %}

# Hello!
Welcome to the ErasmusMG documentation site. 

ErasmusMG is a 2D game development framework written on top of MonoGame in C#. It is a collection of useful classes and methods to help create any 2D game, from platformers to top-down shooters.


# Introduction
ErasmusMG was created as an easier-to-pick up framework for game-developement than MonoGame. While the latter requires you to create many of your own classes for animations, collisions, etc., ErasmusMG comes with pre-built classes and methods to handle all of them at a rudimentary level, and since it's a simple extension of MonoGame itself, it retains the extensibility and the freedom to modify the inner workings that we all love about it. 

ErasmusMG also does **not** use MonoGame's content pipeline. Instead, it comes with helper classes to import various files such as textures, Tiled maps, etc.


# Getting started
All you have to do to get up and running with ErasmusMG is to download the repository (which includes a .csproj file) and add the project to your game's solution.

For a tutorial on how we can create a simple platformer with ErasmusMG, click here.