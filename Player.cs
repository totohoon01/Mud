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
            if (item.Key != "Class")
            {
                userInfo[item.Key] = item.Value * 2;
            }
        }
    }
}