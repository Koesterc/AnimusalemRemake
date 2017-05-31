using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Xml.Serialization;

public class DialogueNPC : MonoBehaviour {

    [SerializeField]
    private Dialogue dialogue;
    [SerializeField]
    GameObject dialogueWindow;
    [SerializeField]
    GameObject optionOne;
    [SerializeField]
    GameObject optionTwo;
    [SerializeField]
    GameObject optionThree;
    [SerializeField]
    GameObject exit;
    [SerializeField]
    GameObject nodeText;
    [SerializeField]
    GameObject dialogueBox;

    //ints
    private int selectedOption = -2;
    [SerializeField]
    string dialogueDataFilePath;

    void Start()
    {
        dialogue = LoadDialogue("Assets/Scripts/Dialogue/" + dialogueDataFilePath);

        exit.GetComponent<Button>().onClick.AddListener(delegate { SetSelectedOption(-1); });
        RunDialogue();

    }

    private void SetOptionButton(GameObject button, DialogueOptions options)
    {
        button.SetActive(true);
        button.GetComponent<Text>().text = options.tempText;
        exit.GetComponent<Button>().onClick.AddListener(delegate { SetSelectedOption(options.destinationNodeID); });
    }

     public static Dialogue LoadDialogue(string path)
    {
        XmlSerializer serz = new XmlSerializer(typeof(Dialogue));
        StreamReader reader = new StreamReader(path);
        Dialogue dialogue = (Dialogue)serz.Deserialize(reader);
        return dialogue;
    }

    public void RunDialogue()
    {
        StartCoroutine(Run());
    }

    public IEnumerator Run()
    {
        dialogueBox.SetActive(true);
        int nodeID = 0;
        while (nodeID != -1)
        {
            DisplayNode(dialogue.nodes[nodeID]);
            selectedOption -= 2;
            while (nodeID == -2)
            {
                yield return new WaitForSeconds(.25f);
            }
            nodeID = selectedOption;
        }
        dialogueWindow.SetActive(false);
    }

    public void SetSelectedOption (int x)
    {
        selectedOption = x;
    }
    private void DisplayNode(DialogueNode node)
    {
        nodeText.GetComponent<Text>().text = node.tempText;
        optionOne.SetActive(false);
        optionTwo.SetActive(false);
        optionThree.SetActive(false);

        for (int i = 0; i < node.options.Count && i < 3; i++)
        {
            switch (i)
            {
                default:
                    SetOptionButton(optionOne, node.options[i]);
                    break;
                case 2:
                    SetOptionButton(optionTwo, node.options[i]);
                    break;
                case 3:
                    SetOptionButton(optionThree, node.options[i]);
                    break;
            }
        }
    }
}
