using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{

    public Animator playerAnim;
    public float attackDelay;
    public float weaponRange;
    public int weaponDamage;
    public LayerMask enemyLayer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        playerAnim.Play("Attack");
        Collider2D enemy = Physics2D.OverlapCircle(transform.position, weaponRange, enemyLayer);
        yield return new WaitForSeconds(attackDelay);
        if (enemy != null)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(weaponDamage);
        } else
        {
            Debug.Log("No enemy in range");
        }
        
    }
}
