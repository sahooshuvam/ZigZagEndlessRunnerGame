using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoreText;

    public void ScoreUpdate(int scoreValue)
    {
        score = score + scoreValue;
        Debug.Log("Score: " + score);
        scoreText.text = score.ToString();
    }
        

}
