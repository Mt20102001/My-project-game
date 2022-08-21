using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public class Slot
    {
        public Item item;
        public int position;
    }
    public List<Slot> slots = new List<Slot>();
    public List<Item> items = new List<Item>();

    public void AddItem(Item item)
    {
        foreach (var i in items)
        {
            if (i.blueprint == item.blueprint && i.curStack < i.blueprint.maxStack)
            {
                int maxAdd = i.blueprint.maxStack - i.curStack;

                int min = Mathf.Min(item.curStack, maxAdd);

                item.curStack -= min;

                i.curStack += min;
            }
            if (i.curStack <= 0)
                break;
        }

        if (item.curStack > 0)
        {
            items.Add(item);
        }
    }

    public void Print()
    {
        Debug.Log($"Has {items.Count} item(s) in inventory");
        foreach (var item in items)
        {
            Debug.Log($"Item: {item.blueprint.baseName} {item.customName} x{item.curStack}");
        }
    }
}

public class Item
{
    public ItemBlueprint blueprint;
    public int curStack;
    public string customName;

    public int positionInInventory;
}

public class ItemBlueprint
{
    public string baseName;
    public int typeId;
    public int maxStack;
    public bool stackable;
}