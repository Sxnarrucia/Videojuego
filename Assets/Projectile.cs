using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage; // Daño que el proyectil inflige

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Aquí verificamos si el collider que tocó al proyectil es un enemigo.
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

        if (enemyHealth != null)
        {
            // Si el proyectil toca a un enemigo, inflige daño.
            enemyHealth.TakeDamage(damage);
            Destroy(gameObject); // Destruye el proyectil después de impactar.
        }
    }
}