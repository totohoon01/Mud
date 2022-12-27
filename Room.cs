using System.Numerics;
using System;
using System.Collections.Generic;

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
  public List<Enemy> monsters = new List<Enemy>();
  public Room()
  {
    roomSize = new Vector2(21, 21);
    for (int i = 0; i < 1; i++)
    {
      monsters.Add(new Enemy());
    }
    Console.WriteLine(monsters[0].position);
  }
  public Enemy? CheckEncounter(Vector2 pos)
  {
    foreach (var monster in monsters)
    {
      if (monster.position.X == pos.X && monster.position.Y == pos.Y)
      {
        Console.WriteLine("몬스터와 마주쳤다!!!!");
        monster.Description();
        return monster;
      }
    }
    Console.WriteLine("아무일도 일어나지 않았다.");
    return null;
  }
}