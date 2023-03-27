using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
	/// <summary>
	/// Сумка с боеприпасами
	/// </summary>
	public class AmmoBag : MonoBehaviour
	{
		/// <summary>
        /// Словарь с типами боеприпасов и их количеством
        /// </summary>
		private Dictionary<AmmoType, int> ammo;

		private void Start()
		{
			ammo = new Dictionary<AmmoType, int>();
		}

		/// <summary>
        /// Добавить боеприпасы в сумку
        /// </summary>
		public void AddAmmo(AmmoType type, int amount)
		{
			if (ammo.ContainsKey(type))
			{
				ammo[type] += amount;
			}
			else
			{
				ammo[type] = amount;
			}
		}

		/// <summary>
        /// Попытаться взять боеприпасы из сумки
        /// </summary>
		/// <param name="type">Тип отнимаемых патронов</param>
		/// <param name="amount">Количество отнимаемых патронов</param>
        /// <returns>Удачное ли изъяние патронов</returns>
		public bool TryTakeAmmo(AmmoType type, int amount)
		{
			if (ammo.ContainsKey(type) && ammo[type] >= amount)
			{
				ammo[type] -= amount;
				Debug.Log(ammo[type]);
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}