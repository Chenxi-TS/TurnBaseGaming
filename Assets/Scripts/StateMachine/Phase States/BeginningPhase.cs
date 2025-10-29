using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginningPhase : State
{
    IPartyAccess partyAccess;
    Dictionary<string, Unit> party;
    public BeginningPhase(IPartyAccess partyAccess)
    {
        this.partyAccess = partyAccess;
        party = partyAccess.Party();
    }
    public override IEnumerator UpdateState(ICommand input)
    {
        party = partyAccess.Party();
        foreach(Unit unit in party.Values)
        {
            yield return unit.ResolveStatusEffects();
            yield return unit.CheckForDeath();
            yield return unit.ResolveBeginningAbility();
            yield return unit.CheckForDeath();
        }
    }
}
