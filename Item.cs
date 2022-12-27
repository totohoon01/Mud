using System;

public class Item
{
  public int itemType;
  public Item(int _itemType)
  {
    itemType = _itemType;
  }
  public void Description(int itemType)
  {
    if (itemType == 0)
    {
      Console.Write("체력 포션: 체력을 50% 회복한다.");
    }
    else if (itemType == 1)
    {
      Console.Write("공격력 증가 물약: 다음 전투에서 공격력을 1 ~ 10 증가시킨다.");
    }
  }
}