using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBat : MonoBehaviour
{
    [SerializeField] public Transform jugador;
    [SerializeField] private float distancia;
    public Vector3 puntoIncial;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        anim = GetComponent<Animator>();
        puntoIncial = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    private void Update()
    {
        distancia = Vector2.Distance(transform.position, jugador.position);
        anim.SetFloat("Distancia", distancia);
    }
    public void Ginar(Vector3 objetivo)
    {
        if(transform.position.x < objetivo.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
