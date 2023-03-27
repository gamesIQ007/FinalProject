using UnityEngine;

namespace Shooter
{
	/// <summary>
    /// Коробка боеприпасов
    /// </summary>
	public class AmmunitionBox : Pickup
	{
		/// <summary>
        /// Тип боеприпасов
        /// </summary>
		[SerializeField] private AmmoType type;
		/// <summary>
        /// Количество боеприпасов
        /// </summary>
		[SerializeField] private int count;
		
		/// <summary>
        /// Эффект после подбора
        /// </summary>
		[SerializeField] private GameObject impactEffect;

		protected override void OnTriggerEnter2D(Collider2D other)
		{
			base.OnTriggerEnter2D(other);

			AmmoBag bag = other.GetComponent<AmmoBag>();

			if (bag != null)
			{
				bag.AddAmmo(type, count);

				Instantiate(impactEffect);
			}
		}
	}
}
