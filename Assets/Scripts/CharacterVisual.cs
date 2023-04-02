using UnityEngine;

namespace Shooter
{
    /// <summary>
    /// Отображение персонажа
    /// </summary>
    public class CharacterVisual : MonoBehaviour
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
        /// Анимации
        /// </summary>
        private Animator animator;

        /// <summary>
        /// Смотрим ли вправо
        /// </summary>
        private bool lookRight;

        private void Start()
        {
            rb = transform.root.GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (rb.velocity.magnitude == 0)
            {
                animator.SetBool("IsWalk", false);
            }
            else
            {
                animator.SetBool("IsWalk", true);
            }
        }

        private void LateUpdate()
        {
            transform.up = Vector2.up;

            if (lookRight && rb.velocity.x < 0)
            {
                sr.flipX = true;
                lookRight = false;
            }
            else if (lookRight == false && rb.velocity.x > 0)
            {
                sr.flipX = false;
                lookRight = true;
            }
        }
    }
}
