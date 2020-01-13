using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Collider2D collider;
    public int Damage = 5;
    public int Health = 100;
    float invulnerabilityTime = 0.22f;
    public bool isHit=false;
    private IEnumerator playerHit;

    // Start is called before the first frame update
    void Start()
    {
        collider = gameObject.GetComponent<PolygonCollider2D>();
        playerHit = PlayerIsHit(invulnerabilityTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if ((col.gameObject.tag=="Enemy" || col.gameObject.tag == "EnemyAttack") && isHit == false)
        {
            if (col.gameObject.tag == "Enemy") Health -= 5;
            isHit = true;
            StartCoroutine(playerHit);
            StopCoroutine(playerHit);
            isHit = false;
        }

    }

    IEnumerator PlayerIsHit(float invTime)
    {
        yield return new WaitForSecondsRealtime(invTime);
    }
}