---

title: Sprite
date: 2024-01-24
author: charya-s
categories: classes graphics
permalink: /graphics/Sprite/

---


{% include navbar.html %}

# Sprite
Used to render textures from .png files directly.

<br>

---
### This inherits from
- Component (abstract)
    - Drawable (abstract)
        - **Sprite**

<br>

---
###  Inherits from this
- AnimatedSprite

<br>

---
###  Construction
{% highlight csharp %}
Sprite(string name, Vector2 size, string pathToContent)
{% endhighlight %}
<br>| Parameter | Type | Description | 
| ---- | ---- | ----------- |
| name | string | Name of the component (used to identify it). |
| size | Vector2 | Size of the sprite (without scaling). |
| pathToContent | string | Path to the .png file. |

<br>

---
###  Public Properties

<br>| Size | Vector2 | Size of the sprite (without scaling). |
| ScaledSize | Vector2 | Size of the sprite as drawn (after scaling). |
| Tint | Color | Color of the texture drawn. |
| Origin | Vector2 | The origin of the texture relative to its scaled size. |
| VisibleBox | bool | Whether the bounds of the texture are shown when drawn. |

<br>

---
###  Methods
{% highlight csharp %}
void FlipH(int dir)
{% endhighlight %}
<br>| Parameter | Type | Description
| ---- | ---- | ----------- |
| dir | int | -1 to flip to left, +1 to flip to right. |
