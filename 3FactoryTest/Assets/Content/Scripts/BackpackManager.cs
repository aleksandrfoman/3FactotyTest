using DG.Tweening;
using UnityEngine;

namespace Content.Scripts
{
    public class BackpackManager : MonoBehaviour
    {
        [SerializeField] 
        private ItemsTower itemsTower;
        [SerializeField] 
        private Transform startPos;
        [SerializeField] 
        private Vector3Int size;
        [SerializeField] 
        private float durationTime;
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
            curItem.transform.DOLocalMove(lastPos* itemDrop.Scale,durationTime).SetEase(Ease.Linear);
        }

        public Item GetItemFromType(ItemType itemType) => itemsTower.GetItemFromType(itemType);
        public Item RemoveItem() => itemsTower.RemoveItem();
        public bool HaveItems() => itemsTower.IsHaveItems();
        public bool HaveSpace() => itemsTower.IsHaveSpace();
    }
}
