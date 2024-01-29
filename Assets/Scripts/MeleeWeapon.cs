using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] float damage;
    [SerializeField] float fieldOfView;

    protected override void Use()
    {
        IsTargetInView();
    }

    private bool IsTargetInView()
    {
        return false;
    }
}
