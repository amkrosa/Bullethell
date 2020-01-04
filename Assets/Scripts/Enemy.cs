using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    int MaximumHealth = 100;
    public int CurrentHealth;
    public float HealthPercentage;
    public AIPath Pathing;
    
  
    // Start is called before the first frame update
    void Start()
    {
        Pathing = gameObject.GetComponent<AIPath>();
        Pathing.canMove = false;
        Pathing.canSearch = false;
        CurrentHealth = MaximumHealth;
        HealthPercentage = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
          HealthPercentage = (float)CurrentHealth / MaximumHealth;
    }
}
