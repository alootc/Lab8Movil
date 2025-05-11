using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonPersistent<GameManager>
{
    public PlayerData.PlayerDTO player_dto;

    public ScoreManager score;


    public void SetNaveDTO(PlayerData.PlayerDTO nave_dto)
    {
        this.player_dto = nave_dto;
    }

    public void SetScore()
    {
        score.score += player_dto.speed;
    }

    public void AddScore(int add_score)
    {
        score.score += add_score;
    }

    public int GetLastScore()
    {
        return score.GetScore();
    }

    public void GameOver()
    {
        Invoke("LoadScene", 0.5f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}

