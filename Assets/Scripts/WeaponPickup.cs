using UnityEngine;

namespace Shooter
{
    /// <summary>
    /// Подбираемое оружие
    /// </summary>
    public class WeaponPickup : Pickup
    {


        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
        }
    }
}
