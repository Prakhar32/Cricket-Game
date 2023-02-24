using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject ball;
    [SerializeField]
    private GameObject spawnLoaction;
    [SerializeField]
    private GameObject ballTypeSelectionPanel;
    [SerializeField]
    private BatBehaviour bat;
    [SerializeField]
    private StumpBehaviour stump;

    private DecisionMaker decisionMaker;
    private MenuUpdater menuUpdater;

    private int ballsLeft;
    private int runsRequired;
    private int currentScore;
    private int wicketsLeft;

    // Start is called before the first frame update
    void Start()
    {
        decisionMaker = GetComponent<DecisionMaker>();
        menuUpdater = GetComponent<MenuUpdater>();
        ball.GetComponent<Rigidbody>().isKinematic = true;
        ballsLeft = 30;
        runsRequired = 50;
        wicketsLeft= 5;
    }

    public void addRuns(int runs)
    {
        currentScore += runs;
        consumeBalls();
        MakeStateChanges();
    }

    public void takeWickets()
    {
        wicketsLeft--;
        consumeBalls();
        MakeStateChanges();
    }

    public void consumeBalls()
    {
        ballsLeft--;
        MakeStateChanges();
    }

    private void MakeStateChanges()
    {
        if (runsRequired - currentScore <= 0) { menuUpdater.WinConditionMet(); }
        else if (ballsLeft == 0 || wicketsLeft == 0) { menuUpdater.LoseConditionMet(); }
        else StartCoroutine(ResetWorld());
    }

    IEnumerator ResetWorld()
    {
        yield return new WaitForSeconds(2);
        menuUpdater.UpdateInformation(currentScore, wicketsLeft, runsRequired - currentScore, ballsLeft);
        yield return new WaitForSeconds(2);
        ball.GetComponent<Trajectory>().target = null;
        ball.transform.position = spawnLoaction.transform.position;
        ball.GetComponent<Rigidbody>().isKinematic = true;
        ballTypeSelectionPanel.SetActive(true);
        bat.SetBatState(0);
        bat.GetComponent<BoxCollider>().enabled = true;
        stump.SetStumpState(false);
    }
}
