using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

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
            UseProperties(weaponProperties);
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

        /// <summary>
        /// Применить свойства подбираемого оружия
        /// </summary>
        private void UseProperties(WeaponProperties weaponProperties)
        {
            sr = GetComponentInChildren<SpriteRenderer>();
            sr.sprite = weaponProperties.Sprite;
        }

#if UNITY_EDITOR

        [CustomEditor(typeof(WeaponPickup))]
        public class WeaponPickupInspector : Editor
        {
            public override void OnInspectorGUI()
            {
                base.OnInspectorGUI();
                WeaponProperties properties = EditorGUILayout.ObjectField(null, typeof(WeaponProperties), false) as WeaponProperties;

                if (properties != null)
                {
                    (target as WeaponPickup).UseProperties(properties);
                }
            }
        }

#endif
    }
}
