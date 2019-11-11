using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheMachine : MonoBehaviour
{
    StateMachine stateMachine = new StateMachine();

    private void Start()
    {
        stateMachine.ChangeState(new MainMenu());
    }

    private void Update()
    {
        stateMachine.Update();
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
    GameState currentState;

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

    }

    public void ActiveState()
    {

    }

    public void ExitState()
    {

    }
}

public class GunRange : GameState
{
    public void EnterState()
    {

    }

    public void ActiveState()
    {

    }

    public void ExitState()
    {

    }
}

