using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public Sprite portrait;
    public List<TextAsset> text = new List<TextAsset>();
    public List<TextAsset> optionOne = new List<TextAsset>();
    public List<TextAsset> optionTwo = new List<TextAsset>();
    public List<TextAsset> optionThree = new List<TextAsset>();
    public string _name;
    public int nodeDestination;
    public int node;

    private void Start()
    {
        UI.dialogueBox.SetActive(true);
        UI.textField.text = text[Random.Range(0,text.Count)].ToString();
        UI.optionOne.text = optionOne[0].ToString();
        UI.optionTwo.text = optionTwo[0].ToString();
        UI.optionThree.text = optionThree[0].ToString();

        //assigning the listeners to the buttons
        UI.UIevent.SetSelectedGameObject(UI.optionOne.gameObject);
        UI.optionOne.gameObject.GetComponent<Button>().onClick.AddListener(() => { SetSelectedOption(-1, optionOne[0].text); });
        UI.optionTwo.gameObject.GetComponent<Button>().onClick.AddListener(() => { SetSelectedOption(-2, optionTwo[0].text); });
        UI.optionThree.gameObject.GetComponent<Button>().onClick.AddListener(() => { SetSelectedOption(-3, optionThree[0].text); });
    } 


    public void SetSelectedOption(int x, string response)
    {
        node = x;
        Debug.Log(node);
        UI.textField.text = response;
        //disabling the buttons
        UI.optionOne.gameObject.SetActive(false);
        UI.optionTwo.gameObject.SetActive(false);
        UI.optionThree.gameObject.SetActive(false);
    }

}
