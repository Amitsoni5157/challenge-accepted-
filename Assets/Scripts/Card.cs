using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Sprite frontSprite; // Card ka image (front)
    public Sprite backSprite;  // Card ka image (back)

    private Image cardImage;
    private bool isFlipped = false;

    void Start()
    {
        cardImage = GetComponent<Image>();
        cardImage.sprite = backSprite;
    }

    public void FlipCard()
    {
        if (!isFlipped)
        {
            cardImage.sprite = frontSprite; // Flip to front
            isFlipped = true;
            GameManager.instance.CheckMatch(this); // Matching logic call
        }
    }

    public void ResetCard()
    {
        cardImage.sprite = backSprite;
        isFlipped = false;
    }
}
