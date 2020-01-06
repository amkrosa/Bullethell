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
    public Vector3 OriginalPosition { get; private set; }
    public GameObject center;
    Vector3 CurrentPosition;
    Rigidbody2D _rigidbody;
    AIPath _pathing;
    public GameObject Laser;


    // Start is called before the first frame update
    void Start()
    {
        _pathing = gameObject.GetComponent<AIPath>();
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        OriginalPosition = gameObject.GetComponent<Transform>().position;
        _pathing.canMove = false;
        _pathing.canSearch = false;
        CurrentHealth = MaximumHealth;
        HealthPercentage = 100; 
    }

    // Update is called once per frame
    void Update()
    {
        HealthPercentage = (float)CurrentHealth / MaximumHealth;
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
    }

    public void FreezePosition(bool value)
    {
        if (value==true)
        {
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            _rigidbody.constraints = RigidbodyConstraints2D.None;
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    public void SetPathingAI(bool value)
    {

        _pathing.canMove = value;
        _pathing.canSearch = value;
    }
    public void ResetEnemyPosition()
    {
        gameObject.GetComponent<Transform>().position = OriginalPosition;
    }
}
