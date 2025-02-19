using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Sprite frontSprite;
    public Sprite backSprite;

    private Image cardImage;
    private bool isFlipped = false;
    public bool IsMatched { get; set; } = false; 

    public int cardIndex;

    void Start()
    {
        cardImage = GetComponent<Image>();
        cardImage.sprite = backSprite;
    }

    public void FlipCard()
    {
        if (!isFlipped && !IsMatched)
        {
            cardImage.sprite = frontSprite;
            isFlipped = true;
            GameManager.instance.CheckMatch(this);
        }
    }

    public void ResetCard()
    {
        if (!IsMatched)
        {
            cardImage.sprite = backSprite;
            isFlipped = false;
        }
    }
}
