using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class TheMachine : MonoBehaviour
{
    public StateMachine stateMachine = new StateMachine();

    public static FirstPersonController fpc;
    public static CharacterController cc;
    public static Camera bC;

    public ButtonManager uiMan;


    private void Start()
    {
        stateMachine.ChangeState(new MainMenu());
        fpc = FindObjectOfType<FirstPersonController>();
        cc = FindObjectOfType<CharacterController>();
        bC = FindObjectOfType<BenchCam>().gameObject.GetComponent<Camera>();
        uiMan = FindObjectOfType<ButtonManager>();
    }

    private void Update()
    {
        stateMachine.Update();
    }

    public void ExitWorkBench()
    {
        FindObjectOfType<WorkBenchInteract>().inBench = false;
        stateMachine.ChangeState(new Walking());
    }
}

public interface GameState
{
    void EnterState();
    void ActiveState();
    void ExitState();
}

public class StateMachine
{
    public GameState currentState;

    public void ChangeState(GameState newState)
    {
        if (currentState != null)
        {
            currentState.ExitState();
        }

        currentState = newState;
        currentState.EnterState();
    }

    public void Update()
    {
        if (currentState != null)
        {
            currentState.ActiveState();
        }
    }
}

public class MainMenu : GameState
{
    public void EnterState()
    {
        TheMachine.fpc = TheMachine.FindObjectOfType<FirstPersonController>();
        TheMachine.fpc.enabled = false;
        
    }

    public void ActiveState()
    {

    }

    public void ExitState()
    {

    }
}

public class Walking : GameState
{
    public void EnterState()
    {
        TheMachine.fpc.enabled = true;
        Cursor.visible = false;
    }

    public void ActiveState()
    {

    }

    public void ExitState()
    {

    }
}

public class GunBuildingMenu : GameState
{
    public void EnterState()
    {
        TheMachine.fpc.enabled = false;
        TheMachine.cc.enabled = false;
        TheMachine.bC.depth = 1;
        GameObject.FindObjectOfType<ButtonManager>().OpenCrafting();
        Cursor.visible = true;
    }

    public void ActiveState()
    {

    }

    public void ExitState()
    {
        GameObject.FindObjectOfType<ButtonManager>().CloseCrafting();
        Cursor.visible = false;
        TheMachine.fpc.enabled = true;
        TheMachine.cc.enabled = true;
        TheMachine.bC.depth = -1;


    }
}

public class GunRange : GameState
{
    public void EnterState()
    {
        TheMachine.fpc.enabled = true;
    }

    public void ActiveState()
    {

    }

    public void ExitState()
    {

    }
}

