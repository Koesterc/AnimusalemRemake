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

}
