using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour {

    public Text myText;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StopAllCoroutines();
            StartCoroutine(Enable());
         }
        if (other.tag == "Interact")
        {
            GameManagerScript.stat.gameObject.SetActive(true);
            Display();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManagerScript.stat.gameObject.SetActive(false);
            StopAllCoroutines();
            StartCoroutine(Disable());
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
        }
        if (gameObject.GetComponent<DroppedArmor>())
        {
            DroppedArmor droppedArmor = gameObject.GetComponent<DroppedArmor>();
            int i = 0;
            GameManagerScript.statDisplay[i].text = droppedArmor.ArmorStats.ItemName;
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
                i++;
            }
            GameManagerScript.statDisplay[i].text = "Weight: " + droppedArmor.ArmorStats.Weight.ToString();
            i++;
            GameManagerScript.statDisplay[i].text = "Value: " + droppedArmor.ArmorStats.SellValue.ToString();
            i++;
            GameManagerScript.statDisplay[i].text = " ";
            i++;
            if (droppedArmor.ArmorStats.Constitution > 0)
            {
                GameManagerScript.statDisplay[i].text = "Constitution: +" + droppedArmor.ArmorStats.Constitution.ToString();
                i++;
            }
            if (droppedArmor.ArmorStats.Strength > 0)
            {
                GameManagerScript.statDisplay[i].text = "Strength: +" + droppedArmor.ArmorStats.Strength.ToString();
                i++;
            }
            if (droppedArmor.ArmorStats.Dexterity > 0)
            {
                GameManagerScript.statDisplay[i].text = "Dexterity: +" + droppedArmor.ArmorStats.Dexterity.ToString();
                i++;
            }
            if (droppedArmor.ArmorStats.Intelligence > 0)
            {
                GameManagerScript.statDisplay[i].text = "Intelligence: +" + droppedArmor.ArmorStats.Intelligence.ToString();
                i++;
            }
            if (droppedArmor.ArmorStats.Agility > 0)
            {
                GameManagerScript.statDisplay[i].text = "Agility: +" + droppedArmor.ArmorStats.Agility.ToString();
                i++;
            }
            if (droppedArmor.ArmorStats.Charisma > 0)
            {
                GameManagerScript.statDisplay[i].text = "Charisma: +" + droppedArmor.ArmorStats.Charisma.ToString();
                i++;
            }
            if (droppedArmor.ArmorStats.Perception > 0)
            {
                GameManagerScript.statDisplay[i].text = "Perception: +" + droppedArmor.ArmorStats.Perception.ToString();
                i++;
            }
            if (droppedArmor.ArmorStats.Fortitude > 0)
            {
                GameManagerScript.statDisplay[i].text = "Fortitude: +" + droppedArmor.ArmorStats.Fortitude.ToString();
                i++;
            }
            if (droppedArmor.ArmorStats.Luck > 0)
            {
                GameManagerScript.statDisplay[i].text = "Luck: +" + droppedArmor.ArmorStats.Luck.ToString();
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
            GameManagerScript.statDisplay[i].text = droppedWeapon.WeaponStats.ItemType.ToString();
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
        }
    }//end of else if
}
