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