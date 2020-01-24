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

    void Start()
    {

    }

    void Update()
    {
        if(Health <= 0)
        {
            EndGame.Instance.Lose.SetActive(true);
        }
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
