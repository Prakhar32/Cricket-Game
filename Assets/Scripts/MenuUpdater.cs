using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuUpdater : MonoBehaviour
{
    public TextMeshProUGUI DelieveryType;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI ScoreLeft;
    public TextMeshProUGUI Wickets;
    public TextMeshProUGUI BallsLeft;
    public TextMeshProUGUI ResultDisplayer;

    public void UpdateBallTypeSelected(BallType ballType, TileBehaviour tileBehaviour)
    {
        DelieveryType.text = ballType.ToString() + " " + tileBehaviour.Label;
    }

    public void UpdateInformation(int score, int wickets, int needed, int ballsLeft)
    {
        Score.text = "Score : " + score;
        ScoreLeft.text = "Remaining : " + needed;
        Wickets.text = "Wickets : " + wickets;
        BallsLeft.text = ballsLeft / 6 + " overs " + ballsLeft % 6 + " balls";
    }

    public void WinConditionMet()
    {
        ResultDisplayer.gameObject.SetActive(true);
        ResultDisplayer.text = " You Win";
    }

    public void LoseConditionMet()
    {
        ResultDisplayer.gameObject.SetActive(true);
        ResultDisplayer.text = "You Lose";
    }
}
