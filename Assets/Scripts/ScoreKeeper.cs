using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    // singleton pattern
    public static ScoreKeeper instance;

    public Text streakText;
    public Text maxStreakText;

    public int currStreak;
    public int maxStreak;

	// Use this for initialization
	void Start () {
        if(instance == null)
        {
            instance = this;
            UpdateStreakText();
            UpdateMaxStreakText();
        }
        else
        {
            // FIXME Throw an exception or something?
            Debug.Log("Already have a ScoreKeeper instance!");
        }
    }

    public void IncreaseStreak()
    {
        currStreak++;
        if(currStreak > maxStreak)
        {
            maxStreak = currStreak;
            UpdateMaxStreakText();
        }
        UpdateStreakText();
    }

    public void EndStreak()
    {
        currStreak = 0;
        UpdateStreakText();
    }

    public void UpdateStreakText()
    {
        streakText.text = currStreak.ToString();
    }

    public void UpdateMaxStreakText()
    {
        maxStreakText.text = string.Format("Best Streak: {0}", maxStreak);
    }
    
}
