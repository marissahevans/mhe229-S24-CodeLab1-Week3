using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int score = 0;
    public double timer = 0.0;

    private int targetTrig = 1;
    public int sceneTrig = 0;

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            //Debug.Log("Someone set the score!");
            if (score > highScore)
            {
                HighScore = score;
            }
        }
    }


    int currentLevel = 0;

    int highScore = 0;

    public int HighScore
    {
        get
        {
            if (File.Exists(DATA_FULL_HS_FILE_PATH))
            {
                string fileContents = File.ReadAllText(DATA_FULL_HS_FILE_PATH);
                highScore = Int32.Parse(fileContents);
            }
            return highScore;
        }
        set
        {
            highScore = value;
            Debug.Log("New High Score!");
            string fileContent = "" + highScore;
            
            if (!Directory.Exists(Application.dataPath + DATA_DIR))
            {
                Directory.CreateDirectory(Application.dataPath + DATA_DIR);
            }
            
            File.WriteAllText(DATA_FULL_HS_FILE_PATH, fileContent);
        }
    }

    public TextMeshProUGUI scoretext; //text component to set score

    private const string DATA_DIR = "/Data/";
    private const string DATA_HS_FILE = "highscores.txt";

    private string DATA_FULL_HS_FILE_PATH;



    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        DATA_FULL_HS_FILE_PATH = Application.dataPath + DATA_DIR + DATA_HS_FILE;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        // update the text with score and level
        scoretext.text = "Level: " + currentLevel +
                         "\nTime to target: " + Math.Round(timer,4) + " s" +
                         "\nScore: " + Score +
                         "\nHigh Score: " +  HighScore; 
        
        if (sceneTrig == targetTrig)
        {
            currentLevel++;
            SceneManager.LoadScene(currentLevel);
            targetTrig += 1;
        }
    }
}