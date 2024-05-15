using System;
using UnityEngine;


namespace Character
{
    [Serializable]
    public sealed class PlayerService
    {
        [SerializeField] private GameObject character;
        public GameObject Character => character;
    }
}