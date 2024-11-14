using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenTest : MonoBehaviour, IScreen
{
    public ScreenTest nextScreen;
    public void BTN_Active()
    {
        if (nextScreen != null)
            ScreenManager.instance.ActiveScreen(nextScreen);
    }

    public void BTN_Close()
    {
        ScreenManager.instance.DesactiveScreen();
    }
    public void Activate()
    {
        gameObject.SetActive(true);

        var c = GetComponent<Image>().color;

        GetComponent<Image>().color = new Color(c.r, c.g, c.b, 1f);

        foreach (var item in GetComponentsInChildren<Button>())
            item.interactable = true;
    }

    public void Desactivate()
    {
        gameObject.SetActive(false);
    }

    public void Hide()
    {
        var c = GetComponent<Image>().color;

        GetComponent<Image>().color = new Color(c.r, c.g, c.b, 0.5f);

        foreach (var item in GetComponentsInChildren<Button>())
            item.interactable = false;
    }
}
