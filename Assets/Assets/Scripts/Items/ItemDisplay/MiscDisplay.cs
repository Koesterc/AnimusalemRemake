using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiscDisplay : MonoBehaviour
{
    public Text myText;
    bool pickUp = false;

    void OnDestroy()
    {
        pickUp = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
            StartCoroutine(Enable());
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // AmmoDisplay.isActive = false;
            StopAllCoroutines();
            StartCoroutine(Disable());
        }
        if (other.CompareTag("Interact") && pickUp)
        {
            AmmoDisplay.isActive = false;
            pickUp = false;
            myText.GetComponent<Outline>().effectColor = Color.HSVToRGB(.585f, 1, 1);
            Color c = myText.GetComponent<Outline>().effectColor;
            myText.fontSize = 12;
            Transform canvas = transform.Find("MyCanvas");
            canvas.GetComponent<Canvas>().sortingOrder = 100;
            c.a = .5f;
            myText.GetComponent<Outline>().effectColor = c;
            for (int i = 0; i < GameManagerScript.statDisplay.Count; i++)
            {
                GameManagerScript.statDisplay[i].gameObject.SetActive(false);
                GameManagerScript.statDisplay[i].GetComponent<Outline>().effectColor = Color.HSVToRGB(.585f, 1, 1);

            }
            GameManagerScript.stat.gameObject.SetActive(false);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Interact") && !AmmoDisplay.isActive)
        {
            AmmoDisplay.isActive = true;
            pickUp = true;
            GameManagerScript.stat.gameObject.SetActive(true);
            myText.GetComponent<Outline>().effectColor = Color.HSVToRGB(.8f, 1, 1);
            Color c = myText.GetComponent<Outline>().effectColor;
            c.a = .5f;
            myText.GetComponent<Outline>().effectColor = c;
            myText.fontSize = 12;
            Transform canvas = transform.Find("MyCanvas");
            canvas.GetComponent<Canvas>().sortingOrder = 101;
            Display();
        }
        else if (other.CompareTag("Interact") && pickUp && Input.GetKeyDown("return") && !GameManagerScript.isActive)
        {
      //    AmmoDisplay.isActive = false;
      //    pickUp = false;
      //      GameManagerScript.stat.gameObject.SetActive(false);
            gameObject.GetComponent<DroppedMisc>().PickedUp();
        }
    }

    IEnumerator Disable()
    {
        Color c = myText.color;
        while (c.a > 0)
        {
            yield return new WaitForSeconds(.1f);
            c.a -= .1f;
            myText.color = c;
        }
    }
    IEnumerator Enable()
    {
        Color c = myText.color;
        while (c.a < 1)
        {
            yield return new WaitForSeconds(.1f);
            c.a += .1f;
            myText.color = c;
        }
    }

    public void Display()
    {
        for (int j = 0; j < GameManagerScript.statDisplay.Count; j++)
        {
            GameManagerScript.statDisplay[j].gameObject.SetActive(true);
            GameManagerScript.statDisplay[j].GetComponent<Outline>().effectColor = Color.HSVToRGB(.585f, 1, 1);

        }
        DroppedMisc droppedMisc = gameObject.GetComponent<DroppedMisc>();
        int i = 0;
        GameManagerScript.statDisplay[i].text = "[" + droppedMisc.MiscStats.ItemName + "]";
        i++;
        GameManagerScript.statDisplay[i].text = " ";
        i++;
        while (i < (GameManagerScript.statDisplay.Count - 1))
        {
            GameManagerScript.statDisplay[i].gameObject.SetActive(false);
            i++;
        }
    }//end of display function
}//end of class


