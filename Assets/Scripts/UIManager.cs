using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonPersistent<UIManager>
{
    public Text txt_score;

    private void Start()
    {
        UpdateScore();
    }

    public void UpdateScore()
    {
        txt_score.text = $"Score:{GameManager.Instance.score.score}";
    }
}
