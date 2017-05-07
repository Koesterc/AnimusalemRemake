using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour {

    public Text myText;
    static bool isActive = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StopAllCoroutines();
            StartCoroutine(Enable());
         }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isActive = false;
            StopAllCoroutines();
            StartCoroutine(Disable());
        }
        if (other.tag == "Interact")
        {
            isActive = false;
            GameManagerScript.stat.gameObject.SetActive(false);
            myText.GetComponent<Outline>().effectColor = Color.HSVToRGB(.585f,1,1);
            Color c = myText.GetComponent<Outline>().effectColor;
            myText.fontSize = 14;
            Transform canvas = transform.Find("MyCanvas");
            canvas.GetComponent<Canvas>().sortingOrder = 100;
            c.a = .5f;
            myText.GetComponent<Outline>().effectColor = c;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Interact" && !isActive)
        {
            isActive = true;
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
        for (int i = 0; i < GameManagerScript.statDisplay.Count - 1; i++)
        {
            GameManagerScript.statDisplay[i].gameObject.SetActive(true);
            GameManagerScript.statDisplay[i].GetComponent<Outline>().effectColor = Color.HSVToRGB(.585f, 1, 1);

        }
        if (gameObject.GetComponent<DroppedArmor>())
        {
            DroppedArmor droppedArmor = gameObject.GetComponent<DroppedArmor>();
            int i = 0;
            GameManagerScript.statDisplay[i].text = "["+droppedArmor.ArmorStats.ItemName+"]";
            i++;
            GameManagerScript.statDisplay[i].text = "Defense: " + droppedArmor.ArmorStats.Defense.ToString();
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
                else
                    GameManagerScript.statDisplay[i].GetComponent<Outline>().effectColor = Color.blue;
                i++;
            }
            GameManagerScript.statDisplay[i].text = "Weight: " + droppedArmor.ArmorStats.Weight.ToString()+" lbs";
            i++;
            GameManagerScript.statDisplay[i].text = "Value: $" + droppedArmor.ArmorStats.SellValue.ToString();
            i++;
            GameManagerScript.statDisplay[i].text = " ";
            i++;
            if (droppedArmor.ArmorStats.EnhancedDefense > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Reinforced Defense: +" + droppedArmor.ArmorStats.EnhancedDefense.ToString();
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
            if (droppedArmor.ArmorStats.ReducedWeight> 0)
            {
                GameManagerScript.statDisplay[i].text = "*Item's weight reduced by " + (droppedArmor.ArmorStats.ReducedWeight*100).ToString()+"%";
                i++;
            }
            while (i < (GameManagerScript.statDisplay.Count - 1))
            {
                GameManagerScript.statDisplay[i].gameObject.SetActive(false);
                i++;
            }
        }//end of if
        else if (gameObject.GetComponent<DroppedWeapon>())//checking the weapon
        {
            DroppedWeapon droppedWeapon = gameObject.GetComponent<DroppedWeapon>();
            int i = 0;
            GameManagerScript.statDisplay[i].text = "["+droppedWeapon.WeaponStats.WeaponTypes.ToString()+"]";
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
            GameManagerScript.statDisplay[i].text = "Weight: " + droppedWeapon.WeaponStats.Weight.ToString()+" lbs";
            i++;
            GameManagerScript.statDisplay[i].text = "Value: $" + droppedWeapon.WeaponStats.SellValue.ToString();
            i++;
            GameManagerScript.statDisplay[i].text = " ";
            i++;
            GameManagerScript.statDisplay[i].text = "Damage: " + droppedWeapon.WeaponStats.Damage.ToString();
            i++;
            GameManagerScript.statDisplay[i].text = "Firerate: " + droppedWeapon.WeaponStats.Firerate.ToString()+" Secs";
            i++;
            GameManagerScript.statDisplay[i].text = "Reload: " + droppedWeapon.WeaponStats.Reload.ToString()+" Secs";
            i++;
            GameManagerScript.statDisplay[i].text = "Capacity: " + droppedWeapon.WeaponStats.Capacity.ToString();
            i++;
            GameManagerScript.statDisplay[i].text = "Accuracy: " + (droppedWeapon.WeaponStats.Accuracy*100).ToString()+"%";
            i++;
            GameManagerScript.statDisplay[i].text = "Critical Damage: " + (droppedWeapon.WeaponStats.CriticalDamage*100).ToString()+"%";
            i++;
            GameManagerScript.statDisplay[i].text = "Critical Chance: " + (droppedWeapon.WeaponStats.CriticalChance*100).ToString()+"%";
            i++;
            GameManagerScript.statDisplay[i].text = " ";
            i++;
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
            if (droppedWeapon.WeaponStats.IncreasedCriticalChance > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Increased Critical Chance: +" + (droppedWeapon.WeaponStats.IncreasedCriticalChance*100).ToString()+"%";
                i++;
            }
            if (droppedWeapon.WeaponStats.IgnoreArmor > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Ignore Target's Defense: -" + droppedWeapon.WeaponStats.IgnoreArmor.ToString();
                i++;
            }
            if (droppedWeapon.WeaponStats.PoisonDamage > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Poison Damage: +" + droppedWeapon.WeaponStats.PoisonDamage.ToString();
                i++;
            }
            if (droppedWeapon.WeaponStats.AimAssist > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Assisted Aim: +" + droppedWeapon.WeaponStats.AimAssist.ToString()+"%";
                i++;
            }
            if (droppedWeapon.WeaponStats.Leech > 0)
            {
                GameManagerScript.statDisplay[i].text = "*Leeches "+droppedWeapon.WeaponStats.Leech.ToString()+" health per each kill";
                i++;
            }
            if (droppedWeapon.WeaponStats.AdditionalXP > 0)
            {
                GameManagerScript.statDisplay[i].text = "*+"+(droppedWeapon.WeaponStats.AdditionalXP*100).ToString()+"% more experience after each kill";
                i++;
            }
            if (droppedWeapon.WeaponStats.AdditionalGold > 0)
            {
                GameManagerScript.statDisplay[i].text = "*+"+(droppedWeapon.WeaponStats.AdditionalGold*100).ToString() + "% more gold after each kill";
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
    }//end of else if
}//end of class
