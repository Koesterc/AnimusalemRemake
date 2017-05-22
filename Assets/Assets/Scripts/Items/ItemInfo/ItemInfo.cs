using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : MonoBehaviour {

    float canDisable;

    private void OnEnable()
    {
    }


	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("return"))
        {
            Time.timeScale = GameManagerScript.gameSpeed;
            gameObject.SetActive(false);
        }
	}
}
