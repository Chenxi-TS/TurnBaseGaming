using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Unit
{
    protected UnitStats unitStats;
    protected IStatusEffectCreateAccess statusEffectFactoryAccess;
    protected List<StatusEffect> appliedStatusEffects;
    public string UnitId { get { return unitStats.UniqueId; } }
    
    public Unit(UnitStats unitStats, IStatusEffectCreateAccess statusFactoryAccess)
    {
        this.unitStats = unitStats;
        this.statusEffectFactoryAccess = statusFactoryAccess;

        Debug.Log($"Unit_Constructor_'{unitStats.UniqueId} constructed_'" +
            $"MaxHealth: {unitStats.MaxHealth}");
    }

    protected Unit(UnitStats unitStats)
    {
        this.unitStats = unitStats;
    }

    public virtual IEnumerator ResolveStatusEffects()
    {
        yield break;
    }
    public abstract IEnumerator ResolveBeginningAbility();

    public virtual IEnumerator ResolveGotAttacked(AttackStats attack)
    {
        unitStats.Health -= attack.Damage;
        Debug.Log($"{unitStats.UniqueId} took {attack.Damage}" +
            $"New health: {unitStats.Health}");
        if (attack.StatusEffectStats.Count() > 0)
        {
            Debug.LogWarning("Unit_ResolveGotAttacked_Apply status effects here (placeholder)");
            foreach (StatusEffectStats statusEffectStats in attack.StatusEffectStats)
            {
                appliedStatusEffects.Add(statusEffectFactoryAccess.Create(statusEffectStats));
            }
            //Apply Status and play Status application animation
            //Unit should hold reference to which StatusEffect is on them now
            //By creating new StatusEffect through StatusEffectFactory.Create(attack.StatusEffectStat)
            //But where should StatusEffectFactory be? Another static INSTANCE created in gamemanager?

        }
        yield return null;

    }
    public virtual IEnumerator CheckForDeath() 
    {
        if (unitStats.Health <= 0)
            yield return OnDeath();
        Debug.Log($"{unitStats.UniqueId}[{this.GetType()}] has died.");
    }
    public abstract IEnumerator OnDeath();
}


//EVENT CONSTRUCTORS
namespace GameEvents.Combat
{
    struct OnGotAttacked: IEvent
    {
        public Unit Victim;
        public AttackStats Attack;
        public OnGotAttacked(Unit victim, AttackStats attack)
        {
            this.Victim = victim;
            this.Attack = attack;
        }
    }
}
