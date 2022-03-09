using System;
using UnityEngine;

namespace LastWarBR
{

    [CreateAssetMenu(fileName = "Weapon",menuName = "LastWarBR/Inventory/Weapon")]
    [Serializable]
    public class Weapon :Object
    {
        #region Declarations
        [Header("Weapon Stats")]
        [SerializeField, Range(50,1000)] private short damage = 50;
        [SerializeField, Range(1,20)] private short range = 1;
        [SerializeField, Range(1,5)] private short areaEffect = 1;
        [SerializeField, Range(0,5)] private double coldown = 0;
        [SerializeField, Range(1,50)] private short ammo = 1;
        [SerializeField, Range(1,100)] private short bulletSpeed = 1;

        [SerializeField] private Material mat;
        #endregion
        #region Encapsulation
        public short Damage
        {
            get => damage;
            set
            {
                if ( value > 0 )
                {
                    damage = value;
                }
                else
                {
                    damage = 50;
                }
            }
        }
        public short Range
        {
            get => range;
            set
            {
                if ( value > 0 )
                {
                    range = value;
                }
                else
                {
                    range = 10;
                }
            }
        }
        public short AreaEffect
        {
            get => areaEffect;
            set
            {
                if ( value > 0 )
                {
                    areaEffect = value;
                }
                else
                {
                    areaEffect = 1;
                }
            }
        }
        public double Coldown
        {
            get => coldown;
            set
            {
                if ( value > 0 )
                {
                    coldown = value;
                }
                else
                {
                    coldown = 1;
                }
            }
        }
        public short Ammo
        {
            get => ammo;
            set
            {
                if ( value > 0 )
                {
                    ammo = value;
                }
                else
                {
                    ammo = 1;
                }
            }
        }
        public short BulletSpeed => bulletSpeed;
        public Material Mat => mat;
        #endregion
        #region Constructor
        public Weapon(short damage = 50,short range = 10,short areaEffect = 1,short coldown = 1,short ammo = 1)
        {
            Damage = damage;
            Range = range;
            AreaEffect = areaEffect;
            Coldown = coldown;
            Ammo = ammo;
        }
        public void MoreAmmo()
        {
            Ammo += ammo;
        }
        #endregion
    }
}