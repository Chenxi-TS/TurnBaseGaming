using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager: IPartyAccess
{
    Dictionary<string, Unit> partyMembers;

    Dictionary<string, Unit> IPartyAccess.Party() { return partyMembers; }

    public PartyManager() 
    {
        partyMembers = new Dictionary<string, Unit>();
    }
    public void Addmember(Unit newUnit)
    {
        if (partyMembers.ContainsKey(newUnit.UnitId))
            return;
        partyMembers.Add(newUnit.UnitId, newUnit);
    }
    public void Removemember(Unit newUnit)
    {
        if (!partyMembers.ContainsKey(newUnit.UnitId))
            return;
        partyMembers.Remove(newUnit.UnitId);
    }
}
