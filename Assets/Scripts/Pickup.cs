using UnityEngine;

namespace Shooter
{
	/// <summary>
    /// Подбираемые предметы
    /// </summary>
	public class Pickup : MonoBehaviour
	{
		protected virtual void OnTriggerEnter2D(Collider2D other)
		{
			Player player = other.GetComponent<Player>();

			if (player != null)
			{
				Destroy(gameObject);
			}
		}
	}
}
