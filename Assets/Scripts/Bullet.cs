using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour, IUpdateTick
{
    private const int LiveTime = 4;

    public int Damage;
    public BulletType BulletType;
    public Rigidbody2D Rb;

    private float _creationTime;

    private void OnEnable()
    {
        _creationTime = Time.time;
        UpdateTick.Instance.AddToUpdateTick(this);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag(Tags.Player))
        {
            if (collision.gameObject.CompareTag(Tags.Enemy))
            {
                Debug.Log("collision.gameObject.GetComponent<Enemy>().Health: " + collision.gameObject.GetComponent<Enemy>().CurrentHealth);
                collision.gameObject.GetComponent<Enemy>().CurrentHealth -= 5;
            }

            ReturnToPool();
        }
    }

    private void ReturnToPool()
    {
        UpdateTick.Instance.RemoveFromUpdateTick(this);
        BulletsPool.Instance.ReturnToPool(this);
    }

    public void OnUpdateTick()
    {
        if(Time.time - _creationTime > LiveTime)
        {
            ReturnToPool();
        }
    }
}
