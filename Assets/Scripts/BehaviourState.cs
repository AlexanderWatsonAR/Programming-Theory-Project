using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviourState
{
    protected PlayerController m_Player;
    protected Enemy m_Enemy;
    protected CharacterController m_EnemyController;

    public BehaviourState(PlayerController controller, Enemy enemy)
    {
        m_Player = controller;
        m_Enemy = enemy;
        m_EnemyController = m_Enemy.GetComponent<CharacterController>();
    }

    public abstract void Movement();
    public abstract void Attack();

}
