using UnityEngine;
using UnityEngine.UI;

public class CardLayoutManager : MonoBehaviour
{
    public GridLayoutGroup gridLayout;
    public GameObject cardPrefab; // Your card prefab
    private int rows, columns;
    private float screenWidth, screenHeight;

    void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        // Call the layout setup method with different configurations
        SetGridLayout("2x3"); // Example layout, you can change this to 2x3, 5x6, etc.
    }

    // Method to set up grid layout
    public void SetGridLayout(string layout)
    {
        // Define grid dimensions based on layout string
        switch (layout)
        {
            case "2x2":
                rows = 2;
                columns = 2;
                break;
            case "2x3":
                rows = 2;
                columns = 3;
                break;
            case "5x6":
                rows = 5;
                columns = 6;
                break;
            default:
                rows = 2;
                columns = 2;
                break;
        }

        // Update the grid layout to match the layout
        gridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount; // We use columns as constraint here
        gridLayout.constraintCount = columns;

        // Adjust the card size to fit the screen dynamically
        AdjustCardSize();
        
        // Instantiate cards based on rows and columns
        CreateCards(rows, columns);
    }

    // Adjust card size based on screen size
    void AdjustCardSize()
    {
        // Calculate card width and height based on screen size and grid configuration
        float cardWidth = screenWidth / columns;
        float cardHeight = screenHeight / rows;
        
        // Update the cell size of GridLayoutGroup
        gridLayout.cellSize = new Vector2(cardWidth, cardHeight);
    }

    // Create and instantiate the cards based on the grid dimensions
    void CreateCards(int rows, int columns)
    {
        // Remove existing cards
        foreach (Transform child in gridLayout.transform)
        {
            Destroy(child.gameObject);
        }

        // Create new cards
        for (int i = 0; i < rows * columns; i++)
        {
            Instantiate(cardPrefab, gridLayout.transform);
        }
    }
}
