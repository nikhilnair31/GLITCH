﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public int score;        // The player's score.
    public Text text;                      // Reference to the Text component.

    void Awake ()
    {
        // Reset the score.
        score = 0;
    }

    void Update ()
    {
        // Set the displayed text to be the word "Score" followed by the score value.
        text.text = "" + score;
    }
}
