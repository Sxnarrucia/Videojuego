using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    public static bool checkCollision;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Terrain")) checkCollision = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Terrain")) checkCollision = false;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
