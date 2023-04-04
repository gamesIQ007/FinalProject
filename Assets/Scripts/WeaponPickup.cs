using UnityEngine;

namespace Shooter
{
    /// <summary>
    /// Подбираемое оружие
    /// </summary>
    public class WeaponPickup : AmmunitionBox
    {
        /// <summary>
        /// Свойства оружия
        /// </summary>
        [SerializeField] private WeaponProperties weaponProperties;
        
        private SpriteRenderer sr;

        private void Start()
        {
            sr = GetComponentInChildren<SpriteRenderer>();
            sr.sprite = weaponProperties.Sprite;
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);

            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.AddWeapon(weaponProperties);
            }
        }
    }
}
