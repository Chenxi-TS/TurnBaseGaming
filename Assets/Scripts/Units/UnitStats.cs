using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Unit/Stats")]
public class UnitStats : ScriptableObject
{
    public string UniqueId;
    public float MaxHealth;

    public float Health;
}
