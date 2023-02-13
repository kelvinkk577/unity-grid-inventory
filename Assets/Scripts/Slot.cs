[System.Serializable]
public class Slot
{
  public bool occupied;
  public Slot mainSlot;

  public Slot()
  {
    this.occupied = false;
    this.mainSlot = null;
  }
}
