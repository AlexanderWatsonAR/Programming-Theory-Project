using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float useSpeed;
    [SerializeField] protected bool inUse;

    public bool InUse { get { return inUse; } private set { inUse = value; } }

    public void Attack()
    {
        if (InUse)
            return;

        Use();
        InUse = true;
        Invoke(nameof(Wait), useSpeed);
    }

    private void Wait()
    {
        InUse = false;
    }

    protected abstract void Use();

}
