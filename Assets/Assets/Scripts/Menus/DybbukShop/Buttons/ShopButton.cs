using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{

    public void OnSelect()
    {
        Text text = gameObject.GetComponent<Text>();
        Color color = GetComponent<Text>().color;
        color.a = .5f;
        text.color = color;
        text.fontStyle = FontStyle.Bold;
  //      gameObject.GetComponent<Outline>().enabled = true;
        text.fontSize = 50;
        //     UI.UIevent.SetSelectedGameObject(null);
        //    UI.UIevent.SetSelectedGameObject(gameObject);
        color = GetComponent<Outline>().effectColor;
        color.a = .5f;
        GetComponent<Outline>().effectColor = color;
        gameObject.GetComponent<Animator>().enabled = true;
    }
    public void Deselect()
    {
        gameObject.GetComponent<Animator>().enabled = false;
        Text text = gameObject.GetComponent<Text>();
        Color color = GetComponent<Text>().color;
        color.a = .2f;
        text.color = color;
        text.fontStyle = FontStyle.Normal;
        text.fontSize = 40;
        color = GetComponent<Outline>().effectColor;
        color.a = .2f;
        GetComponent<Outline>().effectColor = color;
    }

    public void ExitShop()
    {
        gameObject.GetComponent<Animator>().Play("SelectButton");
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut ()
    {
        UI.screenEffect.Play("FadeOut");
        yield return new WaitForSeconds(2f);
        UI.screenEffect.Play("FadeIn");
        Text text = gameObject.GetComponent<Text>();
        Color color = GetComponent<Text>().color;
        color.a = .2f;
        text.color = color;
        text.fontStyle = FontStyle.Normal;
        text.fontSize = 40;
        color = GetComponent<Outline>().effectColor;
        color.a = .2f;
        GetComponent<Outline>().effectColor = color;
        Controls controls = GameManagerScript.player.GetComponent<Controls>();
        controls.enabled = true;
        controls.anim.speed = 1;
        controls.reflectionAnim.speed = 1;
        UI.dibbukShop.SetActive(false);
    }

}
