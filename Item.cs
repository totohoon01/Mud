using System;

public class Item
{
  private int itemType;
  private int price;

  public Item()
  {
    Console.Write("Create Item");
  }
  public void Description(int itemType)
  {
    Console.WriteLine("아이템 설명");
  }
}