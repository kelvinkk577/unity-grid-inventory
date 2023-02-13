using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Single Source of Truth for Item ID
public class ItemIDMapping : MonoBehaviour
{
  [SerializeField]
  private SerializableDictionary<string, int> mapping = new SerializableDictionary<string, int>();

  // This must be called ahead of other scripts that make use of the Item System
  // This make sures the id of all Items scriptable objects are the same as the mapping in ItemIDMapping.cs
  public void SyncItemId()
  {
    var itemArray = Resources.LoadAll<Item>("Items");
    foreach (Item item in itemArray)
    {
      if (!mapping.ContainsKey(item.itemName))
      {
        Debug.LogError("Assign ID for " + item.itemName + " in ItemIDMapping.cs");
        continue;
      }

      item.id = mapping[item.itemName];
    }
  }

  void Awake()
  {
    SyncItemId();
  }
}
