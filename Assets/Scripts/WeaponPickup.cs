using UnityEngine;

namespace Shooter
{
    /// <summary>
    /// ����������� ������
    /// </summary>
    public class WeaponPickup : Pickup
    {


        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
        }
    }
}
