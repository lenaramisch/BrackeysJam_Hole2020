using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheeseHealth : MonoBehaviour
{
    public GameObject gameManager;
    public int maxHealth;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
       if (currentHealth <= 0)
        {
            gameManager.GetComponent<SceneLoader>().LoadScene("GameOver");
        }
       
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
