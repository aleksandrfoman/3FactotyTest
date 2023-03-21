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
    private ItemType[] itemType;
    
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
            curItem.transform.parent = factoryPos;
            curItem.transform.DOLocalMove(factoryPos.position* curItem.Scale,0.2f).SetEase(Ease.Linear);
            Destroy(curItem.gameObject,0.2f);
            return true;
        }
        return false;
    }
    
    private void GetItem(Player player)
    {
        if (itemsTower.HaveSpace() && player.HaveItems())
        {
            var curItem = player.GetItem();
            itemsTower.AddItem(curItem);
            curItem.transform.parent = startPos;
            var lastPos = itemsTower.GetLastPos();
            curItem.transform.DOLocalMove(lastPos* curItem.Scale,0.2f).SetEase(Ease.Linear);
        }   
    }
}
