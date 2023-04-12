using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitsManager : MonoBehaviour
{
    public GameObject levelCleared;

    /*public GameObject transtion;*/

    public Text totalFruits;
    public Text fruitsCollected;
    private int totalFruitsInlevel;

    private void Start()
    {
        totalFruitsInlevel = transform.childCount;
    }
    private void Update()
    {
        AllFruitsCollected();
        totalFruits.text = totalFruitsInlevel.ToString();
        fruitsCollected.text = transform.childCount.ToString();
    }
    public void AllFruitsCollected()
    {
        if(transform.childCount == 0)
        {
            /*levelCleared.gameObject.SetActive(true);*/
            /*transtion.SetActive(true);*/
            /*Invoke("changeScene", 2);*/
        }
    }
    
    public void changeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
}
