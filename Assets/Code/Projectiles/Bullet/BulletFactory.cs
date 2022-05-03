using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Services;
using Code.Services.Ticks;

namespace Code.Projectiles.Bullet
{
    public class BulletFactory : IService
    {
        private readonly PoolMono<Bullet> _bulletPool;
        private readonly TickProcessor _tickProcessor;
        

        public BulletFactory(IAssetProvider assetProvider, TickProcessor tickProcessor)
        {
            _tickProcessor = tickProcessor;
            
            Bullet bulletPrefab = assetProvider.Load<Bullet>(AssetPath.BULLET_PATH);
            _bulletPool = new PoolMono<Bullet>(bulletPrefab, 25, "[BULLETS]", false);
        }

        public Bullet Spawn()
        {
            Bullet firedBullet = _bulletPool.Take();
            firedBullet.Construct();
            
            _tickProcessor.Add(firedBullet);

            firedBullet.Hitting.OnHited += Despawn;

            return firedBullet;
        }

        public void Despawn(object sender)
        {
            Bullet bullet = sender as Bullet;
            _tickProcessor.Remove(bullet);
            _bulletPool.Put(bullet);
        }
    }
}