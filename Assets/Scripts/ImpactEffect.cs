﻿using UnityEngine;

namespace Shooter
{
    /// <summary>
    /// Эффект взаимодействия
    /// </summary>
    public class ImpactEffect : MonoBehaviour
    {
        /// <summary>
        /// Время жизни
        /// </summary>
        [SerializeField] private float lifeTime;

        /// <summary>
        /// Таймер
        /// </summary>
        private float timer;


        private void Update()
        {
            if (timer < lifeTime)
            {
                timer += Time.deltaTime;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}