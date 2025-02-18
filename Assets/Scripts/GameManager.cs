using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // This will hold the currently flipped cards (only 2 at a time for comparison)
    private List<Card> flippedCards = new List<Card>();

    void Awake()
    {
        if (instance == null) instance = this;
    }

    // This method will be called when a card is clicked
    public void CheckMatch(Card selectedCard)
    {
        // If the card is already flipped, we don't want to flip it again
        if (flippedCards.Contains(selectedCard)) return;

        // Flip the card and add it to the list of flipped cards
        flippedCards.Add(selectedCard);
        selectedCard.FlipCard();

        // If two cards are flipped, start comparing them immediately
        if (flippedCards.Count == 2)
        {
            StartCoroutine(CompareCards());
        }
    }

    // Compare the two flipped cards immediately (no waiting)
    private IEnumerator CompareCards()
    {
        yield return new WaitForSeconds(0.15f);

        // Check if the two flipped cards match immediately
        if (flippedCards[0].frontSprite == flippedCards[1].frontSprite)
        {
            // If the cards match, destroy them
            Destroy(flippedCards[0].gameObject);
            Destroy(flippedCards[1].gameObject);
        }
        else
        {
            // If the cards don't match, reset them
            flippedCards[0].ResetCard();
            flippedCards[1].ResetCard();
        }

        // Clear the list of flipped cards after comparison to allow new cards to be flipped
        flippedCards.Clear();
    }
}
