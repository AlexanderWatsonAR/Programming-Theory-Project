using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FleeState : BehaviourState
{

    public FleeState(PlayerController player, Enemy enemy) : base(player, enemy)
    {
        
    }

    public override void Attack()
    {
        //
    }

    public override void Movement()
    {
        Vector3 dirAwayFromPlayer = Extensions.DirectionToTarget(m_Player.transform.position, m_Enemy.transform.position);
        m_Enemy.transform.forward = dirAwayFromPlayer;
        m_EnemyController.Move(m_Enemy.MovementSpeed * Time.deltaTime * dirAwayFromPlayer);

    }
}
