using System;
using UnityEngine;

public class PlayerInventory : Singleton<PlayerInventory>
{
    public Item Bullet;

    private void Start()
    {
        Bullet = GameManager.Instance.ItemsDb.Items[0];
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Bullet = GameManager.Instance.ItemsDb.Items[0];
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Bullet = GameManager.Instance.ItemsDb.Items[1];
        }
    }
}


[System.Serializable]
public class Item
{
    public string Name;
    public int Id;
    public GameObject Prefab;
}
