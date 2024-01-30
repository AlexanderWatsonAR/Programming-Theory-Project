using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    [SerializeField] GameObject m_Projectile;
    [SerializeField] Vector3 m_LocalSpawnPosition;
    [SerializeField] float m_ProjectileSpeed;
    [SerializeField] float m_ProjectileDamage;
    [SerializeField] float m_AmmoCapacity;

    protected override void Use()
    {
        GameObject projectileClone = Instantiate(m_Projectile);
        Vector3 worldPos = transform.TransformPoint(m_LocalSpawnPosition);
        projectileClone.transform.position = worldPos;
        Rigidbody body = projectileClone.GetComponent<Rigidbody>();
        body.velocity = transform.right * m_ProjectileSpeed;
        Destroy(projectileClone, 10f);

    }



}
