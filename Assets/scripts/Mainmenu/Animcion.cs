using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animcion : MonoBehaviour
{
    [SerializeField] private GameObject logo;
    [SerializeField] private GameObject iniciLogo;
    [SerializeField] private GameObject MenuExtra;
    [SerializeField] private RectTransform fondoNegro;
    [SerializeField] private GameObject acepstaeSalirjuego;
    private void Start()
    {
        LeanTween.moveX(logo.GetComponent<RectTransform>(), 0, 1.5f).setDelay(2.5f).setEase(LeanTweenType.easeInOutBounce).setOnComplete(BajarAlpha);
    }
    private void BajarAlpha()
    {
        LeanTween.alpha(iniciLogo.GetComponent<RectTransform>(), 0f, 1f).setDelay(0.5f);
        iniciLogo.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void activeMenuExtra()
    {
        LeanTween.moveY(MenuExtra.GetComponent<RectTransform>(), -170f, 1f).setEase(LeanTweenType.easeInOutElastic);
    }
    public void AbriMenuSalir()
    {
        LeanTween.scale(acepstaeSalirjuego.GetComponent<RectTransform>(), new Vector3(1, 1, 1), 0.5f).setDelay(0.5f).setEase(LeanTweenType.easeInOutBounce);
        LeanTween.alpha(fondoNegro, 0.5f, 1f);
    }
    public void CarrarMenuSalir()
    {
        LeanTween.scale(acepstaeSalirjuego.GetComponent<RectTransform>(), new Vector3(0, 0, 0), 0.5f);
        LeanTween.alpha(fondoNegro.GetComponent<RectTransform>(), 0f, 0.5f);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
