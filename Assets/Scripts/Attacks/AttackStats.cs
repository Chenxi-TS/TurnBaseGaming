using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatusEffectTypes
{
    None,
    Burn,
    Freeze
}
public enum StatusEffectApplicationRate
{
    Latent = 0,
    Unlikely = 30,
    Good = 70,
    High = 90, 
    Assured = 100,
    Guaranteed = 200 //Cannot be lowered, Will always hit
}

public class AttackStats : ScriptableObject
{
    public string UniqueId;
    public float Damage;
    public StatusEffectStats[] StatusEffectStats;
}

[System.Serializable]
public class StatusEffectStats
{
    public StatusEffectTypes StatusEffectType;

    public int TurnDuration;
    public int TickRate;
    public float DamagePerTick;
}