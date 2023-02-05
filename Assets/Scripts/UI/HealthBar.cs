using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Base
{
    public class HealthBar : MonoBehaviour
    {
        
        [SerializeField] private Slider slider;
        private float time = 0;
        private Property temp;
        public void SetMaxHealth(float health)
        {
            slider.maxValue = health;
            slider.value = health;
        } 

        public void SetHealth(float health)
        {
            slider.value = health;
        }

        private void Start()
        {
            slider = GetComponent<Slider>();
            temp = GetComponentInParent<Property>();
            SetMaxHealth(temp.HP);
        }

        private void Update()
        {
            time += Time.deltaTime;
            if (time >= 0.15f)
            {
                SetHealth(temp.HP);
            }
        }
    }
}

