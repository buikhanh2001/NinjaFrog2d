using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    public bool enableSelectCharacter;
    public enum Player { Frog, VitrualGuy, PinkMan, MaskDue};
    public Player Playerselected;
    public Animator anim;
    public SpriteRenderer spriteRenderer;
    public RuntimeAnimatorController[] playercontroller;
    public Sprite[] playerRenderer;
    void Start()
    {
        if (!enableSelectCharacter)
        {
            ChangePlayerInMenu();
        }
        else
        {
            switch (Playerselected)
            {
                case Player.Frog:
                    spriteRenderer.sprite = playerRenderer[0];
                    anim.runtimeAnimatorController = playercontroller[0];
                    break;
                case Player.PinkMan:
                    spriteRenderer.sprite = playerRenderer[1];
                    anim.runtimeAnimatorController = playercontroller[1];
                    break;
                case Player.VitrualGuy:
                    spriteRenderer.sprite = playerRenderer[2];
                    anim.runtimeAnimatorController = playercontroller[2];
                    break;
                case Player.MaskDue:
                    spriteRenderer.sprite = playerRenderer[3];
                    anim.runtimeAnimatorController = playercontroller[3];
                    break;
                default:
                    break;
            }
        }
        
    }
    public void ChangePlayerInMenu()
    {
        switch (PlayerPrefs.GetString("PlayerSelected"))
        {
            case "Frog":
                spriteRenderer.sprite = playerRenderer[0];
                anim.runtimeAnimatorController = playercontroller[0];
                break;
            case "PinkMan":
                spriteRenderer.sprite = playerRenderer[1];
                anim.runtimeAnimatorController = playercontroller[1];
                break;
            case "VitrualGuy":
                spriteRenderer.sprite = playerRenderer[2];
                anim.runtimeAnimatorController = playercontroller[2];
                break;
            case "MaskDue":
                spriteRenderer.sprite = playerRenderer[3];
                anim.runtimeAnimatorController = playercontroller[3];
                break;
            default:
                break;
        }
    }
}
