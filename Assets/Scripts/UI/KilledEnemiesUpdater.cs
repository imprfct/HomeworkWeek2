using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class KilledEnemiesUpdater: MonoBehaviour
    {
        public void IncrementKilledEnemiesCounter()
        {
            var label = UIManager.Instance.KilledEnemiesCounter;
            if (label != null)
            {
                int killedEnemies = int.Parse(label.GetComponent<Text>().text) + 1;
                label.GetComponent<Text>().text = killedEnemies.ToString();
            }
            UIManager.Instance.KilledEnemiesCounter = label;
        }
    }
}