using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaEntrance : MonoBehaviour
{
    Collider2D collider;
    public GameObject EnemyHealthBar;
    public GameObject Enemy;

    void Start()
    {
        collider = gameObject.GetComponent<Collider2D>();
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Player entered boss arena.");
            Enemy.SetActive(true);
            EnemyHealthBar.SetActive(true);
            collider.isTrigger = false;
        }
    }

    void Update()
    {
    }
}
