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
<br>| Parameter | Type | Description
| ---- | ---- | ----------- |
| name | string | Name of the component (used to identify it). |
| size | Vector2 | Size of the sprite in vectors (without scaling). |
| pathToContent | string | Path to the .png file within the "Content" folder (changeable). |

<br>

---
###  Public Properties
Properties that can be accessed publicly.

<br>| Property | Type | Description
| ---- | ---- | ----------- |
| Name | string | Name of the component (used to identify it). |

<br>

---
###  Methods
Usable methods.
