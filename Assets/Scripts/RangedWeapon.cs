using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : Weapon
{
    [SerializeField] GameObject projectile;
    [SerializeField] Vector3 localSpawnPosition;
    [SerializeField] float projectileSpeed;
    [SerializeField] float projectileDamage;
    [SerializeField] float ammoCapacity;

    protected override void Use()
    {
        GameObject projectileClone = Instantiate(projectile);
        Vector3 worldPos = transform.TransformPoint(localSpawnPosition);
        projectileClone.transform.position = worldPos;
        Rigidbody body = projectileClone.GetComponent<Rigidbody>();
        body.velocity = PlayerController.Direction * projectileSpeed;

    }



}
