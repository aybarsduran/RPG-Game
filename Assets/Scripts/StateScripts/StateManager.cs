using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public State currentState;

    // Update is called once per frame
     
    public void Update()
    {
        RunStateMachine();
    }
    public void RunStateMachine()
    {
        State nextState= currentState?.RunCurrentState();//null ise ignore et
        if(nextState != null)
        {
            SwitchToTheNextState(nextState);
        }
    }
    public void SwitchToTheNextState(State nextState)
    {
        currentState = nextState;
    }
}
