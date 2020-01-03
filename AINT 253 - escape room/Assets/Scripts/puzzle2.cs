using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class puzzle2 : MonoBehaviour
{
    public Image submarineUI;
    public GameObject increaseValve; // the two valves the player can interact with
    public GameObject decreaseValve;

    public AudioSource failAudio; // the audio that plays when the player is failing the puzzle
    public Animator failAnimation; // the animation that will play when the player is struggling with the puzzle

    Vector3 player; // this is the origin of the raycast

  


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
                    increaseValve.transform.Rotate(Vector3.forward * 30 * Time.deltaTime); // rotate the valve
                    submarineUI.rectTransform.Rotate(Vector3.forward * 30 * Time.deltaTime);  // and increase the pitch of the submarine

                    decreaseValve.transform.Rotate(Vector3.back * 30 * Time.deltaTime); // rotate the opposite valve

                    Debug.Log("current sub's rotation is: " + submarineUI.rectTransform.localEulerAngles.z);
                }

                if (hit.collider.gameObject.name == "DecreaseValve")
                {
                    decreaseValve.transform.Rotate(Vector3.back * 30 * Time.deltaTime); // rotate the valve
                    submarineUI.rectTransform.Rotate(Vector3.back * 30 * Time.deltaTime);  // and increase the pitch of the submarine

                    increaseValve.transform.Rotate(Vector3.forward * 30 * Time.deltaTime);// rotate the opposite valve

                    Debug.Log("current sub's rotation is: " + submarineUI.rectTransform.localEulerAngles.z);
                }
            }
        }


        /*   
        A button in the game to start the puzzle is needed 



           
         
        if they successfully balance the puzzle for say 2 minutes then they win               
            
         */

        if (submarineUI.rectTransform.localEulerAngles.z > 45 || submarineUI.rectTransform.localEulerAngles.z > 340) // if the submarine tilt is too great
        {
            failAudio.Play();
            failAnimation.SetBool("Trigger Flashing", true);
            // alert the player they are close to failure
        }
        else
        {
            // cancel this when the player brings it under control
            failAnimation.SetBool("Trigger Flashing", false);
        }

        if (submarineUI.rectTransform.localEulerAngles.z > 80 || submarineUI.rectTransform.localEulerAngles.z > 360) // if the submarine tilt is far too great
        {

              FindObjectOfType<GameManager>().FailedGame(); // they have failed
        }
    }
}





