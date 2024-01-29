using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TODO: If enemy is at grater than 20 percent health use chase behaviour state,
// otherwise use flee behaviour state.

public class Enemy : MonoBehaviour
{
    [SerializeField] Weapon weapon;
     BehaviourState behaviourState;
    [SerializeField] float health;

    private void Start()
    {
        behaviourState = new ChaseState();
    }

    // Update is called once per frame
    void Update()
    {
        behaviourState.Movement();
        behaviourState.Attack();
    }

    private void OnTriggerEnter(Collider other)
    {
    }
}
