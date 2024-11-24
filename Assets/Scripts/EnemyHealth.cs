using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int enemyHealth = 1;
    public Animator playerAnim;
    private GameObject efectoMuerte;

    public void TakeDamage(int amount)
    {
        enemyHealth -= amount;
        if (enemyHealth <= 0)
        {
            Muerte();
        }
    }

    public void Muerte(){
        if (playerAnim != null)
        {
            playerAnim.Play("MuerteEnemigo");
        }
            Destroy(gameObject);
        
    }



}
