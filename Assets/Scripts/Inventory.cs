using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory")]
public class Inventory : ScriptableObject
{
  public int xSize;
  public int ySize;
  public Slot[,] inventory;

  public void Init()
  {
    inventory = new Slot[xSize, ySize];
    for (int i = 0; i < ySize; i++)
    {
      for (int j = 0; j < xSize; j++)
      {
        inventory[j, i] = new Slot();
      }
    }

    RunTest();
    PrintMatrix();
  }

  public (int, int) FindFreeSlots(int xSize, int ySize)
  {
    bool found = false;
    int currX, currY;
    currX = currY = 0;
    while (!found)
    {
      (currX, currY) = FindNextUnoccupiedSlot(currX, currY); // currX and currY should be increment, else infinite loop if unoccupied slot is found but not enough space for item
      if ((currX, currY) == (-1, -1))
        return (-1, -1);

      if (HasSpace(currX, currY, xSize, ySize))
      {
        return (currX, currY);
      }
    }

    return (-1, -1); // delete
  }

  private bool HasSpace(int currX, int currY, int xSize, int ySize)
  {
    for (int i = 0; i < ySize; i++)
    {
      for (int j = 0; j < xSize; j++)
      {
        if (inventory[currX + j, currY + i].occupied)
          return false;
      }
    }
    return true;
  }

  private (int, int) FindNextUnoccupiedSlot(int currX, int currY)
  {
    for (int y = currY; y < ySize; y++)
    {
      for (int x = currX; x < xSize; x++)
      {
        if (!inventory[x, y].occupied)
          return (x, y);
      }
    }
    return (-1, -1);
  }
  private void RunTest() // Run unit test of each newly created function
  {
    inventory[0, 0].occupied = true;
    inventory[1, 0].occupied = true;
    inventory[0, 1].occupied = true;
    inventory[1, 1].occupied = true;
  }

  private void PrintMatrix()
  {
    string output = "";
    for (int i = 0; i < ySize; i++)
    {
      for (int j = 0; j < xSize; j++)
      {
        output = inventory[j, i].occupied ? string.Concat(output, "1\t") : string.Concat(output, "o\t");
      }
      output = string.Concat(output, "\n");
    }
    Debug.Log(output);
  }
}
