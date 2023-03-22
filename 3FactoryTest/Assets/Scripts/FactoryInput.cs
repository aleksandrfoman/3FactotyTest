using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FactoryInput : MonoBehaviour
{
    [SerializeField] 
    private InputTrigger inputTrigger;
    [SerializeField] 
    private ItemsTower itemsTower;
    [SerializeField] 
    private Transform startPos;
    [SerializeField] 
    private Transform factoryPos;
    [SerializeField] 
    private Vector3Int size;
    [SerializeField] 
    private ItemType itemType;
    [SerializeField] 
    private float durationTime;
    private void Awake()
    {
        itemsTower = new ItemsTower(size.x, size.z,size.y);
        inputTrigger.OnTrigger.AddListener(GetItem);
    }

    public bool IsTakeFactroy()
    {
        if (itemsTower.HaveItems())
        {
            var curItem = itemsTower.RemoveItem();
            curItem.transform.parent = null;
            curItem.transform.DOLocalMove( factoryPos.position,durationTime).SetEase(Ease.Linear);
            Destroy(curItem.gameObject,durationTime);
            return true;
        }
        return false;
    }

    public bool IsFactoryHaveItems() => itemsTower.HaveItems();
    
    private void GetItem(Player player)
    {
        if (itemsTower.HaveSpace() && player.HaveItems())
        {
            var curItem = player.GetItemFromType(itemType);
            if (curItem != null)
            {
                itemsTower.AddItem(curItem);
                curItem.transform.parent = startPos;
                var lastPos = itemsTower.GetLastPos();
                curItem.transform.DOLocalMove(lastPos * curItem.Scale, durationTime).SetEase(Ease.Linear);
            }
        }
    }
}
