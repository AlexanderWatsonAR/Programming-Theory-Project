using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChaseState : BehaviourState
{
    public ChaseState(PlayerController player, Enemy enemy) : base(player, enemy)
    {

    }

    public override void Attack()
    {
        Vector3 dirToPlayer = Extensions.DirectionToTarget(m_Enemy.transform.position, m_Player.transform.position);

        float dotProduct = Vector3.Dot(m_Enemy.transform.forward, dirToPlayer);

        //if player is in front of the enemy.
        if (dotProduct > 0.78f)
        {

            if(Vector3.Distance(m_Enemy.transform.position, m_Enemy.transform.position) <= 2)
            {
                m_Enemy.Weapon.Attack();
            }

        }

    }

    public override void Movement()
    {
        Vector3 dirToPlayer = Extensions.DirectionToTarget(m_Enemy.transform.position, m_Player.transform.position);

        m_Enemy.transform.forward = dirToPlayer;
        m_EnemyController.Move(m_Enemy.MovementSpeed * Time.deltaTime * dirToPlayer);
    }
}
