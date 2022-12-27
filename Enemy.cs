using System.Numerics;
using System.Collections.Generic;
using System;

public class Enemy
{
  private string? name;
  public Vector2 position = new Vector2(0, 0);
  public Dictionary<string, int> enemyInfo = new Dictionary<string, int>(){
        {"Level", 1},
        {"CURRENT_HP", 100},
        {"HP", 100},
        {"ATK", 10},
    };

  public Enemy()
  {
    Random rand = new Random();
    int level = rand.Next(1, 11);

    if (level < 3)
    {
      name = "갈색 곰";
    }
    else if (level < 7)
    {
      name = "흉포한 갈색 곰";
    }
    else
    {
      name = "곰";
    }

    foreach (var item in enemyInfo)
    {
      if (item.Key == "Level")
      {
        enemyInfo[item.Key] = level;
      }
      else
      {
        enemyInfo[item.Key] = enemyInfo[item.Key] * level;
      }
    }
    position.X = 0;
    position.Y = 1;

    // position.X = rand.Next(-10, 11);
    // position.Y = rand.Next(-10, 11);
  }
  public void Description()
  {
    Console.WriteLine("********************");
    Console.WriteLine($"Name: {name}");
    foreach (var item in enemyInfo)
    {
      Console.WriteLine($"{item.Key}: {item.Value}");
    }
    Console.WriteLine("********************");
  }
  public void Attacked(int atk)
  {
    enemyInfo["CURRENT_HP"] -= atk;
    if (enemyInfo["CURRENT_HP"] > 0)
    {
      Console.WriteLine($"몬스터에게 {atk}의 데미지를 주었다. Monster HP:{enemyInfo["CURRENT_HP"]}");
    }
    else
    {
      Console.WriteLine("몬스터를 쓰러트렸다.");
    }
  }
  public bool CheckCondition()
  {
    if (enemyInfo["CURRENT_HP"] < 0)
    {
      return true;
    }
    else
    {
      return false;
    }

  }
  public void Die()
  {
    //클래스 삭제.
  }
}