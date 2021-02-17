using UnityEngine;
using UnityEngine.UI;

public class TryAgainClick : MonoBehaviour
{
    [SerializeField] 
    private GameLogic _gameLogic;

    void Start () {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(BtnOnClick);
    }

    void BtnOnClick(){
        _gameLogic.Restart();
    }
}
