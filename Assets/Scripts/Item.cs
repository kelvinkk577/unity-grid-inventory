using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class Item : ScriptableObject
{
  public int id;
  public string itemName;
  public string description;
  public int maxStackSize = 1;
  public int xSize;
  public int ySize;
  public Sprite icon;
  public GameObject prefab;
}

// Hardcoded Item ID
// Make sure the IDs match the values of mapping in ItemIDMapping.cs
public static class ItemID
{
  public const int Armour = 0;
  public const int Sword = 1;
  public const int Meat = 2;
  public const int Apple = 3;
  public const int Pickaxe = 4;
  public const int Hatchet = 5;
}
