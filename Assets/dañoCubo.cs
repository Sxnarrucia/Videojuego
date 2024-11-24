using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dañoCubo : MonoBehaviour
{

    public int damage;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.CompareTag("Player")) {
			GameManager.Instance.PerderVida(damage);
		}
	}

}
