using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour {
    public Text myText;
    static bool isActive = false;
    bool pickUp = false;

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
           // isActive = false;
            StopAllCoroutines();
            StartCoroutine(Disable());
        }
        if (other.tag == "Interact")
        {
            isActive = false;
            pickUp = false;
            myText.GetComponent<Outline>().effectColor = Color.HSVToRGB(.585f,1,1);
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
        if (other.tag == "Interact" && !isActive)
        {
            isActive = true;
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
        else if (other.tag == "Interact" && pickUp && Input.GetKeyDown("return") && !Inventory.inventory.gameObject.activeSelf)
        {
            //check weight
            //add weight
            //play sound
            isActive = false;
            pickUp = false;
            GameManagerScript.stat.gameObject.SetActive(false);
            if (gameObject.GetComponent<DroppedArmor>())
            {
                gameObject.GetComponent<DroppedArmor>().PickedUp();
                Destroy(gameObject);
            }
            else if(gameObject.GetComponent<DroppedWeapon>())
            {
                gameObject.GetComponent<DroppedWeapon>().PickedUp();
                Destroy(gameObject);
            }
            else if (gameObject.GetComponent<DroppedMisc>())
            {
                gameObject.GetComponent<DroppedMisc>().PickedUp();
                Destroy(gameObject);
            }
            else if (gameObject.GetComponent<DroppedAmmo>())
            {
                gameObject.GetComponent<DroppedAmmo>().PickedUp();
            }

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
        for (int i = 0; i < GameManagerScript.statDisplay.Count; i++)
        {
            GameManagerScript.statDisplay[i].gameObject.SetActive(true);
            GameManagerScript.statDisplay[i].GetComponent<Outline>().effectColor = Color.HSVToRGB(.585f, 1, 1);

        }
        if (gameObject.GetComponent<DroppedArmor>())
        {
            DroppedArmor droppedArmor = gameObject.GetComponent<DroppedArmor>();
            int i = 0;
            GameManagerScript.statDisplay[i].text = "[" + droppedArmor.ArmorStats.ItemName + "]";
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
            GameManagerScript.statDisplay[i].text = "Weight: " + droppedArmor.ArmorStats.Weight.ToString() + " lbs";
            if (droppedArmor.ArmorStats.Weight + PlayerStats.curWeight > PlayerStats.maxWeight)
                GameManagerScript.statDisplay[i].GetComponent<Outline>().effectColor = Color.red;
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
        }//end of if
        else if (gameObject.GetComponent<DroppedWeapon>())//checking the weapon
        {
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
            if (droppedWeapon.WeaponStats.ThreeRoundBurst)
            {
                GameManagerScript.statDisplay[i].text = "*Three Round Burst";
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
                GameManagerScript.statDisplay[i].text = "*Electricute: +" + droppedWeapon.WeaponStats.LightDamage.ToString()+" Shock Damage";
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
        }//end of else if
        else if (gameObject.GetComponent<DroppedMisc>())//checking the misc
        {
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
        }//end of else if
        else if (gameObject.GetComponent<DroppedAmmo>())//checking the ammo
        {
            DroppedAmmo droppedAmmo = gameObject.GetComponent<DroppedAmmo>();
            int i = 0;
            GameManagerScript.statDisplay[i].text = "[" + droppedAmmo.AmmoStats.ItemName+ "]";
            i++;
            GameManagerScript.statDisplay[i].text = "Quantity: " + droppedAmmo.AmmoStats.Quantity;
            i++;
            switch (droppedAmmo.AmmoStats.AmmoTypes)
            {
                case BaseAmmo.AmmoType.HandgunAmmo:
                    GameManagerScript.statDisplay[i].text = "Weight: " + (droppedAmmo.AmmoStats.Quantity * PlayerStats.hgAmmoWeight).ToString()+" lbs";
                    if ((droppedAmmo.AmmoStats.Quantity * PlayerStats.hgAmmoWeight) > PlayerStats.maxWeight)
                        GameManagerScript.statDisplay[i].GetComponent<Outline>().effectColor = Color.red;
                    break;
                case BaseAmmo.AmmoType.ShotgunShells:
                    GameManagerScript.statDisplay[i].text = "Weight: " + (droppedAmmo.AmmoStats.Quantity * PlayerStats.sgAmmoWeight).ToString() + " lbs";
                    if ((droppedAmmo.AmmoStats.Quantity * PlayerStats.sgAmmoWeight) > PlayerStats.maxWeight)
                        GameManagerScript.statDisplay[i].GetComponent<Outline>().effectColor = Color.red;
                    break;
                case BaseAmmo.AmmoType.MachinegunAmmo:
                    GameManagerScript.statDisplay[i].text = "Weight: " + (droppedAmmo.AmmoStats.Quantity * PlayerStats.mgAmmoWeight).ToString() + " lbs";
                    if ((droppedAmmo.AmmoStats.Quantity * PlayerStats.mgAmmoWeight) > PlayerStats.maxWeight)
                        GameManagerScript.statDisplay[i].GetComponent<Outline>().effectColor = Color.red;
                    break;
                case BaseAmmo.AmmoType.RifleAmmo:
                    GameManagerScript.statDisplay[i].text = "Weight: " + (droppedAmmo.AmmoStats.Quantity * PlayerStats.rifleAmmoWeight).ToString() + " lbs";
                    if ((droppedAmmo.AmmoStats.Quantity * PlayerStats.rifleAmmoWeight) > PlayerStats.maxWeight)
                        GameManagerScript.statDisplay[i].GetComponent<Outline>().effectColor = Color.red;
                    break;
                case BaseAmmo.AmmoType.AssaultRifleAmmo:
                    GameManagerScript.statDisplay[i].text = "Weight: " + (droppedAmmo.AmmoStats.Quantity * PlayerStats.arAmmoWeight).ToString() + " lbs";
                    if ((droppedAmmo.AmmoStats.Quantity * PlayerStats.arAmmoWeight) > PlayerStats.maxWeight)
                        GameManagerScript.statDisplay[i].GetComponent<Outline>().effectColor = Color.red;
                    break;
                case BaseAmmo.AmmoType.MagnumAmmo:
                    GameManagerScript.statDisplay[i].text = "Weight: " + (droppedAmmo.AmmoStats.Quantity * PlayerStats.magnumAmmoWeight).ToString() + " lbs";
                    if ((droppedAmmo.AmmoStats.Quantity * PlayerStats.magnumAmmoWeight) > PlayerStats.maxWeight)
                        GameManagerScript.statDisplay[i].GetComponent<Outline>().effectColor = Color.red;
                    break;
                case BaseAmmo.AmmoType.ExplosiveRounds:
                    GameManagerScript.statDisplay[i].text = "Weight: " + (droppedAmmo.AmmoStats.Quantity * PlayerStats.explosiveAmmoWeight).ToString() + " lbs";
                    if ((droppedAmmo.AmmoStats.Quantity * PlayerStats.explosiveAmmoWeight) > PlayerStats.maxWeight)
                        GameManagerScript.statDisplay[i].GetComponent<Outline>().effectColor = Color.red;
                    break;
            }
            i++;
            while (i < (GameManagerScript.statDisplay.Count - 1))
            {
                GameManagerScript.statDisplay[i].gameObject.SetActive(false);
                i++;
            }
        }//end of else if
    }//end of display function
}//end of class
