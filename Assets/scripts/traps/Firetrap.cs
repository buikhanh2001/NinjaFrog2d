using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firetrap : MonoBehaviour
{
    [Header("Firetrap Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    private Animator anim;
    private SpriteRenderer spriteRend;
    private bool trigger;
    private bool active;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!trigger)
                StartCoroutine(ActivateFiretrap());
            if(active)
                collision.transform.GetComponent<PlayerRespawn>().PlayerDamage();
        }
    }
    private IEnumerator ActivateFiretrap()
    {
        trigger = true;
        spriteRend.color = Color.red;
        yield return new WaitForSeconds(activationDelay);
        spriteRend.color = Color.white;
        active = true;
        anim.SetBool("activated", true);

        yield return new WaitForSeconds(activeTime);
        active = false;
        trigger = false;
        anim.SetBool("activated", false);
    }
}
