using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySounds : MonoBehaviour {
    [SerializeField]
    AudioSource _select;
    [SerializeField]
    AudioSource _drop;

    public static AudioSource select;
    public static AudioSource drop;

    // Use this for initialization
    void Start ()
    {
        select = _select;
        drop = _drop;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
