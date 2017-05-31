using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDybbukShop : MonoBehaviour {

	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown("return") && !UI.dibbukShop.activeSelf && !GameManagerScript.isActive)
        {
            StartCoroutine(EnterShop());
            Controls controls = GameManagerScript.player.GetComponent<Controls>();
            controls.anim.speed = 0;
            controls.reflectionAnim.speed = 0;
            controls.enabled = false;
        }
	}

    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Interact"))
        {
                Controls.question.SetActive(true);
                gameObject.GetComponent<EnterDybbukShop>().enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interact"))
        {
            Controls.question.SetActive(false);
            gameObject.GetComponent<EnterDybbukShop>().enabled = false;
        }
    }

    IEnumerator EnterShop()
    {
        UI.screenEffect.Play("FadeOut");
        yield return new WaitForSeconds(2f);
        UI.dibbukShop.SetActive(true);
        UI.screenEffect.Play("FadeIn");
        yield return new WaitForSeconds(2f);
    }
}
