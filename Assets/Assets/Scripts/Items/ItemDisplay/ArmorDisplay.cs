using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorDisplay : MonoBehaviour {
    public Text myText;
    public bool pickUp = false;

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
        if (other.CompareTag ("Player"))
        {
           // AmmoDisplay.isActive = false;
            StopAllCoroutines();
            StartCoroutine(Disable());
        }
        if (other.CompareTag ("Interact") && pickUp)
        {
            AmmoDisplay.isActive = false;
            pickUp = false;
            myText.GetComponent<Outline>().effectColor = Color.HSVToRGB(.585f,1,1);
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
            //play sound
            pickUp = false;
            gameObject.GetComponent<DroppedArmor>().PickedUp();
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
            DroppedArmor droppedArmor = gameObject.GetComponent<DroppedArmor>();
            int i = 0;
            GameManagerScript.statDisplay[i].text = "[" + droppedArmor.ArmorStats.ItemName + "]";
            i++;
            GameManagerScript.statDisplay[i].text = "Defense: " + droppedArmor.ArmorStats.Defense.ToString("n0");
            i++;
            if (droppedArmor.ArmorStats.LevelRestriction > 0)
            {
                GameManagerScript.statDisplay[i].text = "Level Restriction: Level " + droppedArmor.ArmorStats.LevelRestriction.ToString();
                if (droppedArmor.ArmorStats.LevelRestriction > PlayerStats.curLevel)
                    GameManagerScript.statDisplay[i].GetComponent<Outline>().effectColor = Color.red;
                i++;
            }
            if (droppedArmor.ArmorStats.RequiredStrength > 0)
            {
                GameManagerScript.statDisplay[i].text = "Required Strength: " + droppedArmor.ArmorStats.RequiredStrength.ToString();
                if (droppedArmor.ArmorStats.RequiredStrength > PlayerStats.strength)
                    GameManagerScript.statDisplay[i].GetComponent<Outline>().effectColor = Color.red;
                i++;
            }
            if (droppedArmor.ArmorStats.RequiredDexterity > 0)
            {
                GameManagerScript.statDisplay[i].text = "Required Dexterity: " + droppedArmor.ArmorStats.RequiredDexterity.ToString();
                if (droppedArmor.ArmorStats.RequiredDexterity > PlayerStats.dexterity)
                    GameManagerScript.statDisplay[i].GetComponent<Outline>().effectColor = Color.red;
                i++;
            }
            if (droppedArmor.ArmorStats.RequiredIntelligence > 0)
            {
                GameManagerScript.statDisplay[i].text = "Required Intelligence: " + droppedArmor.ArmorStats.RequiredIntelligence.ToString();
                if (droppedArmor.ArmorStats.RequiredIntelligence > PlayerStats.intelligence)
                    GameManagerScript.statDisplay[i].GetComponent<Outline>().effectColor = Color.red;
                i++;
            }
            GameManagerScript.statDisplay[i].text = "Weight: " + droppedArmor.ArmorStats.Weight.ToString() + " lbs";
            if (droppedArmor.ArmorStats.Weight + PlayerStats.curWeight > PlayerStats.maxWeight)
                GameManagerScript.statDisplay[i].GetComponent<Outline>().effectColor = Color.red;
            i++;
            GameManagerScript.statDisplay[i].text = "Value: $" + droppedArmor.ArmorStats.SellValue.ToString("n0");
            i++;
            GameManagerScript.statDisplay[i].text = " ";
            i++;
            if (droppedArmor.ArmorStats.EnhancedDefense > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Reinforced Defense: +" + droppedArmor.ArmorStats.EnhancedDefense.ToString();
                i++;
            }
            if (droppedArmor.ArmorStats.MaxHealth > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Increased Maximum Health: +"+ (droppedArmor.ArmorStats.MaxHealth*100).ToString()+"%";
                i++;
            }
            if (droppedArmor.ArmorStats.PoisonRes > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Poison Tolerance: +" + droppedArmor.ArmorStats.PoisonRes.ToString();
                i++;
            }
            if (droppedArmor.ArmorStats.FireRes > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Fire Resistance: +" + droppedArmor.ArmorStats.FireRes.ToString();
                i++;
            }
            if (droppedArmor.ArmorStats.ColdRes > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Cold Protection: +" + droppedArmor.ArmorStats.ColdRes.ToString();
                i++;
            }
            if (droppedArmor.ArmorStats.LightRes> 0)
            {
                GameManagerScript.statDisplay[i].text = "*Light Asborption: +" + droppedArmor.ArmorStats.LightRes.ToString();
                i++;
            }
            if (droppedArmor.ArmorStats.Constitution > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Constitution: +" + droppedArmor.ArmorStats.Constitution.ToString();
                i++;
            }
            if (droppedArmor.ArmorStats.Strength > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Strength: +" + droppedArmor.ArmorStats.Strength.ToString();
                i++;
            }
            if (droppedArmor.ArmorStats.Dexterity > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Dexterity: +" + droppedArmor.ArmorStats.Dexterity.ToString();
                i++;
            }
            if (droppedArmor.ArmorStats.Intelligence > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Intelligence: +" + droppedArmor.ArmorStats.Intelligence.ToString();
                i++;
            }
            if (droppedArmor.ArmorStats.Agility > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Agility: +" + droppedArmor.ArmorStats.Agility.ToString();
                i++;
            }
            if (droppedArmor.ArmorStats.Charisma > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Charisma: +" + droppedArmor.ArmorStats.Charisma.ToString();
                i++;
            }
            if (droppedArmor.ArmorStats.Perception > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Perception: +" + droppedArmor.ArmorStats.Perception.ToString();
                i++;
            }
            if (droppedArmor.ArmorStats.Fortitude > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Fortitude: +" + droppedArmor.ArmorStats.Fortitude.ToString();
                i++;
            }
            if (droppedArmor.ArmorStats.Luck > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Luck: +" + droppedArmor.ArmorStats.Luck.ToString();
                i++;
            }
            if (droppedArmor.ArmorStats.ReducedWeight > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Item's weight reduced by " + (droppedArmor.ArmorStats.ReducedWeight * 100).ToString() + "%";
                i++;
            }
            while (i < (GameManagerScript.statDisplay.Count))
            {
                GameManagerScript.statDisplay[i].gameObject.SetActive(false);
                i++;
            }
    }//end of display function
}//end of class
