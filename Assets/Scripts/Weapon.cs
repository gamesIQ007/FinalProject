using UnityEngine;

namespace Shooter
{
    /// <summary>
    /// Оружие
    /// </summary>
    public class Weapon : MonoBehaviour
    {
        /// <summary>
        /// Свойства турели. ScriptableObject
        /// </summary>
        [SerializeField] private WeaponProperties weaponProperties;

        /// <summary>
        /// Таймер повторного выстрела
        /// </summary>
        private float refireTimer;

        /// <summary>
        /// Возможность стрельбы
        /// </summary>
        public bool CanFire => refireTimer <= 0;

        /// <summary>
        /// Ссылка на игрока
        /// </summary>
        private Player player;

        
        private void Start()
        {
            player = transform.root.GetComponent<Player>();
        }

        private void Update()
        {
            if (refireTimer > 0)
            {
                refireTimer -= Time.deltaTime;
            }
        }

        
        /// <summary>
        /// Стрельба
        /// </summary>
        public void Fire()
        {
            if (weaponProperties == null) return;
            if (CanFire == false) return;

            Projectile projectile = Instantiate(weaponProperties.ProjectilePrefab);
            projectile.transform.position = transform.position;
            projectile.transform.up = transform.up;
            projectile.SetParentShooter(player);

            refireTimer = weaponProperties.RateOfFire;

            player.audio.clip = weaponProperties.LaunchSFX;
            player.audio.Play();
        }

        /// <summary>
        /// Замена режима стрельбы
        /// </summary>
        /// <param name="props"></param>
        public void AssignLoadout(WeaponProperties props)
        {
            refireTimer = 0;

            weaponProperties = props;
        }
    }
}