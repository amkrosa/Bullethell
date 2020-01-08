using System.Collections.Generic;

public class BulletsPool : Singleton<BulletsPool>
{
    public Bullet BulletPrefab; //todo scriptable with diffrent bullet prefabs
    private Dictionary<BulletType, Queue<Bullet>> _pool = new Dictionary<BulletType, Queue<Bullet>>();

    public Bullet GetBullet(BulletType type)
    {
        Queue<Bullet> queue;

        if(!_pool.TryGetValue(type, out queue))
        {
            queue = new Queue<Bullet>();
            _pool.Add(type, queue);
        }

        Bullet bullet;

        if (queue.Count == 0)
        {
            bullet = Instantiate(BulletPrefab);
            return bullet;
        }
        else
        {
            bullet = queue.Dequeue();
            bullet.gameObject.SetActive(true);
            return bullet;
        }
    }

    public void ReturnToPool(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        _pool[bullet.BulletType].Enqueue(bullet);
    }
}
