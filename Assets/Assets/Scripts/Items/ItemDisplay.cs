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
            Display();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
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
        DroppedArmor droppedArmor = gameObject.GetComponent<DroppedArmor>();

        GameManagerScript.statDisplay[0].text = droppedArmor.ArmorStats.ItemName;
        GameManagerScript.statDisplay[1].text = "Defense: " +droppedArmor.ArmorStats.Defense.ToString();
        GameManagerScript.statDisplay[2].text = "Level Restriction: Level " + droppedArmor.ArmorStats.LevelRestriction.ToString();
        if (droppedArmor.ArmorStats.LevelRestriction > PlayerStats.curLevel)
            GameManagerScript.statDisplay[2].GetComponent<Outline>().effectColor = Color.red;
        GameManagerScript.statDisplay[3].text = "Required Strength: " + droppedArmor.ArmorStats.RequiredStrength.ToString();
        if (droppedArmor.ArmorStats.RequiredStrength > PlayerStats.strength)
            GameManagerScript.statDisplay[3].GetComponent<Outline>().effectColor = Color.red;
        GameManagerScript.statDisplay[4].text = "Required Dexterity: " + droppedArmor.ArmorStats.RequiredDexterity.ToString();
        if (droppedArmor.ArmorStats.RequiredDexterity > PlayerStats.dexterity)
            GameManagerScript.statDisplay[4].GetComponent<Outline>().effectColor = Color.red;
        GameManagerScript.statDisplay[5].text = "Required Intelligence: " + droppedArmor.ArmorStats.RequiredIntelligence.ToString();
        if (droppedArmor.ArmorStats.RequiredIntelligence > PlayerStats.intelligence)
            GameManagerScript.statDisplay[5].GetComponent<Outline>().effectColor = Color.red;
        GameManagerScript.statDisplay[6].text = "Weight: " + droppedArmor.ArmorStats.Weight.ToString();
        GameManagerScript.statDisplay[7].text = "Value: " + droppedArmor.ArmorStats.SellValue.ToString();
        GameManagerScript.statDisplay[8].text = "Constitution: +" + droppedArmor.ArmorStats.Constitution.ToString();
        GameManagerScript.statDisplay[9].text = "Strength: +" + droppedArmor.ArmorStats.Strength.ToString();
        GameManagerScript.statDisplay[10].text = "Dexterity: +" + droppedArmor.ArmorStats.Dexterity.ToString();
        GameManagerScript.statDisplay[11].text = "Intelligence: +" + droppedArmor.ArmorStats.Intelligence.ToString();
        GameManagerScript.statDisplay[12].text = "Agility: +" + droppedArmor.ArmorStats.Agility.ToString();
        GameManagerScript.statDisplay[13].text = "Charisma: +" + droppedArmor.ArmorStats.Charisma.ToString();
        GameManagerScript.statDisplay[14].text = "Perception: +" + droppedArmor.ArmorStats.Perception.ToString();
        GameManagerScript.statDisplay[15].text = "Fortitude: +" + droppedArmor.ArmorStats.Fortitude.ToString();
        GameManagerScript.statDisplay[16].text = "Luck: +" + droppedArmor.ArmorStats.Luck.ToString();


        //GameManagerScript.itemDisplay.text = "*" + "Level Restriction: " + droppedArmor.ArmorStats.LevelRestriction + "\n"
        //+ "*" + "Required Strength: " + droppedArmor.ArmorStats.RequiredStrength + "\n"
        //+ "*" + "Required Int: " + droppedArmor.ArmorStats.RequiredIntelligence + "\n"
        //+ "*" + "Required Dexterity: " + droppedArmor.ArmorStats.RequiredDexterity + "\n"
        //+ "\n"
        //+ "Defense: " + droppedArmor.ArmorStats.Defense + "\n"
        //+ "*" + "Constitution: + " + droppedArmor.ArmorStats.Constitution + "\n"
        //+ "*" + "Strength: + " + droppedArmor.ArmorStats.Strength + "\n"
        //+ "*" + "Luck: + " + droppedArmor.ArmorStats.Luck + "\n"
        //+ "*" + "Intelligence: + " + droppedArmor.ArmorStats.Intelligence + "\n"
        //+ "*" + "Agility: + " + droppedArmor.ArmorStats.Agility + "\n"
        //+ "*" + "Fortitude: + " + droppedArmor.ArmorStats.Fortitude + "\n"
        //+ "*" + "Charisma: + " + droppedArmor.ArmorStats.Charisma + "\n"
        //+ "*" + "Perception: + " + droppedArmor.ArmorStats.Perception + "\n";
    }

}
