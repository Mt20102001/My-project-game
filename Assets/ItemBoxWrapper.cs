using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxWrapper : MonoBehaviour
{
    public Item item;
    
    public void InsertItem(Item item)
    {
        this.item = item;

        if (item.blueprint.typeId == 1)
        {
            var o = GameObject.CreatePrimitive(PrimitiveType.Cube);
            o.transform.SetParent(transform);
            o.transform.localPosition = Vector3.zero;
        }
        else
        {
            var o = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            o.transform.SetParent(transform);
            o.transform.localPosition = Vector3.zero;
        }
    }
}
