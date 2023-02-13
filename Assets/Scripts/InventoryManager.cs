using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
  [SerializeField]
  private Inventory inventory;

  void Start()
  {
    inventory.Init();
  }
}
