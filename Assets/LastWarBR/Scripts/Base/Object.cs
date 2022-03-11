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
        [SerializeField] private ObjectType type;
        [SerializeField, Range(0,99)] private short uses = 1;
        [SerializeField] private bool unbreakable = false;
        [SerializeField] private Sprite image;
        #endregion
        #region Encapsulation
        public short Uses
        {
            get => uses;
            set
            {
                if ( value >= 0 )
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
        public Sprite Image { get => image; set => image = value; }
        public ObjectType Type { get => type; set => type = value; }
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
    public enum ObjectType
    {
        Gun,
        AidKit,
        Key
    }
}
