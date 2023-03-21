using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private BackpackManager backpackManager;

    public void SetItem(Item item)
    {
        if(item!=null)
        backpackManager.AddItem(item);
    }

    public Item GetItem() => backpackManager.RemoveItem();
    public bool HaveSpace() => backpackManager.HaveSpace();

    public bool HaveItems() => backpackManager.HaveItems();
}
