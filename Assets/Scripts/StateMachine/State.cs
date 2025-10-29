using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class State
{
    public State() { }
    public virtual void StateEntry() { Debug.LogWarning($"Entered into {this.GetType()} state"); }
    public abstract IEnumerator UpdateState(ICommand input);
    public virtual void StateExit() { }
}
