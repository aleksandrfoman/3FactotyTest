using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
            if (layers[i].HaveSpace())
            {
                layers[i].AddItem(item);
                return;
            }
        }
        if (CanAddLayer())
        {
            layers.Add(new ItemsLayer(layersCount,rowCount));   
            AddItem(item);
        }
    }

    public Item GetItemFromType(ItemType itemType)
    {
        // for (int i = 0; i < layers; i++)
        // {
        //     
        // }
        return null;
    }
    
    public Item RemoveItem()
    {
        for (int i = layers.Count-1;i>=0; i--)
        {
            if (layers[i].HaveItems())
            {
                var item = layers[i].RemoveItem();
                if (!layers[i].HaveItems())
                {
                    layers.Remove(layers[i]);
                }
                return item;
            }
        }
        return null;
    }
    
    public bool HaveSpace()
    {
        for (int i = 0; i < layers.Count; i++)
        {
            if (layers[i].HaveSpace())
            {
                return true;
            }
        }
        return CanAddLayer();
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
    
    public bool HaveItems()
    {
        for (int i = 0; i < layers.Count; i++)
        {
            if (layers[i].HaveItems())
            {
                return true;
            }
        }
        return false;
    }
    private bool CanAddLayer()
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
            if (lines[i].HaveSpace())
            {
                lines[i].AddItem(item);
                return;;
            }
        }
        if (CanAddLine())
        {
            lines.Add(new ItemsLine(lineCount));   
            AddItem(item);
        }
    }
    
    public Item RemoveItem()
    {
        for (int i = lines.Count-1;i>=0; i--)
        {
            if (lines[i].HaveItems())
            {
                var item = lines[i].RemoveItem();
                if (!lines[i].HaveItems())
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
        // for (int i = 0; i < layers; i++)
        // {
        //     
        // }
        return null;
    }
    
    public bool HaveSpace()
    {
        for (int i = 0; i < lines.Count; i++)
        {
            if (lines[i].HaveSpace())
            {
                return true;
            }
        }
        return CanAddLine();
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
    
    public bool HaveItems()
    {
        for (int i = 0; i < lines.Count; i++)
        {
            if (lines[i].HaveItems())
            {
                return true;
            }
        }
        return false;
    }
    
    private bool CanAddLine()
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
       // if(items)
       // var item = items[items.Count - 1];
        return null;
    }
    
    public void AddItem(Item item)
    {
        if(item!=null)
        items.Add(item);
    }
    public bool HaveSpace()
    {
        return items.Count < count;
    }

    public bool HaveItems()
    {
        return items.Count > 0;
    }

    public int GetLastPos()
    {
        return items.Count - 1;
    }
}
