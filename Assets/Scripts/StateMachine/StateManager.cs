using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateManager
{
    protected State[] stateOrder;
    protected Stack<State> stateStack = new Stack<State>();
    protected int currentStateOrderIndex;

    protected InputHandler inputHandler;
    protected ICommand input;
    public StateManager(InputHandler inputHandler)
    {
        this.inputHandler = inputHandler;
    }

    public virtual void UpdateCurrentState()
    {
        input = inputHandler.GetInput();
        stateStack.First().UpdateState(input);
    }
}
