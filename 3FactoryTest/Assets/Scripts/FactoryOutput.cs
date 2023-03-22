using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class FactoryOutput : MonoBehaviour
{
    [SerializeField]
    private Factory factory;
    [SerializeField] 
    private OutputTrigger outputTrigger;
    [SerializeField]
    private Item itemDrop;
    [SerializeField] 
    private ItemsTower itemsTower;
    [SerializeField] 
    private Transform startPos;
    [SerializeField] 
    private Transform factoryPos;
    [SerializeField] 
    private Vector3Int size;
    [SerializeField] 
    private float durationTime;
    
    private void Awake()
    {
        factory.OnTick.AddListener(OnFactoryTick);
        outputTrigger.OnTrigger.AddListener(GetItem);
        itemsTower = new ItemsTower(size.x, size.z,size.y);
    }
    private void OnFactoryTick()
    {
        if (itemsTower.IsHaveSpace())
        {
            var curItem = Instantiate(itemDrop);
            itemsTower.AddItem(curItem);
            curItem.transform.parent = startPos;
            var lastPos = itemsTower.GetLastPos();
            curItem.transform.position = factoryPos.position;
            curItem.transform.DOLocalMove(lastPos* itemDrop.Scale,durationTime).SetEase(Ease.Linear);
        }
    }

    private void GetItem(Player player)
    {
        if (itemsTower.IsHaveItems() && player.HaveSpace())
        {
            var item = itemsTower.RemoveItem();
            player.SetItem(item);
        }   
    }

    public bool IsHaveSpace() => itemsTower.IsHaveSpace();
}
