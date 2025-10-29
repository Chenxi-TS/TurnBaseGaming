using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestAlly1 : Unit
{
    public TestAlly1(UnitStats unitStats) : base(unitStats)
    {
        Debug.Log("TestAlly1_Constructor_Called");
    }

    public override IEnumerator OnDeath()
    {
        Debug.Log("Unit_OnDeath_'TestAlly1 Death'");
        yield return null;
    }

    public override IEnumerator ResolveBeginningAbility()
    {
        Debug.Log("Unit_ResolveBeginningAbility_'TestAlly1 Resolve Start of Turn Ability(s)'");
        yield return null;
    }
}
