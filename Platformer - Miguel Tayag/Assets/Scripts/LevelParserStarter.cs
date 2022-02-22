using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;

public class LevelParserStarter : MonoBehaviour
{
    public string filename;
    [FormerlySerializedAs("Rock")]
    public GameObject rockPrefab;
    [FormerlySerializedAs("Brick")]
    public GameObject brickPrefab;
    [FormerlySerializedAs("QuestionBox")]
    public GameObject questionBoxPrefab;
    [FormerlySerializedAs("Stone")]
    public GameObject stonePrefab;
    public Transform environmentRoot;

    // --------------------------------------------------------------------------
    void Start()
    {
        LoadLevel();
    }

    // --------------------------------------------------------------------------
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadLevel();
        }
    }

    // --------------------------------------------------------------------------
    private void LoadLevel()
    {
        string fileToParse = $"{Application.dataPath}{"/Resources/"}{filename}.txt";
        Debug.Log($"Loading level file: {fileToParse}");

        Stack<string> levelRows = new Stack<string>();

        // Get each line of text representing blocks in our level
        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                levelRows.Push(line);
            }

            sr.Close();
        }

        // Go through the rows from bottom to top
        int row = 0;
        while (levelRows.Count > 0)
        {
            string currentLine = levelRows.Pop();

            int column = 0;
            char[] letters = currentLine.ToCharArray();
            foreach (var letter in letters)
            {
                // Todo - Instantiate a new GameObject that matches the type specified by letter
                    var rockObject = Instantiate(rockPrefab);
                    var stoneObject = Instantiate(stonePrefab);
                    var QuestionBoxObject = Instantiate(questionBoxPrefab);
                    var BrickObject = Instantiate(brickPrefab);

                if (letter == 'x'){
                    rockObject.transform.position = new Vector3(column + 0.5f, row + 0.5f, -0.5f);
                }
                if (letter == 's'){
                    stoneObject.transform.position = new Vector3(column + 0.5f, row + 0.5f, -0.5f);
                }
                if (letter == 'b'){
                    BrickObject.transform.position = new Vector3(column + 0.5f, row + 0.5f, -0.5f);
                }
                if (letter == '?'){
                    QuestionBoxObject.transform.position = new Vector3(column + 0.5f, row + 0.5f, -0.5f);
                }
                // Todo - Position the new GameObject at the appropriate location by using row and column
                // Todo - Parent the new GameObject under levelRoot
                column++;
            }
            row++;
        }
    }

    // --------------------------------------------------------------------------
    private void ReloadLevel()
    {
        foreach (Transform child in environmentRoot)
        {
           Destroy(child.gameObject);
        }
        LoadLevel();
    }
}
