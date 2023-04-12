using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FruitCollected : MonoBehaviour
{
    public AudioSource clip;
    [SerializeField] private float cantidasPuntos;
    [SerializeField] private Fruitstext fruitstext;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            fruitstext.SumarPuntos(cantidasPuntos);
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject, 0.5f);
            clip.Play();
            
        }
    }
}
