using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PhaseManager : StateManager
{
    BeginningPhase beginning;
    SelectionPhase selection;
    ActionPhase action;
    EnemyPhase enemyAction;

    public PhaseManager(InputHandler inputHandler, IPartyAccess partyManager) : base(inputHandler)
    {
        beginning = new BeginningPhase(partyManager);
        selection = new SelectionPhase();
        action = new ActionPhase();
        enemyAction = new EnemyPhase();

        stateOrder = new State[4]{
            beginning,
            selection,
            action,
            enemyAction };
        currentStateOrderIndex = 0;

        Debug.LogWarning("Phase Manager Initialized");
    }

    public override void UpdateCurrentState()
    {
        base.UpdateCurrentState();
    }
}
