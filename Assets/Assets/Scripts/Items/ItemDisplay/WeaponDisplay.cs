using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{
    public Text myText;
    bool pickUp = false;

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
            myText.fontSize = 14;
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
            myText.fontSize = 16;
            Transform canvas = transform.Find("MyCanvas");
            canvas.GetComponent<Canvas>().sortingOrder = 101;
            Display();
        }
        else if (other.CompareTag("Interact") && pickUp && Input.GetKeyDown("return") && !GameManagerScript.isActive)
        {
            //check weight
            //add weight
            //play sound
          //  AmmoDisplay.isActive = false;
            pickUp = false;
            GameManagerScript.stat.gameObject.SetActive(false);
            gameObject.GetComponent<DroppedWeapon>().PickedUp();
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
            DroppedWeapon droppedWeapon = gameObject.GetComponent<DroppedWeapon>();
            int i = 0;
            GameManagerScript.statDisplay[i].text = "[" + droppedWeapon.WeaponStats.WeaponTypes.ToString() + "]";
            i++;
            GameManagerScript.statDisplay[i].text = "\"" + droppedWeapon.WeaponStats.ItemName + "\"";
            i++;
            if (droppedWeapon.WeaponStats.LevelRestriction > 0)
            {
                GameManagerScript.statDisplay[i].text = "Level Restriction: Level " + droppedWeapon.WeaponStats.LevelRestriction.ToString();
                if (droppedWeapon.WeaponStats.LevelRestriction > PlayerStats.curLevel)
                    GameManagerScript.statDisplay[i].GetComponent<Outline>().effectColor = Color.red;
                i++;
            }
            if (droppedWeapon.WeaponStats.RequiredStrength > 0)
            {
                GameManagerScript.statDisplay[i].text = "Required Strength: " + droppedWeapon.WeaponStats.RequiredStrength.ToString();
                if (droppedWeapon.WeaponStats.RequiredStrength > PlayerStats.strength)
                    GameManagerScript.statDisplay[i].GetComponent<Outline>().effectColor = Color.red;
                i++;
            }
            if (droppedWeapon.WeaponStats.RequiredDexterity > 0)
            {
                GameManagerScript.statDisplay[i].text = "Required Dexterity: " + droppedWeapon.WeaponStats.RequiredDexterity.ToString();
                if (droppedWeapon.WeaponStats.RequiredDexterity > PlayerStats.dexterity)
                    GameManagerScript.statDisplay[i].GetComponent<Outline>().effectColor = Color.red;
                i++;
            }
            GameManagerScript.statDisplay[i].text = "Weight: " + droppedWeapon.WeaponStats.Weight.ToString() + " lbs";
            if (droppedWeapon.WeaponStats.Weight + PlayerStats.curWeight > PlayerStats.maxWeight)
                GameManagerScript.statDisplay[i].GetComponent<Outline>().effectColor = Color.red;
            i++;
            GameManagerScript.statDisplay[i].text = "Value: $" + droppedWeapon.WeaponStats.SellValue.ToString();
            i++;
            GameManagerScript.statDisplay[i].text = " ";
            i++;
            GameManagerScript.statDisplay[i].text = "Damage: " + droppedWeapon.WeaponStats.Damage.ToString();
            i++;
            GameManagerScript.statDisplay[i].text = "Firerate: " + droppedWeapon.WeaponStats.Firerate.ToString() + " Secs";
            i++;
            GameManagerScript.statDisplay[i].text = "Reload: " + droppedWeapon.WeaponStats.Reload.ToString() + " Secs";
            i++;
            GameManagerScript.statDisplay[i].text = "Capacity: " + droppedWeapon.WeaponStats.Capacity.ToString();
            i++;
            GameManagerScript.statDisplay[i].text = "Accuracy: " + (droppedWeapon.WeaponStats.Accuracy * 100).ToString() + "%";
            i++;
            GameManagerScript.statDisplay[i].text = "Critical Damage: " + (droppedWeapon.WeaponStats.CriticalDamage * 100).ToString() + "%";
            i++;
            GameManagerScript.statDisplay[i].text = "Critical Chance: " + (droppedWeapon.WeaponStats.CriticalChance * 100).ToString() + "%";
            i++;
            GameManagerScript.statDisplay[i].text = " ";
            i++;
            if (droppedWeapon.WeaponStats.ThreeRoundBurst)
            {
                GameManagerScript.statDisplay[i].text = "*Three Round Burst";
                i++;
            }
            if (droppedWeapon.WeaponStats.DoubleBarrel)
            {
                GameManagerScript.statDisplay[i].text = "*Double Barrel";
                i++;
            }
            if (droppedWeapon.WeaponStats.TrippleBarrel)
            {
                GameManagerScript.statDisplay[i].text = "*Tripple Barrel";
                i++;
            }
            if (droppedWeapon.WeaponStats.EnhancedDamage > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Enhanced Damage: +" + droppedWeapon.WeaponStats.EnhancedDamage.ToString();
                i++;
            }
            if (droppedWeapon.WeaponStats.ExtendedClip > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Extended Magazine: +" + droppedWeapon.WeaponStats.ExtendedClip.ToString();
                i++;
            }
            if (droppedWeapon.WeaponStats.ModifiedAccuracy > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Modified Accuracy: +" + (droppedWeapon.WeaponStats.ModifiedAccuracy * 100).ToString() + "%";
                i++;
            }
            if (droppedWeapon.WeaponStats.IncreasedCriticalChance > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Increased Critical Chance: +" + (droppedWeapon.WeaponStats.IncreasedCriticalChance * 100).ToString() + "%";
                i++;
            }
            if (droppedWeapon.WeaponStats.IgnoreArmor > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Armor Piercing: +" + droppedWeapon.WeaponStats.IgnoreArmor.ToString();
                i++;
            }
            if (droppedWeapon.WeaponStats.PoisonDamage > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Toxicant: +" + droppedWeapon.WeaponStats.PoisonDamage.ToString() + " Poison Damage";
                i++;
            }
            if (droppedWeapon.WeaponStats.FireDamage > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Incinerate: +" + droppedWeapon.WeaponStats.FireDamage.ToString() + " Fire Damage";
                i++;
            }
            if (droppedWeapon.WeaponStats.ColdDamage > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Frost Bite: +" + droppedWeapon.WeaponStats.ColdDamage.ToString() + " Cold Damage";
                i++;
            }
            if (droppedWeapon.WeaponStats.LightDamage > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Electricute: +" + droppedWeapon.WeaponStats.LightDamage.ToString() + " Shock Damage";
                i++;
            }
            if (droppedWeapon.WeaponStats.AimAssist > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Assisted Aim: +" + droppedWeapon.WeaponStats.AimAssist.ToString() + "%";
                i++;
            }
            if (droppedWeapon.WeaponStats.Leech > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Leeches " + droppedWeapon.WeaponStats.Leech.ToString() + " health per each kill";
                i++;
            }
            if (droppedWeapon.WeaponStats.AdditionalXP > 0)
            {
                GameManagerScript.statDisplay[i].text = "*+" + (droppedWeapon.WeaponStats.AdditionalXP * 100).ToString() + "% more experience after each kill";
                i++;
            }
            if (droppedWeapon.WeaponStats.AdditionalGold > 0)
            {
                GameManagerScript.statDisplay[i].text = "*+" + (droppedWeapon.WeaponStats.AdditionalGold * 100).ToString() + "% more gold after each kill";
                i++;
            }
            if (droppedWeapon.WeaponStats.ReducedWeight > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Item's weight reduced by " + (droppedWeapon.WeaponStats.ReducedWeight * 100).ToString() + "%";
                i++;
            }
            while (i < (GameManagerScript.statDisplay.Count - 1))
            {
                GameManagerScript.statDisplay[i].gameObject.SetActive(false);
                i++;
            }
    }//end of display function
}//end of class

