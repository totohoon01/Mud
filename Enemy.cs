using System.Numerics;
using System.Collections.Generic;
using System;

public class Enemy
{
  private string name;
  private Vector2 position;
  private Dictionary<string, int> enemyInfo = new Dictionary<string, int>(){
        {"Level", 1},
        {"Current_HP", 100},
        {"HP", 100},
        {"ATK", 10},
    };
  public Enemy()
  {
    Random rand = new Random();
    int level = rand.Next(1, 11);
    foreach (var item in enemyInfo)
    {
      if (item.Key == "Level")
      {
        enemyInfo[item.Key] = level;
      }
      else
      {
        enemyInfo[item.Key] = level * 2;
      }
    }

    position.X = rand.Next(-10, 11);
    position.Y = rand.Next(-10, 11);
  }

  public void Attack()
  {
    //attack
  }
  public void Die()
  {
    //파괴,
    //30초 있다가 다시 생성
  }
}