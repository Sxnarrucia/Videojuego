using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAttack : MonoBehaviour
{
    public Animator playerAnim;
    public GameObject projectilePrefab; // Prefab del proyectil.
    public Transform firePoint; // Punto desde donde se disparará el proyectil.
    public float projectileSpeed; // Velocidad del proyectil.
    public int weaponDamage; // Daño del proyectil.

    private bool facingRight = true; // Indica si el personaje está mirando a la derecha.

    void Update()
    {
        // Movimiento del personaje y detección de cambio de dirección.
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (facingRight)
            {
                Flip();
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (!facingRight)
            {
                Flip();
            }
        }

        // Disparar al presionar el botón Fire2.
        if (Input.GetButtonDown("Fire2"))
        {
            Disparar();
        }
    }

    private void Disparar()
    {
        // Verificar que el punto de disparo y el prefab están asignados.
        if (firePoint == null || projectilePrefab == null)
        {
            Debug.LogError("FirePoint or ProjectilePrefab is not assigned.");
            return;
        }

        // Reproducir animación de disparo si existe.
        if (playerAnim != null)
        {
            playerAnim.Play("Shoot");
        }

        // Instanciar el proyectil en la posición y rotación del firePoint.
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Configurar el daño del proyectil.
        Projectile projectileScript = projectile.GetComponent<Projectile>();
        if (projectileScript != null)
        {
            projectileScript.damage = weaponDamage;
        }
        else
        {
            Debug.LogError("Projectile prefab does not have a Projectile script.");
        }

        // Configurar la dirección y velocidad del proyectil.
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Definir dirección según el personaje
            Vector2 direction = facingRight ? Vector2.right : Vector2.left; // Dirección según orientación.
            rb.velocity = direction * projectileSpeed; // Aplicar la velocidad del proyectil.
        }
        else
        {
            Debug.LogError("Projectile prefab does not have a Rigidbody2D component.");
        }

        // Destruir el proyectil después de 5 segundos.
        Destroy(projectile, 5f);
    }

    private void Flip()
    {
        // Cambiar la orientación del personaje.
        facingRight = !facingRight;

        // Cambiar la rotación del firePoint para reflejar la nueva dirección del personaje.
        if (firePoint != null)
        {
            // Invertir la rotación del firePoint según la dirección del personaje
            firePoint.rotation = facingRight ? Quaternion.identity : Quaternion.Euler(0f, 180f, 0f);
        }
    }
}
