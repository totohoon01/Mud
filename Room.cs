using System.Numerics;
using System;

public class Room
{
  private Vector2 roomSize;
  public Vector2 RoomSize
  {
    get
    {
      return roomSize;
    }
  }

  public Room()
  {
    roomSize = new Vector2(21, 21);
  }
}