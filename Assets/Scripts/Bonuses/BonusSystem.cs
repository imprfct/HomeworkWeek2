using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts.Bonuses
{
    public class BonusSystem : MonoBehaviour
    {
        [SerializeField]
        private GameObject _player;
        [SerializeField]
        private List<Bonus> _bonuses;

        private void Update()
        {
            if (Input.GetKeyUp("space"))
            {
                var randomBonus = _bonuses[new Random().Next(_bonuses.Count)];
                randomBonus.Effect(_player);
            }        
        }
    }
}
