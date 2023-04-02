using UnityEngine;

namespace Shooter
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(AmmoBag))]
    [RequireComponent(typeof(AudioSource))]

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
        /// Список оружия
        /// </summary>
        [SerializeField] private Weapon[] weapons;

        /// <summary>
        /// Индекс активного оружия
        /// </summary>
        private int activeWeaponIndex = 0;

        /// <summary>
        /// Сохранённая ссылка на ригид
        /// </summary>
        private Rigidbody2D rb;
		
        /// <summary>
        /// Сохранённая ссылка на сумку боеприпасов
        /// </summary>
        private AmmoBag ammoBag;
        public AmmoBag AmmoBag => ammoBag;

        /// <summary>
        /// Звуки
        /// </summary>
        [HideInInspector] public new AudioSource audio;


        protected override void Start()
        {
            base.Start();
            rb = GetComponent<Rigidbody2D>();
            ammoBag = GetComponent<AmmoBag>();
            audio = GetComponent<AudioSource>();
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


        /// <summary>
        /// Стрельба
        /// </summary>
        /// <param name="point">Цель выстрела</param>
        public void Fire(Vector3 point)
        {
            weapons[activeWeaponIndex].transform.up = point - weapons[activeWeaponIndex].transform.position;
            weapons[activeWeaponIndex].Fire();
        }
    }
}