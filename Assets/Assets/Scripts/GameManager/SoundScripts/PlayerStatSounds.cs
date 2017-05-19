using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatSounds : MonoBehaviour {
    [Header("audio sounds are Children of this gameobject")]
    [SerializeField]
    AudioSource _on;
    [SerializeField]
    AudioSource _off;
    [SerializeField]
    AudioSource _emptyClick;
    [SerializeField]
    AudioSource _click;

    public static AudioSource click;
    public static AudioSource emptyClick;
    public static AudioSource on;
    public static AudioSource off;


    void Awake ()
    {
        click = _click;
        emptyClick = _emptyClick;
        on = _on;
        off = _off;
    }
	

}
