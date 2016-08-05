using UnityEngine;
using System.Collections;

public class HighScoreSystem : MonoBehaviour {

	private static int score;
    private static string highScoreKey = "HighScore";

    //Add Point
    public static void AddPoint()
    {
        score++;
    }

    //Get Score
    public static int GetScore()
    {
        return score;
    }

    //Set new High Score
    public static void SetHighScore(int newScore)
    {
        if (newScore > GetHighScore())
        {
            PlayerPrefs.SetInt(highScoreKey, newScore);
        }
    }

    //Get the current High Score
    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt(highScoreKey);
    }

    //Resets the score back to 0
    public static void ResetScore()
    {
        score = 0;
    }



}
