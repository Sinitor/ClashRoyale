using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Animator anim;
    public float range = 0.5f;
    public string towerTag = "Tower";
    private Transform target;
    private void Update()
    {
        float step = speed * Time.deltaTime;
        if (target != null )
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            Vector3 relativePos = target.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.rotation = rotation;
        }
        UpdateTarget();
    }
    private void UpdateTarget()
    {
        GameObject[] heroes = GameObject.FindGameObjectsWithTag(towerTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestHero = null;
        foreach (GameObject hero in heroes)
        {
            float distanceToHero = Vector3.Distance(transform.position, hero.transform.position);
            if (distanceToHero < shortestDistance)
            {
                shortestDistance = distanceToHero;
                nearestHero = hero;
            }
        }
        if (nearestHero != null)
        {
            target = nearestHero.transform;
        }
        else
        {
            target = null;
        }
        if (shortestDistance >= range)
        {
            anim.SetBool("Attack", false);
            speed = 0.5f;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tower")
        {
            anim.SetBool("Attack", true);
            speed = 0.1f;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
