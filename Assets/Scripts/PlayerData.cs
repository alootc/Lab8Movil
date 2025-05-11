using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "ScriptableObjects/Sensors", order = 2)]
public class PlayerData : ScriptableObject
{
    [System.Serializable]

    public class PlayerDTO
    {
        public Sprite  imagen;

        public int health_max;
        
        public int speed;
    }

    public List<PlayerDTO> players;


}
