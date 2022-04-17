using System.Collections;
using System.Collections.Generic;
using UnityEngine; 


public class Tower : MonoBehaviour
{
    private Transform target;
    public string playerTag = "PlayerHero";

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float range = 2f;
    public float fireRate = 1f;
    public float fireCountDown = 0f; 

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    } 

    private void UpdateTarget()
    {
        GameObject[] heroes = GameObject.FindGameObjectsWithTag(playerTag);
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
        if (nearestHero != null && shortestDistance <= range)
        {
            target = nearestHero.transform;
        }
        else
        {
            target = null;
        }
    }
    private void Update()
    {
        if (target == null)
        {
            return;
        }

        if (fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }
        fireCountDown -= Time.deltaTime;
    } 

    private void Shoot()
    {
       GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
       Bullet bullet = bulletGo.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
