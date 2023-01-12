# SRH Toolkit
This is a collection of random utility classes/scripts I have made over the years I have used Unity.

I don't know how often I will be adding to this, but I will try to add any general purpose scripts I make to this.

# Singleton Usage
This just shows you how to use the singleton pattern that [TaroDev](https://www.youtube.com/@Tarodev) made. This is really useful if you want to use a singleton!
```` C#
  using SRH.Toolkit

  // A Normal Singleton
  public class GameManager : Singleton<GameManager>
  {
      public void Start()
      {
          // do game manager stuff
      }
  }

  // A Singleton that will survive scene loads. (DontDestoryOnLoad)
  public class GameManager : SingletonPersistent<GameManager>
  {
      public void Start()
      {
          // do game manager stuff
      }
  }
````

# Scripts
## Core
- [AnimationManager](https://github.com/SlushyRH/SRH-Toolkit/blob/master/Toolkit/Core/AnimationManager.cs) - This helps you manage your animations on an Animator in C#.
- [Extensions](https://github.com/SlushyRH/SRH-Toolkit/blob/master/Toolkit/Core/Extensions.cs) - A bunch of extension methods on game objects.
- [MathRH](https://github.com/SlushyRH/SRH-Toolkit/blob/master/Toolkit/Core/MathRH.cs) - Some random Math related functions.
- [Singleton](https://github.com/SlushyRH/SRH-Toolkit/blob/master/Toolkit/Core/Singleton.cs) - A useful singleton abstract class which allows you to have singletons with just one abstract class.
- [ZipArchiver](https://github.com/SlushyRH/SRH-Toolkit/blob/master/Toolkit/Core/ZipArchiver.cs) - Allows you to extract or compress ZIP files in runtime or in the editor.
## Effects
- [MouseParallaxEffect](https://github.com/SlushyRH/SRH-Toolkit/blob/master/Toolkit/Effects/MouseParallaxEffect.cs) - Just another Parallax Mouse Effect. A simple but useful effect.
- [TypeWriterEffect](https://github.com/SlushyRH/SRH-Toolkit/blob/master/Toolkit/Effects/TypeWriterEffect.cs) - Just a Typing Effect that can be used on either Text or Text Mesh Pro.