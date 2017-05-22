using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{
    public Text myText;
    public static bool isActive = false;
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
            // isActive = false;
            StopAllCoroutines();
            StartCoroutine(Disable());
        }
        if (other.CompareTag("Interact") && pickUp)
        {
            isActive = false;
            pickUp = false;
            myText.GetComponent<Outline>().effectColor = Color.HSVToRGB(.585f, 1, 1);
            Color c = myText.GetComponent<Outline>().effectColor;
            myText.fontSize = 10;
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
        if (other.CompareTag("Interact") && !isActive)
        {
            isActive = true;
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
    //        isActive = false;
      //      pickUp = false;
        //    GameManagerScript.stat.gameObject.SetActive(false);
            gameObject.GetComponent<DroppedAmmo>().PickedUp();
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

            DroppedAmmo droppedAmmo = gameObject.GetComponent<DroppedAmmo>();
            int i = 0;
            GameManagerScript.statDisplay[i].text = "[" + droppedAmmo.AmmoStats.ItemName + "]";
            i++;
            GameManagerScript.statDisplay[i].text = "Quantity: " + droppedAmmo.AmmoStats.Quantity;
            i++;
            switch (droppedAmmo.AmmoStats.AmmoTypes)
            {
                case BaseAmmo.AmmoType.HandgunAmmo:
                    GameManagerScript.statDisplay[i].text = "Weight: " + (droppedAmmo.AmmoStats.Quantity * PlayerStats.hgAmmoWeight).ToString() + " lbs";
                    if (PlayerStats.curWeight + (droppedAmmo.AmmoStats.Quantity * PlayerStats.hgAmmoWeight) > PlayerStats.maxWeight)
                        GameManagerScript.statDisplay[i].GetComponent<Outline>().effectColor = Color.red;
                    break;
                case BaseAmmo.AmmoType.ShotgunShells:
                    GameManagerScript.statDisplay[i].text = "Weight: " + (droppedAmmo.AmmoStats.Quantity * PlayerStats.sgAmmoWeight).ToString() + " lbs";
                    if (PlayerStats.curWeight + (droppedAmmo.AmmoStats.Quantity * PlayerStats.sgAmmoWeight) > PlayerStats.maxWeight)
                        GameManagerScript.statDisplay[i].GetComponent<Outline>().effectColor = Color.red;
                    break;
                case BaseAmmo.AmmoType.MachinegunAmmo:
                    GameManagerScript.statDisplay[i].text = "Weight: " + (droppedAmmo.AmmoStats.Quantity * PlayerStats.mgAmmoWeight).ToString() + " lbs";
                    if (PlayerStats.curWeight + (droppedAmmo.AmmoStats.Quantity * PlayerStats.mgAmmoWeight) > PlayerStats.maxWeight)
                        GameManagerScript.statDisplay[i].GetComponent<Outline>().effectColor = Color.red;
                    break;
                case BaseAmmo.AmmoType.RifleAmmo:
                    GameManagerScript.statDisplay[i].text = "Weight: " + (droppedAmmo.AmmoStats.Quantity * PlayerStats.rifleAmmoWeight).ToString() + " lbs";
                    if (PlayerStats.curWeight + (droppedAmmo.AmmoStats.Quantity * PlayerStats.rifleAmmoWeight) > PlayerStats.maxWeight)
                        GameManagerScript.statDisplay[i].GetComponent<Outline>().effectColor = Color.red;
                    break;
                case BaseAmmo.AmmoType.AssaultRifleAmmo:
                    GameManagerScript.statDisplay[i].text = "Weight: " + (droppedAmmo.AmmoStats.Quantity * PlayerStats.arAmmoWeight).ToString() + " lbs";
                    if (PlayerStats.curWeight + (droppedAmmo.AmmoStats.Quantity * PlayerStats.arAmmoWeight) > PlayerStats.maxWeight)
                        GameManagerScript.statDisplay[i].GetComponent<Outline>().effectColor = Color.red;
                    break;
                case BaseAmmo.AmmoType.MagnumAmmo:
                    GameManagerScript.statDisplay[i].text = "Weight: " + (droppedAmmo.AmmoStats.Quantity * PlayerStats.magnumAmmoWeight).ToString() + " lbs";
                    if (PlayerStats.curWeight + (droppedAmmo.AmmoStats.Quantity * PlayerStats.magnumAmmoWeight) > PlayerStats.maxWeight)
                        GameManagerScript.statDisplay[i].GetComponent<Outline>().effectColor = Color.red;
                    break;
                case BaseAmmo.AmmoType.ExplosiveRounds:
                    GameManagerScript.statDisplay[i].text = "Weight: " + (droppedAmmo.AmmoStats.Quantity * PlayerStats.explosiveAmmoWeight).ToString() + " lbs";
                    if (PlayerStats.curWeight + (droppedAmmo.AmmoStats.Quantity * PlayerStats.explosiveAmmoWeight) > PlayerStats.maxWeight)
                        GameManagerScript.statDisplay[i].GetComponent<Outline>().effectColor = Color.red;
                    break;
            }
            i++;
            while (i < (GameManagerScript.statDisplay.Count - 1))
            {
                GameManagerScript.statDisplay[i].gameObject.SetActive(false);
                i++;
            }
    }//end of display function
}//end of class

