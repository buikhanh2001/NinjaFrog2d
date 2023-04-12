using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformtempnal : MonoBehaviour
{
    [SerializeField] private float timepoEspera;
    private Rigidbody2D rb;
    [SerializeField] private float velocidadRotation;
    private Animator anim;
    private bool caida = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (caida)
        {
            transform.Rotate(new Vector3(0, 0, -velocidadRotation * Time.deltaTime));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Caida(collision));
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Suelo"))
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Caida(Collision2D collision)
    {
        anim.SetTrigger("Destivar");
        yield return new WaitForSeconds(timepoEspera);
        caida = true;
        Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), collision.transform.GetComponent<Collider2D>());
        rb.constraints = RigidbodyConstraints2D.None;
        rb.AddForce(new Vector2(0.1f, 0));
    }
}
