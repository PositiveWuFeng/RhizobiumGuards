using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Base
{
    /// <summary>
    /// Attribute classes for characters
    /// </summary>
    public class Property : MonoBehaviour
    {
        public int id;
        
        //index stands for the serial number in the property list
        public int index=-1;
        
        public float HP;

        //Attack power 
        public float power;

        public float attackRange;
        
        public float attackSpeed;
        
        public float moveSpeed;

        public int level;

        public float spellRange;
        
        public float AttackSpeed
        {
            get { return 1 / attackSpeed; }
        }
    }
}
