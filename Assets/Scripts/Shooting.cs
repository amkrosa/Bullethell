using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Player Player;
    public Transform BulletOrigin;
    public float BulletForce;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Bullet bullet = BulletsPool.Instance.GetBullet(BulletType.Arrow);
            bullet.transform.position = BulletOrigin.position;
            bullet.transform.rotation = BulletOrigin.rotation;
            bullet.Rb.AddForce(BulletOrigin.up * BulletForce, ForceMode2D.Impulse);
            bullet.Damage = Player.Damage;
        }
    }
}