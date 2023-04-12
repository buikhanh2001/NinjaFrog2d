using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : MonoBehaviour
{
    private float waitedTime;
    public float waitTimeToAttack = 3;
    public Animator anim;
    public GameObject bulletPrefabs;
    public Transform launchSpawnPoint;
    private void Start()
    {
        waitedTime = waitTimeToAttack;
    }
    private void Update()
    {
        if (waitedTime<=0)
        {
            waitedTime = waitTimeToAttack;
            anim.Play("Attack");
            Invoke("LaunchBullet", 0.5f);
        }
        else
        {
            waitedTime -= Time.deltaTime;
        }
    }
    public void LaunchBullet()
    {
        GameObject newBulet;
        newBulet = Instantiate(bulletPrefabs, launchSpawnPoint.position, launchSpawnPoint.rotation);
    }
}
