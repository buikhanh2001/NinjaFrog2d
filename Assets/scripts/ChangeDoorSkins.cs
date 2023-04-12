using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDoorSkins : MonoBehaviour
{
    public GameObject skinsPpanel;
    private bool inDoor = false;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            skinsPpanel.gameObject.SetActive(true);
            inDoor = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        skinsPpanel.gameObject.SetActive(false);
        inDoor = false;
    }
    public void SetPlayerFrog()
    {
        PlayerPrefs.SetString("PlayerSelected", "Frog");
        ResetLayerSkin();
    }
    public void SetPlayerMaskDude()
    {
        PlayerPrefs.SetString("PlayerSelected", "MaskDue");
        ResetLayerSkin();
    }
    public void SetPlayerPinkMan()
    {
        PlayerPrefs.SetString("PlayerSelected", "PinkMan");
        ResetLayerSkin();
    }
    public void SetPlayerVirtualGuy()
    {
        PlayerPrefs.SetString("PlayerSelected", "VitrualGuy");
        ResetLayerSkin();
    }
    void ResetLayerSkin()
    {
        skinsPpanel.gameObject.SetActive(false);
        player.GetComponent<PlayerSelect>().ChangePlayerInMenu();
    }
}
