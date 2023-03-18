using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Shooter
{
    /// <summary>
    /// Уничтожаемый объект. То, что может иметь хитпоинты.
    /// </summary>
    public class Destructible : Entity
    {
        /// <summary>
        /// Объект игнорирует повреждения.
        /// </summary>
        [SerializeField] private bool indestructible;
        public bool IsIndestructible => indestructible;

        /// <summary>
        /// Стартовое количество хитпоинтов.
        /// </summary>
        [SerializeField] protected int maxHitPoints;
        public int MaxHitPoints => maxHitPoints;

        /// <summary>
        /// Текущее количество хитпоинтов.
        /// </summary>
        private int currentHitPoints;
        public int HitPoints => currentHitPoints;

        /// <summary>
        /// Ивент, происходящий со смертью
        /// </summary>
        [SerializeField] protected UnityEvent eventOnDeath;
        public UnityEvent EventOnDeath => eventOnDeath;

        protected virtual void Start()
        {
            currentHitPoints = maxHitPoints;
        }

        /// <summary>
        /// Применение урона к объекту.
        /// </summary>
        /// <param name="damage">Наносимый объекту урон.</param>
        public void ApplyDamage(int damage)
        {
            if (indestructible) return;

            currentHitPoints -= damage;
            if (currentHitPoints <= 0)
            {
                OnDeath();
            }
        }

        /// <summary>
        /// Переопределяемое событие уничтожения объекта, когда хитпоинты меньше 0.
        /// </summary>
        protected virtual void OnDeath()
        {
            Destroy(gameObject);
            eventOnDeath?.Invoke();
        }

        /// <summary>
        /// Список всех уничтожаемых объектов. HashSet - аналог List, иногда работает быстрее
        /// </summary>
        private static HashSet<Destructible> m_AllDestructibles;
        public static IReadOnlyCollection<Destructible> AllDestructibles => m_AllDestructibles;

        protected virtual void OnEnable()
        {
            if (m_AllDestructibles == null)
            {
                m_AllDestructibles = new HashSet<Destructible>();
            }

            m_AllDestructibles.Add(this);
        }

        protected virtual void OnDestroy()
        {
            m_AllDestructibles.Remove(this);
        }
    }
}
