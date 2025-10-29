using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour
{
    [SerializeField]
    UnitStats test_Unit1Stats;
    [SerializeField]
    AttackStats test_Attack1Stats;

    Unit test_Unit1;
    public void Start()
    {
        test_Unit1 = new TestAlly1(test_Unit1Stats);
        GameManager.INSTANCE.PartyManager.Addmember(test_Unit1);
    }

    public void Update()
    {
        if (GameManager.INSTANCE.InputHander.GetInput() is ConfirmCommand)
        {
            Debug.Log("DebugScript_Update_ConfirmCommand Found");
            StartCoroutine(test_Unit1.ResolveGotAttacked(test_Attack1Stats));
        }
    }
}
