using System.Collections.Generic;
using UnityEngine;

namespace Content.Scripts
{
    public class ItemsTower
    {
        private int layersCount;
        private int rowCount;
        private int columnCount;
        private List<ItemsLayer> layers = new List<ItemsLayer>(10);
    
        public ItemsTower(int layersCount,int rowCount, int columnCount)
        {
            this.layersCount = layersCount;
            this.rowCount = rowCount;
            this.columnCount = columnCount;
        }
    
        public void AddItem(Item item)
        {
            for (int i = 0; i < layers.Count; i++)
            {
                if (layers[i].IsHaveSpace())
                {
                    layers[i].AddItem(item);
                    return;
                }
            }
            if (IsCanAddLayer())
            {
                layers.Add(new ItemsLayer(layersCount,rowCount));   
                AddItem(item);
            }
        }

        public Item GetItemFromType(ItemType itemType)
        {
            for (int i = layers.Count-1;i>=0; i--)
            {
                if (layers[i].IsHaveItems())
                {
                    var item = layers[i].GetItemFromType(itemType);
                    if (!layers[i].IsHaveItems())
                    {
                        layers.Remove(layers[i]);
                    }
                    return item;
                }
            }
            return null;
        }
    
        public Item RemoveItem()
        {
            for (int i = layers.Count-1;i>=0; i--)
            {
                if (layers[i].IsHaveItems())
                {
                    var item = layers[i].RemoveItem();
                    if (!layers[i].IsHaveItems())
                    {
                        layers.Remove(layers[i]);
                    }
                    return item;
                }
            }
            return null;
        }
    
        public bool IsHaveSpace()
        {
            for (int i = 0; i < layers.Count; i++)
            {
                if (layers[i].IsHaveSpace())
                {
                    return true;
                }
            }
            return IsCanAddLayer();
        }

        public Vector3 GetLastPos()
        {
            if (layers.Count == 0)
            {
                return  Vector2.zero;
            }
            else
            {
                var vec2 = layers[layers.Count - 1].GetLastPos();
                var y = layers.Count - 1;
                return new Vector3(vec2.x, y, vec2.y);
            }

        }

        public bool IsHaveItems()
        {
            for (int i = 0; i < layers.Count; i++)
            {
                if (layers[i].IsHaveItems())
                {
                    return true;
                }
            }
            return false;
        }
        private bool IsCanAddLayer()
        {
            return layers.Count < columnCount;
        }
    }
    public class ItemsLayer
    {
        private int lineCount;
        private int rowCount;
        private List<ItemsLine> lines = new List<ItemsLine>(10);

        public ItemsLayer(int lineCount, int rowCount)
        {
            this.lineCount = lineCount;
            this.rowCount = rowCount;
        }
    
        public void AddItem(Item item)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].IsHaveSpace())
                {
                    lines[i].AddItem(item);
                    return;;
                }
            }
            if (IsCanAddLine())
            {
                lines.Add(new ItemsLine(lineCount));   
                AddItem(item);
            }
        }
    
        public Item RemoveItem()
        {
            for (int i = lines.Count-1;i>=0; i--)
            {
                if (lines[i].IsHaveItems())
                {
                    var item = lines[i].RemoveItem();
                    if (!lines[i].IsHaveItems())
                    {
                        lines.Remove(lines[i]);
                    }
                    return item;
                }
            }
        
            return null;
        }
    
        public Item GetItemFromType(ItemType itemType)
        {
            for (int i = lines.Count-1;i>=0; i--)
            {
                if (lines[i].IsHaveItems())
                {
                    var item = lines[i].GetItemFromType(itemType);
                    if (!lines[i].IsHaveItems())
                    {
                        lines.Remove(lines[i]);
                    }
                    return item;
                }
            }
            return null;
        }
    
        public bool IsHaveSpace()
        {
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].IsHaveSpace())
                {
                    return true;
                }
            }
            return IsCanAddLine();
        }

        public Vector2 GetLastPos()
        {
            if (lines.Count == 0)
            {
                return  Vector2.zero;
            }
            else
            {
                var x = lines[lines.Count - 1].GetLastPos();
                var y = lines.Count - 1;
                return new Vector2(x, y);
            }
        }
        public bool IsHaveItems()
        {
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].IsHaveItems())
                {
                    return true;
                }
            }
            return false;
        }
    
        private bool IsCanAddLine()
        {
            return lines.Count < rowCount;
        }
    }
    public class ItemsLine
    {
        private int count;
        private List<Item> items = new List<Item>(10);

        public ItemsLine(int count)
        {
            this.count = count;
        }
        public Item RemoveItem()
        {
            var item = items[items.Count - 1];
            items.RemoveAt(items.Count-1);
            return item;
        }
    
        public Item GetItemFromType(ItemType itemType)
        {
            if (items.Find(x => x.ItemType == itemType) != null)
            {
                var item = items.Find(x => x.ItemType == itemType);
                items.Remove(item);
                return item;
            }
            else
            {
                return null;
            }
        }
    
        public void AddItem(Item item)
        {
            if(item!=null)
                items.Add(item);
        }
        public bool IsHaveSpace()
        {
            return items.Count < count;
        }

        public bool IsHaveItems()
        {
            return items.Count > 0;
        }
    
        public int GetLastPos()
        {
            return items.Count - 1;
        }
    }
}