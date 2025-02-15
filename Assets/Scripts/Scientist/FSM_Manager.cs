using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;

public class FSM_Manager : MonoBehaviour
{
    ScientistBaseState currentState;
    public ScientistIdleState idleState = new ScientistIdleState();
    public ScientistAlertedState alertedState = new ScientistAlertedState();
    public ScientistWarningState warningState = new ScientistWarningState();
    [Header("Counter Timer")]
    public float counter;
    //Idle State Variables
    [Header("Scientist Variables")]
    public float timeIdle = 5;
    public float timeChecking = 4;
    public float speed = 3;
    public Transform[] waypoints;
    public GameObject button;
    //public GameObject defeatPanel;
    public GameObject fovMesh;
    public bool isOnPlate;
    public TextMeshProUGUI tmpro;
    public KnockKnock knock;
    public FOV_Scientist fov;
    public Animator anim;

    private void Start()
    {
        currentState = idleState;

        currentState.OnAwake(this);
    }

    private void Update()
    {
        currentState.OnUpdate(this);
        if (knock.isOnChecker)
        {
            isOnPlate = true;
        }
    }

    public void SwitchState(ScientistBaseState state)
    {
        currentState.OnExit(this);
        currentState = state;
        currentState.OnAwake(this);
    }
}
