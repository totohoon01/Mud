using System.Numerics;
using System.Collections.Generic;
using System;

public class GameManager
{
  public enum STATE
  {
    LOBBY,
    ADVENTURE,
    FIGHT,
    SHOP,
  }

  private Player player;
  private NPC npc;
  private Enemy enemy;
  private Room room;
  public STATE state;


  public GameManager()
  {
    state = STATE.ADVENTURE;
    player = new Player();
    room = new Room();
    // npc = new NPC();
    // enemy = new Enemy();
    // player.UserInfo;
  }

  public void START()
  {
    while (true)
    {
      Console.Clear();
      if (state == STATE.LOBBY)
      {
        Console.WriteLine("광장 / ");
      }
      else if (state == STATE.ADVENTURE)
      {
        Console.WriteLine("동:0 서:1 남:2 북:3 [그만하기:-1]");
        Console.Write("이동할 방향을 입력하세요: ");
        int dir = Convert.ToInt32(Console.ReadLine());
        if (dir == -1) break;

        Vector2 pos = player.Position;
        //TODO: 조건 확인
        if (((dir == 0 || dir == 1) && Math.Abs(pos.X) < 10) && ((dir == 2 || dir == 3) && Math.Abs(pos.Y) < 10))
        {
          player.Move(dir);
        }
      }
      else if (state == STATE.FIGHT)
      {

      }
      else if (state == STATE.SHOP)
      {

      }
      Console.WriteLine("");
      Console.Write("계속하려면 Enter...");
      Console.ReadLine();
    }
  }
}