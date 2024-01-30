using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TODO: If enemy is at grater than 20 percent health use chase behaviour state,
// otherwise use flee behaviour state.

public class Enemy : MonoBehaviour
{
    [SerializeField] Weapon m_Weapon;
    [SerializeField] float m_HitPoints;
    [SerializeField] float m_MovementSpeed;

    float m_MaxHitPoints;
    ChaseState m_ChaseState;
    FleeState m_FleeState;
    BehaviourState m_ActiveState;

    public float MovementSpeed => m_MovementSpeed;
    public Weapon Weapon => m_Weapon;

    public float HitPoints
    {
        get { return m_HitPoints; }
        set 
        {
            m_HitPoints = value;

            if(m_HitPoints <= (m_MaxHitPoints * 0.2f))
            {
                m_ActiveState = m_FleeState;
            }

            if(m_HitPoints == m_MaxHitPoints)
            {
                m_ActiveState = m_ChaseState;
            }
        }
    }

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerController controller = player.GetComponent<PlayerController>();

        m_ChaseState = new ChaseState(controller, this);
        m_FleeState = new FleeState(controller, this);
        m_ActiveState = m_ChaseState;
        
        m_MaxHitPoints = m_HitPoints;
    }

    // Update is called once per frame
    void Update()
    {
        m_ActiveState.Movement();
        m_ActiveState.Attack();
    }
}
