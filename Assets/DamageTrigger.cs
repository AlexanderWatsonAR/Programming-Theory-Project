using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    [SerializeField] private float m_Damage;
    public float Damage { get { return m_Damage; } set { m_Damage = value; } }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerController player))
        {
            player.HitPoints -= m_Damage;
            Destroy(gameObject);
            return;
        }
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.HitPoints -= m_Damage;
            Destroy(gameObject);
            return;
        }
        
    }

}
