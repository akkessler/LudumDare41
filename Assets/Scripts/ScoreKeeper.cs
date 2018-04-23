using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    // singleton pattern
    public static ScoreKeeper instance;

    public Text scoreText;

    public int totalPoints;
    public int currStreak;
    public int maxStreak;

	// Use this for initialization
	void Start () {
        if(instance == null)
        {
            instance = this;
            UpdateScoreText();
        }
        else
        {
            // FIXME Throw an exception or something?
            Debug.Log("Already have a ScoreKeeper instance!");
        }
    }

    public void IncreaseStreakAndPoints(int points)
    {
        totalPoints += points;
        currStreak++;
        if(currStreak > maxStreak)
        {
            maxStreak = currStreak;
        }
        UpdateScoreText();
    }

    public void EndStreak()
    {
        currStreak = 0;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = string.Format("Score: {0}\n\nMax Streak: {1}\n\nStreak: {2}", totalPoints, maxStreak, currStreak);
    }
}
