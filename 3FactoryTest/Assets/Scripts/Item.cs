using UnityEngine;

public enum ItemType
{
    Item1,
    Item2,
    Item3
}
public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemType itemType;
    public ItemType ItemType => itemType;
    public float Scale => scale;
    [SerializeField]
    private float scale;


}
