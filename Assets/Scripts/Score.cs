using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    int leftScore, rightScore;

    // Start is called before the first frame update
    void Start()
    {
        leftScore = 0;
        rightScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool LeftScored()
    {
        leftScore++;
        Debug.Log("Left Paddle scored!");
        PrintScore();

        if (leftScore == 11)
        {
            Debug.Log("Game Over, Left Paddle Wins");
            ResetScore();
            return true;
        }
        return false;
    }

    public bool RightScored()
    {
        rightScore++;
        Debug.Log("Right scored!");
        PrintScore();

        if (rightScore == 11)
        {
            Debug.Log("Game Over, Right Paddle Wins");
            ResetScore();
            return true;
        }
        return false;
    }

    private void PrintScore()
    {
        Debug.Log($"Score: {leftScore} - {rightScore}");
    }

    private void ResetScore()
    {
        leftScore = 0;
        rightScore = 0;
    }

}
