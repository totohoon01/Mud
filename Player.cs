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
  private string? name;

  public Dictionary<string, int> userInfo = new Dictionary<string, int>(){
        {"Class", (int)userClass.WARRIOR},
        {"Level", 1},
        {"CURRENT_HP", 100},
        {"HP", 100},
        {"ATK", 10},
    };
  public Vector2 position = new Vector2(0, 0);
  public Player()
  {
    Console.Write("당신의 이름은? ");
    name = Console.ReadLine();
    Console.WriteLine($"환영합니다! {name}");
  }

  public void LevelUP()
  {
    Console.WriteLine("Level UP!!");
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

  public void Move(int direction, Vector2 roomSize)
  {
    int halfX = (int)Math.Floor(roomSize.X / 2);
    int halfY = (int)Math.Floor(roomSize.Y / 2);

    switch (direction)
    {
      case 0:
        if (position.X < halfX)
        {
          position.X++;
        }
        else
        {
          Console.WriteLine("동쪽 끝에 도달했습니다.");
        }
        break;
      case 1:
        if (position.X > -halfX)
        {
          position.X--;
        }
        else
        {
          Console.WriteLine("서쪽 끝에 도달했습니다.");
        }
        break;
      case 2:
        if (position.Y > -halfY)
        {
          position.Y--;
        }
        else
        {
          Console.WriteLine("남쪽 끝에 도달했습니다.");
        }
        break;
      case 3:
        if (position.Y < halfX)
        {
          position.Y++;
        }
        else
        {
          Console.WriteLine("남쪽 끝에 도달했습니다.");
        }
        break;
      default:
        Console.WriteLine("유효하지 않은 입력입니다.");
        break;
    }
    Console.WriteLine($"현재 위치: ({position.X}, {position.Y})");
  }
  public void Attacked(int atk)
  {
    userInfo["CURRENT_HP"] -= atk;
    Console.Write($"몬스터에게 {atk}의 데미지를 받았다. ");
    if (userInfo["CURRENT_HP"] > 0)
    {
      Console.WriteLine($"Player HP:{userInfo["CURRENT_HP"]}");
    }
    else
    {
      Console.WriteLine("눈 앞이 깜깜해졌다.");
    }
  }
  public bool CheckCondition()
  {
    if (userInfo["CURRENT_HP"] < 0)
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
    //사망 이벤트
    userInfo["CURRENT_HP"] = userInfo["HP"];
    position = new Vector2(0, 0);
  }
  public void SetStatus(string key, int value)
  {
    userInfo[key] = value;
  }
  public void Description()
  {
    Console.WriteLine("********************");
    Console.WriteLine($"Name: {name}");
    foreach (var item in userInfo)
    {
      if (item.Key == "Class")
      {
        Console.WriteLine($"{item.Key}: {(userClass)item.Value}");
      }
      else
      {
        Console.WriteLine($"{item.Key}: {item.Value}");
      }
    }
    Console.WriteLine("********************");
  }
}