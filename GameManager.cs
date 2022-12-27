using System.Numerics;
using System.Collections.Generic;
using System;
using System.Threading;

public class GameManager
{
  public enum STATE
  {
    LOBBY,
    ADVENTURE,
    FIGHT,
    SHOP,
    EVENT,
  }

  private Player player;
  private Room room;
  private Vector2 roomSize;
  public STATE state;
  private bool isGetItem = false;
  private Enemy monster;

  public GameManager()
  {
    state = STATE.LOBBY;
    player = new Player();
    room = new Room();
    roomSize = room.RoomSize;
  }

  public void START()
  {
    while (true)
    {
      State_Statements(state);

      int action = Convert.ToInt32(Console.ReadLine());
      if (action == -1) break;

      State_Actions(state, action);
    }
  }

  private void State_Statements(STATE state)
  {
    if (state == STATE.LOBBY)
    {
      Console.WriteLine("던전으로 이동:0 보급소로 이동:1 [그만하기:-1]");
      Console.Write("어디로 갈까요: ");
    }

    else if (state == STATE.ADVENTURE)
    {
      Console.WriteLine("동:0 서:1 남:2 북:3 돌아가기:4 [그만하기:-1]");
      Console.Write("이동할 방향을 입력하세요: ");
    }
    else if (state == STATE.FIGHT)
    {
      Console.WriteLine("공격:0 도망(50%):1 [그만하기:-1]");
      Console.Write("행동을 선택하세요: ");
    }
    else if (state == STATE.SHOP)
    {
      Console.WriteLine("전투에 도움이 되는 효과를 드립니다.");
      Console.WriteLine("받는다:0 받지 않는다:1 [그만하기:-1]");
    }
    else if (state == STATE.EVENT)
    {
      Console.WriteLine("이벤트 발생");
    }
  }

  private void State_Actions(STATE state, int action)
  {
    if (state == STATE.LOBBY)
    {
      if (action == 0)
      {
        room = new Room();
        SET_STATE(STATE.ADVENTURE);
      }
      else if (action == 1)
      {
        SET_STATE(STATE.SHOP);
      }
    }
    else if (state == STATE.ADVENTURE)
    {
      if (action != 4)
      {
        player.Move(action, roomSize);
        monster = room.CheckEncounter(player.position);
        if (monster != null)
        {
          SET_STATE(STATE.FIGHT);
        }
      }
      else
      {
        isGetItem = false;
        player.position = new Vector2(0, 0);
        player.SetStatus("ATK", player.userInfo["Level"] * 10);
        SET_STATE(STATE.LOBBY);
      }
    }

    else if (state == STATE.FIGHT)
    {
      if (action == 0)
      {
        monster.Attacked(player.userInfo["ATK"]);
        bool isDie = monster.CheckCondition();
        if (isDie)
        {
          monster.Die();
          player.LevelUP();
          SET_STATE(STATE.ADVENTURE);
        }
        else
        {
          player.Attacked(monster.enemyInfo["ATK"]);
        }
        isDie = player.CheckCondition();
        if (isDie)
        {
          player.Die();
          SET_STATE(STATE.LOBBY);
        }
      }
      else if (action == 1)
      {
        Random rnd = new Random();
        int dice = rnd.Next(0, 2);
        if (dice == 0)
        {
          Console.WriteLine("무사히 도망쳤다.");
          player.position = new Vector2(0, 0);
          SET_STATE(STATE.LOBBY);
        }
        else
        {
          Console.WriteLine("도망에 실패했다");
          player.Attacked(monster.enemyInfo["ATK"]);
          bool isDie = player.CheckCondition();
          if (isDie)
          {
            player.Die();
            SET_STATE(STATE.LOBBY);
          }
        }
      }
    }
    else if (state == STATE.SHOP)
    {
      if (action == 0)
      {
        if (!isGetItem)
        {
          Random rnd = new Random();
          Item item = new Item(rnd.Next(0, 2));
          if (item.itemType == 0)
          {
            Console.WriteLine("체력을 회복했다!");
            player.userInfo["CURRENT_HP"] += player.userInfo["HP"] / 2;
            if (player.userInfo["CURRENT_HP"] > player.userInfo["HP"])
            {
              player.userInfo["CURRENT_HP"] = player.userInfo["HP"];
            }
          }
          else if (item.itemType == 1)
          {
            Console.WriteLine("공격력이 상승했다!");
            player.userInfo["ATK"] += rnd.Next(1, 11);
          }
          isGetItem = true;
        }
        else
        {
          Console.WriteLine("다음 아이템을 받으려면 던전을 진행해 주세요.");
        }
      }
      else if (action == 1)
      {
        SET_STATE(STATE.LOBBY);
      }
      else if (action == 2)
      {
        player.userInfo["ATK"] += 10000;
      }
      player.Description();
      SET_STATE(STATE.LOBBY);
    }

    else if (state == STATE.EVENT)
    {
      SET_STATE(STATE.ADVENTURE);
    }
  }
  public void SET_STATE(STATE _state)
  {
    state = _state;
    Console.WriteLine("계속하려면 Enter...");
    Console.Read();
    Console.Clear();
  }
}