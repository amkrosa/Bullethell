using UnityEngine;

public class Shooting : MonoBehaviour
{
    private const float ShootingTreshold = 0.1f;

    public Player Player;
    public Transform BulletOrigin;
    public float BulletForce;

    private float _lastShoot;

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (Time.time - _lastShoot > ShootingTreshold)
            {
                _lastShoot = Time.time;
                Debug.Log(PlayerInventory.Instance.Bullet.Name);
                Bullet bullet = BulletsPool.Instance.GetBullet(PlayerInventory.Instance.Bullet.Id);
                bullet.transform.position = BulletOrigin.position;
                bullet.transform.rotation = BulletOrigin.rotation;
                bullet.Rb.AddForce(BulletOrigin.up * BulletForce, ForceMode2D.Impulse);
                bullet.Damage = Player.Damage;
            }
        }
    }
}