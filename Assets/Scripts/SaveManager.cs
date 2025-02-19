using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    // Make filePath static so it can be used in static methods
    private static string filePath;

    void Awake()
    {
        // Initialize the filePath in Awake
        filePath = Application.persistentDataPath + "/gameData.json";
    }

    // Save game data to a file
    public static void SaveGame(GameData data)
    {
        // Check if filePath is set correctly
        Debug.Log("Saving to file: " + filePath);

        string json = JsonUtility.ToJson(data); // Convert data to JSON
        File.WriteAllText(filePath, json); // Save to file
    }

    // Load game data from a file
    public static GameData LoadGame()
    {
        // Check if the file exists
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath); // Read from file
            return JsonUtility.FromJson<GameData>(json); // Convert JSON to GameData
        }
        return null; // No saved data found
    }

    // Delete the save file (for testing purposes)
    public static void DeleteSave()
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath); // Delete the save file
        }
    }
}
