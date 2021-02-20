using UnityEngine;
using UnityEngine.UI;

namespace UI.HealthBar
{
    public class TryAgainClick : MonoBehaviour
    {
        void Start () {
            Button btn = gameObject.GetComponent<Button>();
            btn.onClick.AddListener(BtnOnClick);
        }

        void BtnOnClick(){
            GameLogic.Instance.Restart();
        }
    }
}
