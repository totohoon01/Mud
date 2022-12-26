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
  private NPC npc;
  private Enemy enemy;
  private Room room;
  private Vector2 roomSize;
  public STATE state;

  public GameManager()
  {
    state = STATE.LOBBY;
    player = new Player();
    room = new Room();
    roomSize = room.RoomSize;
    // npc = new NPC();
    // enemy = new Enemy();
    // player.UserInfo;
  }

  public void START()
  {
    while (true)
    {
      State_Statements(state);

      //STATE ACTION
      int action = Convert.ToInt32(Console.ReadLine());
      if (action == -1) break;

      State_Actions(state, action);

      //Delay
      Console.WriteLine("");
      Console.WriteLine("계속하려면 Enter...");
      Console.Read();
      Console.Clear();
    }
  }

  private void State_Statements(STATE state)
  {
    if (state == STATE.LOBBY)
    {
      Console.WriteLine("던전으로 이동:0 상점으로 이동:1 [그만하기:-1]");
      Console.Write("어디로 갈까요: ");
    }

    else if (state == STATE.ADVENTURE)
    {
      Console.WriteLine("동:0 서:1 남:2 북:3 돌아가기:4 [그만하기:-1]");
      Console.Write("이동할 방향을 입력하세요: ");
    }
    else if (state == STATE.FIGHT)
    {
      Console.WriteLine("공격:0 아이템 사용:1 도망(50%):2 [그만하기:-1]");
      Console.Write("행동을 선택하세요: ");
    }
    else if (state == STATE.SHOP)
    {
      Console.WriteLine("구매하기:0 나가기:1 [그만하기:-1]");
      Console.Write("무엇을 할까요: ");
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
        //bool isMeet = enemy.check(player.position);
        //if(isMeet) SET_STATE(STATE.FIGHT);

        //bool isEVENT = event.check(player.position);
        //if(isMeet) SET_STATE(STATE.EVENT)
      }
      else
      {
        SET_STATE(STATE.LOBBY);
      }
      //현재 위치에 무엇이 있는지 체크
      //이벤트가 있다면 해당 스테이트로 이동
    }

    else if (state == STATE.FIGHT)
    {
      //전투 스테이트
      //플레이어 입력 -> 공격 / 도망 / 아이템 사용
      //몬스터 입력 -> 공격
      //승리시 -> 경험치 상승, 다시 어드벤쳐로
      //패배시 -> 이벤트, 로비로 이동
    }
    else if (state == STATE.SHOP)
    {
      //상점 스테이트
      //플레이어 입력 -> (구매, 아이템, 개수), 나가기
      //소지금이 충분하면 추가
    }
    else if (state == STATE.EVENT)
    {
      //아이템 획득 / 함정 같은 이벤트
      //DoSomething();
      SET_STATE(STATE.ADVENTURE);
    }
  }
  public void SET_STATE(STATE _state)
  {
    state = _state;
  }
}