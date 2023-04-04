using UnityEngine;

namespace Shooter
{
    /// <summary>
    /// ����������� ������
    /// </summary>
    public class WeaponPickup : AmmunitionBox
    {
        /// <summary>
        /// �������� ������
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
