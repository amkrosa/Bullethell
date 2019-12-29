using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int Damage;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Debug.Log("collision.gameObject.GetComponent<Enemy>().Health: " + collision.gameObject.GetComponent<Enemy>().CurrentHealth);
                collision.gameObject.GetComponent<Enemy>().CurrentHealth -= 5;
                
            }
            Destroy(gameObject);
        }
    }
}
