using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreBase : MonoBehaviour
{
    public string Name;


    public virtual void JumpAction(player PlayerInstance) { }
    public virtual void StartAction(player PlayerInstance) { }

    public virtual void TakeDamageAction(player PlayerInstance) { }
    public virtual void AttackAction(WeaponBase WeaponInstance, player PlayerInstance)

}
