using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
  public static ItemDatabase Instance { get; private set; }

  [SerializeField]
  private SerializableSortedDictionary<int, Item> items = new SerializableSortedDictionary<int, Item>();

  void Awake()
  {
    if (Instance != null && Instance != this)
      Destroy(this);
    else
      Instance = this;

    var itemArray = Resources.LoadAll<Item>("Items");

    foreach (var item in itemArray)
    {
      if (!items.ContainsKey(item.id))
        items.Add(item.id, item);
    }
  }

  public Item GetItem(int id)
  {
    return items[id];
  }

  public void AddItem(Item item)
  {
    items.Add(item.id, item);
  }
}
