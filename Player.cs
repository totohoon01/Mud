using System.Text.RegularExpressions;
using System.Numerics;
using System.Collections.Generic;
using System;

public class Player
{
  private enum userClass
  {
    WARRIOR,
    MAGE,
  }
  private string name;

  private Dictionary<string, int> userInfo = new Dictionary<string, int>(){
        {"Class", (int)userClass.WARRIOR},
        {"Level", 1},
        {"CURRENT_HP", 100},
        {"HP", 100},
        {"ATK", 10},
    };
  public Dictionary<string, int> UserInfo
  {
    get
    {
      Console.WriteLine("******************");
      Console.WriteLine($"Name : {name}");
      foreach (var item in userInfo)
      {
        if (item.Key == "Class")
        {
          Console.WriteLine($"{item.Key} : {(userClass)item.Value}");
        }
        else
        {
          Console.WriteLine($"{item.Key} : {item.Value}");
        }
      }
      Console.WriteLine("******************");
      return userInfo;
    }
  }
  private Vector2 position = new Vector2(0, 0);
  public Vector2 Position
  {
    get
    {
      return position;
    }
  }

  public Player()
  {
    Console.Write("당신의 이름은? ");
    name = Console.ReadLine();
    Console.WriteLine($"환영합니다! {name}");
  }

  private void LevelUP()
  {
    foreach (var item in userInfo)
    {
      if (item.Key != "Class" && item.Key != "Level")
      {
        userInfo[item.Key] = item.Value * 2;
      }
    }
    userInfo["Level"]++;
    userInfo["CURRENT_HP"] = userInfo["HP"];
  }

  public void Move(int direction)
  {
    switch (direction)
    {
      case 0:
        position.X++;
        break;
      case 1:
        position.X--;
        break;
      case 2:
        position.Y--;
        break;
      case 3:
        position.Y++;
        break;
      default:
        Console.WriteLine("유효하지 않은 입력입니다.");
        break;
    }
    Console.WriteLine($"현재 위치: ({position.X}, {position.Y})");
  }
}