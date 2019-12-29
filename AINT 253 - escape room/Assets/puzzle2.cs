using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class puzzle2 : MonoBehaviour
{
    public Image submarineUI;
    public GameObject increaseValve; // the two valves the player can interact with
    public GameObject decreaseValve;

    AudioSource failAudio; // the audio that plays when the player is failing the puzzle

    Vector3 player; // this is the origin of the raycast



    private void Start()
    {
        failAudio = GetComponent<AudioSource>();


    }

    private void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 20.0f))
            {

                if (hit.collider.gameObject.name == "IncreaseValve")
                {
                    Debug.Log("hit " + hit.collider.gameObject.name);

                    increaseValve.transform.Rotate(Vector3.left * 20 * Time.deltaTime); // rotate the valve
                    submarineUI.transform.Rotate(Vector3.left * 20 * Time.deltaTime);  // and increase the pitch of the submarine
                }
            }
        }
    }

    


}
