using System.Collections.Generic;
using System;

public class GameManager
{
    enum TTT
    {
        AAA
    }

    private Player player;
    private NPC npc;
    private Enemy enemy;
    public GameManager()
    {
        player = new Player();
        // npc = new NPC();
        // enemy = new Enemy();
        // player.UserInfo;
    }

    public void START()
    {
        Dictionary<string, int> dict = player.UserInfo;
        Console.WriteLine("START GAME");
    }
}