using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffect
{
    StatusEffectTypes StatusEffectType;

    int TurnDuration;
    int TickRate;
    float DamagePerTick;
    public StatusEffect(StatusEffectStats stats)
    {
        this.StatusEffectType = stats.StatusEffectType;

        this.TurnDuration = stats.TurnDuration;
        this.TickRate = stats.TickRate;
        this.DamagePerTick = stats.DamagePerTick;
    }
    public abstract void ResolveStatusEffect();
}
