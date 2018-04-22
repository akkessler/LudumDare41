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
	
	// Update is called once per frame
	void Update () {
		
	}

    public void IncreaseStreakAndPoints(int points)
    {
        totalPoints += points;
        currStreak++;
        UpdateScoreText();
    }

    public void EndStreak()
    {
        currStreak = 0;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = string.Format("Score: {0}\n\nStreak: {1}", totalPoints, currStreak);
    }
}
