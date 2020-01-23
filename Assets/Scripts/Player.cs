using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Damage = 5;
    public int Health = 100;
    private float _invulnerabilityTime = 0.5f;
    private float _invulnerabilityLeft = 0;

    [Obsolete("isHit is deprecated, please use InvulnerabilityLeft instead.")]
    public bool isHit=false;

    public float InvulnerabilityLeft { get => _invulnerabilityLeft; set => _invulnerabilityLeft = value; }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay2D(Collision2D col)
    {
        Debug.Log(col.gameObject.tag);
        if (_invulnerabilityLeft <= 0)
        {
            if (col.gameObject.tag == Tags.Enemy)
            {
                Health -= 5;
                _invulnerabilityLeft = _invulnerabilityTime;
            }
        }
        else _invulnerabilityLeft -= Time.deltaTime;
    }
}