using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnemyDamager : MonoBehaviour
{
    public Collider2D collider2d;
    public Animator anim;
    public SpriteRenderer spriteRenderer;
    public GameObject destroyPartical;
    public float jumpForce = 2.5f;
    public int lifes = 2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpForce);
            LosseLifeAndHit();
            checkLife();
        }
    }
    public void LosseLifeAndHit()
    {
        lifes--;
        anim.Play("Hit");
    }
    public void checkLife()
    {
        if(lifes== 0)
        {
            destroyPartical.SetActive(true);
            spriteRenderer.enabled = false;
            Invoke("EnemyDie", 0.2f);
        }
    }
    public void EnemyDie()
    {
        Destroy(gameObject);
    }
}
