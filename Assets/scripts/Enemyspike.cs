using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspike : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player Damager");
            collision.transform.GetComponent<PlayerRespawn>().PlayerDamage();
        }
    }
}
