using UnityEngine;

namespace Shooter
{
    /// <summary>
    /// Отображение оружия
    /// </summary>
    public class WeaponVisual : MonoBehaviour
    {
        /// <summary>
        /// Ригид родителя
        /// </summary>
        private Rigidbody2D rb;

        /// <summary>
        /// Спрайт
        /// </summary>
        private SpriteRenderer sr;

        /// <summary>
        /// Смотрим ли вправо
        /// </summary>
        private bool lookRight;

        private void Start()
        {
            rb = transform.root.GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        }
    }
}
