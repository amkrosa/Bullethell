using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
           if (!col.gameObject.CompareTag(Tags.Enemy))
           {
                if (col.gameObject.CompareTag(Tags.Player))
                {
                    col.gameObject.GetComponent<Player>().Health -= 5;
                    GameObject.Destroy(gameObject);
                }
            }
        }
}
