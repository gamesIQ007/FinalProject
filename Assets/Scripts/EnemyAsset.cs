﻿using UnityEngine;

namespace Shooter
{
    /// <summary>
    /// ScriptableObject со свойствами врагов
    /// </summary>
    [CreateAssetMenu]
    public class EnemyAsset : ScriptableObject
    {
        [Header("Внешний вид")]
        /// <summary>
        /// Цвет
        /// </summary>
        public Color color = Color.white;

        /// <summary>
        /// Размер спрайта
        /// </summary>
        public Vector2 spriteScale = new Vector2(4, 4);

        /// <summary>
        /// Анимация
        /// </summary>
        public RuntimeAnimatorController animations;
        
        [Header("Игровые параметры")]

        /// <summary>
        /// Скорость движения
        /// </summary>
        public float moveSpeed = 1.0f;

        /// <summary>
        /// Здоровье
        /// </summary>
        public int hp = 10;

        /// <summary>
        /// Радиус коллайдера
        /// </summary>
        public float radius = 0.4f;

        /// <summary>
        /// Смещение коллайдера
        /// </summary>
        public float colliderOffsetY = 0.0f;
    }
}