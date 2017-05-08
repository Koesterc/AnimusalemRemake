using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateNewArmor : MonoBehaviour
{
    private BaseArmor newArmor;
    public GameObject droppedArmor;
    static bool refresh;
    void Start()
    {
        if (!refresh)
        {
            refresh = true;
            CreateArmor();
            Transform _weight = gameObject.transform.Find("Weight");
            Transform _name = gameObject.transform.Find("Type");
            _weight.GetComponent<Text>().text = newArmor.Weight.ToString() + " lbs";
            _name.GetComponent<Text>().text = newArmor.ItemName;
        }
    }
    private void CreateArmor()
    {
        newArmor = new BaseArmor();
        newArmor.ItemID = Random.Range(0,10000);
        newArmor.LevelRestriction = Random.Range(1,10);
        int temp = Random.Range(0, 100);
        if (temp >= 90)//use luck here to increase the chance of magic item
            newArmor.Constitution = Random.Range(1, 5);
        temp = Random.Range(0, 100);
        if (temp >= 90)
            newArmor.Strength = Random.Range(1, 5);
        temp = Random.Range(0, 100);
        if (temp >= 90)
            newArmor.Intelligence = Random.Range(1, 5);
        temp = Random.Range(0, 100);
        if (temp >= 90)
            newArmor.Dexterity += Random.Range(1, 5);
        temp = Random.Range(0, 100);
        if (temp >= 90)
            newArmor.Fortitude = Random.Range(1, 5);
        temp = Random.Range(0, 100);
        if (temp >= 90)
            newArmor.Agility = Random.Range(1, 5);
        temp = Random.Range(0, 100);
        if (temp >= 90)
            newArmor.Perception += Random.Range(1, 5);
        temp = Random.Range(0, 100);
        if (temp >= 90)
            newArmor.Charisma = Random.Range(1, 5);
        temp = Random.Range(0, 100);
        if (temp >= 90)
            newArmor.Luck = Random.Range(1, 5);
        temp = Random.Range(0, 100);
        if (temp >= 90)
            newArmor.ReducedWeight = Mathf.Round(Random.Range(.1f, .5f) * 100) / 100;

        ChooseArmor();
        newArmor.SellValue = (((int)newArmor.Defense/2) + newArmor.Strength * 2 +
            newArmor.Dexterity * 2 + newArmor.Constitution * 2 + newArmor.Charisma * 2 + newArmor.Luck * 2  
            + newArmor.Agility * 2 + newArmor.Perception * 2 + newArmor.Intelligence * 2 + newArmor.Fortitude * 2);
        newArmor.Weight = newArmor.Weight - (newArmor.Weight * newArmor.ReducedWeight)+ (int)(newArmor.ReducedWeight * 10);
    }
    private void ChooseArmor()
    {
        int temp = Random.Range(0, 3);
        switch(temp)
        {
            default:
                newArmor.ArmorTypes = BaseArmor.ArmorType.Light;
                newArmor.ItemName = "Light Armor";
                newArmor.ItemDesc = "Light Armor, although it doesn't seem to be of much use, it won't have any adverse effects as oppose to other armors.";
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newArmor.EnhancedDefense = Random.Range(1 + newArmor.LevelRestriction, 3 + newArmor.LevelRestriction);
                newArmor.Defense = Random.Range(1+(newArmor.LevelRestriction + newArmor.EnhancedDefense), 5 +(newArmor.LevelRestriction + newArmor.EnhancedDefense));
                newArmor.Weight = Random.Range(newArmor.LevelRestriction * 3, newArmor.LevelRestriction * 4);
                newArmor.RequiredStrength = Random.Range(0, newArmor.LevelRestriction * 2);
                break;
            case 1:
                newArmor.ArmorTypes = BaseArmor.ArmorType.Medium;
                newArmor.ItemName = "Medium Armor";
                newArmor.ItemDesc = "Medium armor allows the carrier to get the most out of their defense while keeping the burden to a minimum";
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newArmor.EnhancedDefense = Random.Range(1 + newArmor.LevelRestriction, 6 + newArmor.LevelRestriction);
                newArmor.Defense = Random.Range(3 + (newArmor.LevelRestriction + newArmor.EnhancedDefense), 8 + (newArmor.LevelRestriction + newArmor.EnhancedDefense));
                newArmor.Weight = Random.Range(newArmor.LevelRestriction * 2, newArmor.LevelRestriction * 3);
                newArmor.SpeedReduction = -2;
                break;
            case 2:
                newArmor.ArmorTypes = BaseArmor.ArmorType.Heavy;
                newArmor.ItemName = "Heavy Armor";
                newArmor.ItemDesc = "Heavy Armor, although very effective in combat, reduces the rate at which the carrier walks.";
                temp = Random.Range(0, 100);
                if (temp >= 90)
                    newArmor.EnhancedDefense = Random.Range(1 + newArmor.LevelRestriction, 10 + newArmor.LevelRestriction);
                newArmor.Defense = Random.Range(8 + (newArmor.LevelRestriction + newArmor.EnhancedDefense), 13 + (newArmor.LevelRestriction + newArmor.EnhancedDefense));
                newArmor.SpeedReduction = -4;
                newArmor.Weight = Random.Range(newArmor.LevelRestriction * 3, newArmor.LevelRestriction * 4);
                newArmor.RequiredStrength = Random.Range(newArmor.LevelRestriction * 3, newArmor.LevelRestriction * 4);
                break;
        }
    }

    public void DroppedArmor()
    {
        if (Input.GetKeyDown("return"))
        {
            GameObject clone;
            clone = Instantiate(droppedArmor, Controls._Player.transform.position, transform.rotation) as GameObject;
            clone.GetComponent<DroppedArmor>().DropArmor(newArmor);
            Destroy(gameObject);
        }
    }
    public void pickedUpArmor(BaseArmor myArmor)
    {
        newArmor = myArmor;
        Transform _weight = gameObject.transform.Find("Weight");
        Transform _name = gameObject.transform.Find("Type");
        _weight.GetComponent<Text>().text = newArmor.Weight.ToString() + " lbs";
        _name.GetComponent<Text>().text = newArmor.ItemName;
    }

    public void UpdateSelection()
    {
        Inventory._desc.text = newArmor.ItemDesc;
        Inventory._name.text = newArmor.ItemName;
        Inventory._image = newArmor.Icon;
    }
}
