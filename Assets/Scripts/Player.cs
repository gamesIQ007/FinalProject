using UnityEngine;

namespace Shooter
{
    [RequireComponent(typeof(Rigidbody2D))]
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
        /// Звуки
        /// </summary>
        [HideInInspector] public new AudioSource audio;


        protected override void Start()
        {
            base.Start();
            rb = GetComponent<Rigidbody2D>();
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
        /// Возможно ли отнять патроны
        /// </summary>
        /// <param name="count">Количество отнимаемых патронов</param>
        /// <returns>Удачное ли изъяние патронов</returns>
        public bool DrawAmmo(int count)
        {
            if (count == 0)
            {
                return true;
            }

            /*if (m_SecondaryAmmo >= count)
            {
                m_SecondaryAmmo -= count;
                return true;
            }*/

            return false;
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