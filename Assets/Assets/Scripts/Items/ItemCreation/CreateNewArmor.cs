using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateNewArmor : MonoBehaviour
{
    private BaseArmor newArmor;
    public GameObject droppedArmor;
    void Start()
    {
        CreateArmor();
        Transform _weight = gameObject.transform.Find("Weight");
        Transform _name = gameObject.transform.Find("Type");
        _weight.GetComponent<Text>().text = newArmor.Weight.ToString() + " lbs";
        _name.GetComponent<Text>().text = newArmor.ItemName;
        //print(newArmor.ItemName);
        //print(newArmor.ArmorTypes);
        //print(newArmor.Defense);
        //print(newArmor.LevelRestriction);
        //print(newArmor.SpeedReduction);
    }
    private void CreateArmor()
    {
        newArmor = new BaseArmor();
        newArmor.ItemID = Random.Range(0,10000);
        newArmor.LevelRestriction = Random.Range(1,10);
        int temp = Random.Range(0, 100);
        if (temp >= 90)//use luck here to increase the chance of magic item
            newArmor.Constitution += Random.Range(1, 5);
        temp = Random.Range(0, 100);
        if (temp >= 90)
            newArmor.Strength += Random.Range(1, 5);
        temp = Random.Range(0, 100);
        if (temp >= 90)
            newArmor.Intelligence += Random.Range(1, 5);
        temp = Random.Range(0, 100);
        if (temp >= 90)
            newArmor.Dexterity += Random.Range(1, 5);
        temp = Random.Range(0, 100);
        if (temp >= 90)
            newArmor.Fortitude += Random.Range(1, 5);
        temp = Random.Range(0, 100);
        if (temp >= 90)
            newArmor.Agility += Random.Range(1, 5);
        temp = Random.Range(0, 100);
        if (temp >= 90)
            newArmor.Perception += Random.Range(1, 5);
        temp = Random.Range(0, 100);
        if (temp >= 90)
            newArmor.Charisma += Random.Range(1, 5);
        temp = Random.Range(0, 100);
        if (temp >= 90)
            newArmor.Luck += Random.Range(1, 5);
 
        ChooseArmor();
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
                newArmor.Defense = Random.Range(newArmor.LevelRestriction*5, newArmor.LevelRestriction * 10);
                newArmor.Weight = Random.Range(newArmor.LevelRestriction * 3, newArmor.LevelRestriction * 4);
                newArmor.RequiredStrength = Random.Range(0, newArmor.LevelRestriction * 2);
                break;
            case 1:
                newArmor.ArmorTypes = BaseArmor.ArmorType.Medium;
                newArmor.ItemName = "Medium Armor";
                newArmor.ItemDesc = "Medium armor allows the carrier to get the most out of their defense while keeping the burden to a minimum";
                newArmor.Defense = Random.Range(newArmor.LevelRestriction * 2, newArmor.LevelRestriction * 3);
                newArmor.Weight = Random.Range(newArmor.LevelRestriction * 2, newArmor.LevelRestriction * 3);
                newArmor.SpeedReduction = -2;
                break;
            case 2:
                newArmor.ArmorTypes = BaseArmor.ArmorType.Heavy;
                newArmor.ItemName = "Heavy Armor";
                newArmor.ItemDesc = "Heavy Armor, although very effective in combat, reduces the rate at which the carrier walks.";
                newArmor.Defense = Random.Range(newArmor.LevelRestriction * 15, newArmor.LevelRestriction * 20);
                newArmor.SpeedReduction = -4;
                newArmor.Weight = Random.Range(newArmor.LevelRestriction * 3, newArmor.LevelRestriction * 4);
                newArmor.RequiredStrength = Random.Range(newArmor.LevelRestriction * 3, newArmor.LevelRestriction * 4);
                break;
        }
    }

    public void DroppedArmor()
    {
        GameObject clone;
        clone = Instantiate(droppedArmor, Controls._Player.transform.position, transform.rotation) as GameObject;
        clone.AddComponent<DroppedArmor>().DropArmor(newArmor);
        Destroy(gameObject);
    }

    public void UpdateSelection()
    {
        Inventory._desc.text = newArmor.ItemDesc;
        Inventory._name.text = newArmor.ItemName;
        Inventory._image = newArmor.Icon;
    }
}
