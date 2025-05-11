using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreUI : MonoBehaviour
{
    public Text txt_score;

    private void Start()
    {    
       txt_score.text = $"mejor puntaje {GameManager.Instance.GetLastScore()}";
        
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Menu");
    }
}
