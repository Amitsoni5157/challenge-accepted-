using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private List<Card> flippedCards = new List<Card>();

    private int score = 0;
    private int penalty = -1;

    public UIManager uiManager;
    public SoundManager soundManager;
    private GameData gameData;

    public List<Card> allCards = new List<Card>();

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        gameData = SaveManager.LoadGame();

        if (gameData != null)
        {
            score = gameData.score;
            LoadCardStates();
        }

        uiManager.UpdateScore(score);
    }

    void SaveGame()
    {
        gameData = new GameData();
        gameData.score = score;

        gameData.cardStates = new bool[allCards.Count];
        for (int i = 0; i < allCards.Count; i++)
        {
            gameData.cardStates[i] = allCards[i].IsMatched; // Store matched state
        }

        SaveManager.SaveGame(gameData);
    }

    void LoadCardStates()
    {
        if (gameData.cardStates != null && gameData.cardStates.Length == allCards.Count)
        {
            for (int i = 0; i < allCards.Count; i++)
            {
                if (gameData.cardStates[i])
                {
                    allCards[i].gameObject.SetActive(false); // Hide matched cards
                    allCards[i].IsMatched = true;
                }
            }
        }
    }

    public void CheckMatch(Card selectedCard)
    {
        if (flippedCards.Contains(selectedCard)) return;

        flippedCards.Add(selectedCard);
        selectedCard.FlipCard();
        soundManager.PlayFlipSound();

        if (flippedCards.Count == 2)
        {
            StartCoroutine(CompareCards());
        }
    }

    private IEnumerator CompareCards()
    {
        yield return new WaitForSeconds(0.15f);

        if (flippedCards[0].frontSprite == flippedCards[1].frontSprite)
        {
            score += 10;
            soundManager.PlayMatchSound();

            flippedCards[0].IsMatched = true;
            flippedCards[1].IsMatched = true;

            yield return new WaitForSeconds(0.15f);
            flippedCards[0].gameObject.SetActive(false);
            flippedCards[1].gameObject.SetActive(false);
        }
        else
        {
            score += penalty;
            flippedCards[0].ResetCard();
            flippedCards[1].ResetCard();
            soundManager.PlayMismatchSound();
        }

        uiManager.UpdateScore(score);
        flippedCards.Clear();
        SaveGame();
    }
}
