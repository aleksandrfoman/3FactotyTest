using System;
using DG.Tweening;
using UnityEngine;

public class BackpackManager : MonoBehaviour
{
    [SerializeField] 
    private ItemsTower itemsTower;
    [SerializeField] 
    private Transform startPos;
    [SerializeField] 
    private Vector3Int size;
    private void Awake()
    {
        itemsTower = new ItemsTower(size.x, size.z,size.y);
    }

    public void AddItem(Item itemDrop)
    {
        var curItem = itemDrop;
        itemsTower.AddItem(curItem);
        curItem.transform.parent = startPos;
        var lastPos = itemsTower.GetLastPos();
        curItem.transform.DOLocalMove(lastPos* itemDrop.Scale,0.2f).SetEase(Ease.Linear);
    }

    public Item RemoveItem() => itemsTower.RemoveItem();
    public bool HaveItems() => itemsTower.HaveItems();
    public bool HaveSpace() => itemsTower.HaveSpace();
}
