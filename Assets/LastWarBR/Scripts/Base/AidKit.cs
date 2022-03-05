using System;
using UnityEngine;

namespace LastWarBR
{

    [CreateAssetMenu(fileName = "AidKit",menuName = "LastWarBR/Inventory/AidKit")]
    [Serializable]
    public class AidKit :Object
    {
        #region Declarations
        [SerializeField, Range(50,1500)] private short pointsHealed = 50;
        #endregion
        #region Encapsulation
        public short PointsHealed
        {
            get => pointsHealed;
            set
            {
                if ( value > 50 )
                {
                    if ( value > 1500 )
                    {
                        pointsHealed = 1500;
                    }
                    else
                    {
                        pointsHealed = value;
                    }
                }
                else
                {
                    pointsHealed = 50;
                }
            }
        }
        #endregion
    }
}