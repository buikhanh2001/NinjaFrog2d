using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end : MonoBehaviour
{
    private bool levelCompleted = false;
    public GameObject level;
    // Start is called before the first frame update
    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
         
            levelCompleted = true;
            level.gameObject.SetActive(true);
        }

    }
}
