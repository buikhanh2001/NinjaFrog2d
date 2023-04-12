using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject[] skins;
    public int selecterCharacter;
    private void Awake()
    {
        selecterCharacter = PlayerPrefs.GetInt("selecterCharacter", 0);
        foreach (GameObject Player in skins)
            Player.SetActive(false);
        skins[selecterCharacter].SetActive(true);
    }
    public void changeNext()
    {
        skins[selecterCharacter].SetActive(false);
        selecterCharacter++;
        if (selecterCharacter == skins.Length)
            selecterCharacter = 0;
        skins[selecterCharacter].SetActive(true);
        PlayerPrefs.SetInt("selecterCharacter", selecterCharacter);
    }
    public void changeprevious()
    {
        skins[selecterCharacter].SetActive(false);
        selecterCharacter--;
        if (selecterCharacter == -1)
            selecterCharacter = skins.Length -1;
        skins[selecterCharacter].SetActive(true);
        PlayerPrefs.SetInt("selecterCharacter", selecterCharacter);
    }
}
