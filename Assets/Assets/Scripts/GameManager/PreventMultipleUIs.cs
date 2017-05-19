using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventMultipleUIs : MonoBehaviour {

//this script prevents mutipe UIs from being active at once. By that, it determines that only one istance of this script can be active at one time.

    void OnEnable()
    {
        GameManagerScript.isActive = true;
    }
    void OnDisable()
    {
        GameManagerScript.isActive = false;
    }
}
