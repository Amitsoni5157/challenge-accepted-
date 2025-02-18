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
}
