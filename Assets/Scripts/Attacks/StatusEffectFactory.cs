using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class StatusEffectFactory
{
    Dictionary<StatusEffectTypes, Func<StatusEffectStats, StatusEffect>> StatusReceipt = new Dictionary<StatusEffectTypes, Func<StatusEffectStats, StatusEffect>>();

    public StatusEffectFactory()
    {
        Register(StatusEffectTypes.Burn, StatusStats => { return new BurnStatus(StatusStats); } );
    }


    void Register(StatusEffectTypes type, Func<StatusEffectStats, StatusEffect> creationSignature)
    {
        if(StatusReceipt.ContainsKey(type))
            Delegate.Combine(StatusReceipt[type], creationSignature);
        else
            StatusReceipt.Add(type, creationSignature);
    }

    public StatusEffect Create(StatusEffectStats statusEffectStats)
    {
        Debug.Assert(StatusReceipt.ContainsKey(statusEffectStats.StatusEffectType));
        return StatusReceipt[statusEffectStats.StatusEffectType](statusEffectStats);
    }
}
public interface IStatusEffectCreateAccess
{
    StatusEffect Create(StatusEffectStats stats);
}