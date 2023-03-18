using UnityEngine;

namespace Shooter
{
    /// <summary>
    /// Игрок
    /// </summary>
    public class Player : Destructible
    {
        /// <summary>
        /// Скорость перемещения
        /// </summary>
        [SerializeField] private float movementSpeed;

        /// <summary>
        /// Сохранённая ссылка на ригид
        /// </summary>
        private Rigidbody2D rb;


        protected override void Start()
        {
            base.Start();
            rb = GetComponent<Rigidbody2D>();
            //rb.inertia = 1; // иннерциальные силы, чтобы было проще балансировать соотношение сил и легче управлять
        }

        private void FixedUpdate()
        {
            UpdateRigitBody();
        }


        /// <summary>
        /// Управление движением
        /// </summary>
        public Vector2 MovementControl { get; set; }

        /// <summary>
        /// Метод добавления сил для движения
        /// </summary>
        private void UpdateRigitBody()
        {
            rb.velocity = new Vector2(MovementControl.x * movementSpeed, MovementControl.y * movementSpeed);
        }
    }
}