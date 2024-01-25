---

title: AnimatedSprite
date: 2024-01-24
author: charya-s
categories: classes graphics
permalink: /graphics/AnimatedSprite/

---


{% include navbar.html %}

# AnimatedSprite
Used to render animations from spritesheets created from .png files directly.

<br>

---
### This inherits from
- Component (abstract)
    - Drawable (abstract)
        - [Sprite](/sprite.md)
            -  **AnimatedSprite**

<br>

---
###  Inherits from this
- None.

<br>

---
###  Construction
{% highlight csharp %}
AnimatedSprite(string name, Vector2 size, string pathToContent)
{% endhighlight %}
<br>| Parameter | Type | Description | 
| ---- | ---- | ----------- |
| name | string | Name of the component (used to identify it). |
| size | Vector2 | Size of a single sprite frame (without scaling). |
| pathToContent | string | Path to the .png file. |

<br>

---
###  Public Properties

<br>| CurrentAnimation | Animation | Currently active animation. |

<br>

---
###  Methods
{% highlight csharp %}
void AddAnimation(string name, int sheetRow, int animLen, int frameRate, Animation.LoopMode loopMode)
{% endhighlight %}
<br>| Parameter | Type | Description
| ---- | ---- | ----------- |
| name | string | Name of the animation. |
| sheetRow | int | The row of the animation in the sprite sheet. |
| animLen | int | The number of frames in the animation. | 
| frameRate | int | Number of frames per second. | 
| loopMode | Animation.LoopMode | Whether the animation loops or not. | 

<br>

{% highlight csharp %}
void PlayAnimation(string animName)
{% endhighlight %}
<br>| Parameter | Type | Description
| ---- | ---- | ----------- |
| animName | string | Name of the animation to be played. |

