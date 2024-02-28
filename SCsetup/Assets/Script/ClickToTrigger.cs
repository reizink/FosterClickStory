using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToTrigger : MonoBehaviour
{
    private GameObject clickedObj;

    void Update()
    { 
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if(hit.collider != null)
            {
                if(hit.collider.gameObject.tag == "Clickable")
                {
                    clickedObj = hit.collider.gameObject;
                    HandleClick();
                }
            }
        }
    }

    private void HandleClick()
    {
        DialogueTrigger dialogueTrigger = clickedObj.GetComponent<DialogueTrigger>();
        if(dialogueTrigger != null)
        {
            dialogueTrigger.TriggerDialogue();
            clickedObj.SetActive(false);
        }
    }
}
