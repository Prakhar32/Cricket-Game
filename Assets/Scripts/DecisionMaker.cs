using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionMaker : MonoBehaviour
{
    public GameObject Stumps;
    public GameObject Bat;
    public GameObject MissZone;
    public GameObject runSelectionPanel;
    public TileBehaviour cachedBehaviour;
    public BallType ballType;
    public GameObject ball;

    private GameManager gameManager;
    private MenuUpdater menuUpdater;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
        menuUpdater = GetComponent<MenuUpdater>();
    }
    public void SetBallType(string ballType)
    {
        System.Enum.TryParse<BallType>(ballType, out this.ballType);
    }

    public void SelectRunToScore(TileBehaviour tileBehaviour)
    {
        Time.timeScale = 0;
        cachedBehaviour = tileBehaviour;
        menuUpdater.UpdateBallTypeSelected(ballType, tileBehaviour);
        runSelectionPanel.SetActive(true);
    }

    public void MakeDecision(int runSelected)
    {
        Time.timeScale = 1;
        float probability = cachedBehaviour.GetProbability(runSelected, ballType);
        float result = Random.Range(0, 10.0f) / 10;
        if (result <= probability)
            Success(runSelected);
        else
        {
            int fatalProbability = Random.Range(0, 2);
            if (fatalProbability == 0)
                FailureFatal();
            else
                FailureNonFatal();
        }
        cachedBehaviour = null;
    }

    public void Success(int runSelected)
    {
        ball.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1.5f, 0), ForceMode.VelocityChange);
        ball.GetComponent<Trajectory>().StartMotion(Bat);
        Bat.GetComponent<BatBehaviour>().SetBatState(1);
        gameManager.addRuns(runSelected);
    }

    public void FailureFatal()
    {
        ball.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1.5f, 0), ForceMode.VelocityChange);
        ball.GetComponent<Trajectory>().StartMotion(Stumps);
        Bat.GetComponent<BatBehaviour>().SetBatState(2);
        gameManager.takeWickets();
    }

    public void FailureNonFatal()
    {
        ball.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1.5f, 0), ForceMode.VelocityChange);
        ball.GetComponent<Trajectory>().StartMotion(MissZone);
        Bat.GetComponent<BatBehaviour>().SetBatState(2);
        gameManager.consumeBalls();
    }
}
