using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public GameObject impactEffect;

    public float speed = 2f;
    public void Seek( Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        } 

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime; 

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    } 

    private void HitTarget()
    {
       GameObject effectInc = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
       Destroy(effectInc, 2f);

       Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerHero")
        {
            collision.gameObject.GetComponent<HeroesHP>().UpdateHP(-10);
        }
    }
}
