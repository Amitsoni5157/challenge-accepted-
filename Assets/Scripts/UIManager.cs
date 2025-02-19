using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; 

    
    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }
    public void LoadGame()
    {
        GameData loadedData = SaveManager.LoadGame();
        if (loadedData != null)
        {
            scoreText.text = "Loaded Score: " + loadedData.score.ToString();
        }
    }
}
