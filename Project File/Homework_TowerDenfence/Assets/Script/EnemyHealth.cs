using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
    public float InitHealth = 100;      //初始生命值
    private float currentHealth;        //当前生命值
    public Image hpBar;                 //血条

    void Start () {
        currentHealth = InitHealth;
	}
	
	void Update () {
		
	}
    public void Damage(float amount)
    {
        currentHealth -= amount;
        hpBar.fillAmount = currentHealth / InitHealth;
        if (currentHealth <= 0)
        {
            EnemySpawner.EnemyAlive--;
            Destroy(gameObject);
        }
    }
    //private void EnemyDie()
    //{
    //    EnemySpawner.EnemyAlive--;
    //    GameObject effect = Instantiate(deadEffect, transform.position, Quaternion.identity);
    //    Destroy(effect, 5);
    //    Destroy(gameObject);
    //}
}
