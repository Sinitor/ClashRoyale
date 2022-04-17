using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHP : MonoBehaviour
{
    public Slider towerSlider;
    private float health;
    [SerializeField] float maxHealth;

    private void Start()
    {
        towerSlider.maxValue = maxHealth;
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
    private void OnGUI()
    {
        float t = Time.deltaTime / 0.1f;
        towerSlider.value = Mathf.Lerp(towerSlider.value, health, t);
    }
}
