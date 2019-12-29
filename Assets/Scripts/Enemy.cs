using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    int MaximumHealth = 100;
    public int CurrentHealth;
    public float HealthPercentage;

    // Start is called before the first frame update
    void Start()
    {
 
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
