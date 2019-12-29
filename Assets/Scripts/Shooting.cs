using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform BulletOrigin;
    public float BulletForce;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(BulletPrefab, BulletOrigin.position, BulletOrigin.rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.AddForce(BulletOrigin.up * BulletForce, ForceMode2D.Impulse);
        }
    }

}