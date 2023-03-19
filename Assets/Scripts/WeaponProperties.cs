using UnityEngine;

namespace Shooter
{
    [CreateAssetMenu]

    /// <summary>
    /// Свойства оружия
    /// </summary>
    public class WeaponProperties : ScriptableObject
    {
        /// <summary>
        /// Префаб снаряда
        /// </summary>
        [SerializeField] private Projectile projectilePrefab;
        public Projectile ProjectilePrefab => projectilePrefab;

        /// <summary>
        /// Скорострельность
        /// </summary>
        [SerializeField] private float rateOfFire;
        public float RateOfFire => rateOfFire;

        /// <summary>
        /// Звук выстрела
        /// </summary>
        [SerializeField] private AudioClip launchSFX;
        public AudioClip LaunchSFX => launchSFX;
    }
}