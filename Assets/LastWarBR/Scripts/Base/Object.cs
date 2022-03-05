using System;
using UnityEngine;

namespace LastWarBR
{
    [CreateAssetMenu(fileName = "Object",menuName = "LastWarBR/Inventory/Object")]
    [Serializable]
    public class Object :ScriptableObject
    {
        #region Declarations
        [Header("Object components")]
        [SerializeField, Range(1,99)] private short uses = 1;
        [SerializeField] private bool unbreakable = false;
        #endregion
        #region Encapsulation
        public short Uses
        {
            get => uses;
            set
            {
                if ( value > 0 )
                {
                    uses = value;
                }
                else
                {
                    uses = 1;
                }
            }
        }
        public bool Unbreakable { get; set; }
        #endregion
        #region Constructor
        public Object()
        {
            uses = 1;
            unbreakable = false;
        }
        public Object(short uses,bool unbreakable)
        {
            Uses = uses;
            Unbreakable = unbreakable;
        }
        #endregion
    }
}
