using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroesHP : MonoBehaviour
{
    private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] private float attackDamage = 10;
    [SerializeField] private float attackSpeed = 0.5f;
    private float canAttack;

    private void Start()
    {
        health = maxHealth;
    }
    public void UpdateHP(float mod)
    {
        health += mod;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health <= 0f)
        {
            health = 0f;
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Tower")
        {
            if (attackSpeed <= canAttack)
            {
                collision.gameObject.GetComponent<TowerHP>().UpdateHP(-attackDamage);
                canAttack = 0f;
            }
            else
            {
                canAttack += Time.deltaTime;
            }
        }
    }
}
