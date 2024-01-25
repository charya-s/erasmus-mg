---

title: Animation
date: 2024-01-24
author: charya-s
categories: classes graphics
permalink: /graphics/Animation/

---


{% include navbar.html %}

# Animation
Animation helper class that loops through a spritesheet.

<br>

---
### This inherits from
- None.

<br>

---
###  Inherits from this
- None.

<br>

---
###  Construction
{% highlight csharp %}
Animation(string name, int row, int animLen, Vector2 spriteSize, int frameRate, LoopMode loopMode)
{% endhighlight %}
<br>| Parameter | Type | Description | 
| ---- | ---- | ----------- |
| name | string | Name of the animation. |
| row | int | The row of the animation in the sprite sheet. |
| animLen | int | The number of frames in the animation. |
| spriteSize | Vector2 | Size of a single sprite frame (without scaling). | 
| frameRate | int | Number of frames per second. | 
| loopMode | Animation.LoopMode | Whether the animation loops or not. | 

<br>

---
###  Public Properties

<br>| Name | string | Name of the animation. |
| IsAnimFinished | bool | Whether the animation has reached its final frame. |


<br>

---
###  Methods
{% highlight csharp %}
Rectangle GetNextFrame(double delta)
{% endhighlight %}
<br>| Parameter | Type | Description
| ---- | ---- | ----------- |
| delta | double | Time between frames. |

