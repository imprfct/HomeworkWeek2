using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class KilledEnemiesUpdater: MonoBehaviour
    {
        public void IncrementKilledEnemiesLabel()
        {
            var label = GameObject.FindWithTag("KilledEnemiesLabel");
            if (label != null)
            {
                var oldText = label.GetComponent<Text>().text;
                
                if (int.TryParse(oldText, out var killedEnemies))
                {
                    killedEnemies++;
                    label.GetComponent<Text>().text = killedEnemies.ToString();
                }
            }
        }
    }
}