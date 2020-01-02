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
    public Animation failAnimation; // the animation that will play when the player is struggling with the puzzle

    Vector3 player; // this is the origin of the raycast



    private void Start()
    {
        failAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 20.0f))
            {

                if (hit.collider.gameObject.name == "IncreaseValve")
                {
                    Debug.Log("hit " + hit.collider.gameObject.name);

                    decreaseValve.transform.Rotate(Vector3.back * 50 * Time.deltaTime); // rotate the opposite valve

                    increaseValve.transform.Rotate(Vector3.forward * 50 * Time.deltaTime); // rotate the valve
                    submarineUI.transform.Rotate(Vector3.forward * 50 * Time.deltaTime);  // and increase the pitch of the submarine
                }

                if (hit.collider.gameObject.name == "DecreaseValve")
                {
                    Debug.Log("hit " + hit.collider.gameObject.name);

                    increaseValve.transform.Rotate(Vector3.forward * 50 * Time.deltaTime);// rotate the opposite valve

                    decreaseValve.transform.Rotate(Vector3.back * 50 * Time.deltaTime); // rotate the valve
                    submarineUI.transform.Rotate(Vector3.back * 50 * Time.deltaTime);  // and increase the pitch of the submarine

                }

                if (submarineUI.transform.rotation.z < 60 || submarineUI.transform.rotation.z < -60) // if the submarine tilt is too great
                {
                    failAudio.Play(); // alert the player they are close to failure
                    failAnimation.Play();
                }
                else
                {
                    failAudio.Stop(); // cancel this when the player brings it under control
                    failAnimation.Stop();
                }

                if (submarineUI.transform.rotation.z < 80 || submarineUI.transform.rotation.z < -80) // if the submarine tilt is too great
                {
                    FindObjectOfType<GameManager>().EndGame(); // they have failed
                }

            }
        }
    }
}





