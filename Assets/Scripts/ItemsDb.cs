using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsDb", menuName = "ScriptableObjects/ItemsDb")]
public class ItemsDb : ScriptableObject
{
    public List<Item> Items; //todo create dict at start

    public Item GetItem(int itemId)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if(Items[i].Id == itemId)
            {
                return Items[i];
            }
        }

        return null;
    }
}
