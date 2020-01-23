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
    public Vector3 CurrentPosition { get; private set; }
    private Rigidbody2D _rigidbody;
    private AIPath _pathing;
    private bool _isResettingPosition;
    public GameObject Laser;
    public GameObject Beam;
    private Transform _transform;


    // Start is called before the first frame update
    void Start()
    {
        _pathing = gameObject.GetComponent<AIPath>();
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        OriginalPosition = transform.position;
        _transform = gameObject.GetComponent<Transform>();
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
            Destroy(gameObject);

        if (_isResettingPosition)
            ResetEnemyPosition();
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
    private void ResetEnemyPosition()
    {
        if (Vector3.Distance(transform.position, OriginalPosition) < 0.001f)
        {
            _isResettingPosition = false;
        }
        else
        {
            float step = 7.5f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, OriginalPosition, step);
        }
    }
    public void ResetEnemyPosition(bool value)
    {
        _isResettingPosition = value;
    }
}
