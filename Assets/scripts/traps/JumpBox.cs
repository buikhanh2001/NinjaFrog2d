using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBox : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer spriteRenderer;
    public GameObject brokenParts;
    public float jumpForce = 4f;
    public int life = 1;
    public GameObject boxCollider;
    public Collider2D col2d;
    public GameObject fruit;

    private void Start()
    {
        fruit.SetActive(false);
        fruit.transform.SetParent(FindObjectOfType<FruitsManager>().transform);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
            LosseLifeAndHit();
        }
    }
    public void LosseLifeAndHit()
    {
        life--;
        anim.Play("HitBox1");
        CheckLife();
    }
    public void CheckLife()
    {
        if (life < 0)
        {
            fruit.SetActive(true);
            boxCollider.SetActive(false);
            col2d.enabled = false;
            brokenParts.SetActive(true);
            spriteRenderer.enabled = false;
            Invoke("DestroyBox", 0.5f);
        }
    }
    public void DestroyBox()
    {
        Destroy(transform.parent.gameObject);
    }
}
