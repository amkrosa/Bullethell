using System.Collections.Generic;

public class BulletsPool : Singleton<BulletsPool>
{
    private Dictionary<int, Queue<Bullet>> _pool = new Dictionary<int, Queue<Bullet>>();

    public Bullet GetBullet(int itemId)
    {
        Queue<Bullet> queue;

        if(!_pool.TryGetValue(itemId, out queue))
        {
            queue = new Queue<Bullet>();
            _pool.Add(itemId, queue);
        }

        Bullet bullet;

        if (queue.Count == 0)
        {
            bullet = Instantiate(GameManager.Instance.ItemsDb.GetItem(itemId).Prefab.GetComponent<Bullet>());
            bullet.Setup(itemId);
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
        _pool[bullet.Id].Enqueue(bullet);
    }
}
