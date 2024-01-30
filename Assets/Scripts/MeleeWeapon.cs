using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] float m_Damage;
    [SerializeField] DamageTrigger m_DamageToken;
    BoxCollider m_Reach;
    public BoxCollider Reach => m_Reach;

    private void Start()
    {
        m_Reach = GetComponent<BoxCollider>();
    }

    protected override void Use()
    {
        GameObject token = Instantiate(m_DamageToken.gameObject);
        token.transform.position = transform.position;
        token.GetComponent<DamageTrigger>().Damage = m_Damage;

    }
}
