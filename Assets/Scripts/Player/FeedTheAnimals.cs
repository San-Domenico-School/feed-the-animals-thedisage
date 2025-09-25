
/*
 * Class: FeedTheAnimals
 * Purpose: Handle feeding of animals.
 * Component of: Player
 * Fields
 *  -Food (serialize field) → sets a GameObject as food
 *  -Force (float) → Controls force with which food is thrown
 *  Behaviors
 *  - OnFeedAnimalEnter() → Instantiates food
 *  - FeedAnimal() → Runs FeedAnimal on press
 *  Author: Sufian St. Denny
 *  Version: August 27, 2025
 */
using UnityEngine;
using UnityEngine.InputSystem;
public class FeedTheAnimals : MonoBehaviour
{
    [SerializeField] private GameObject food;
    [SerializeField] private float maxForce;
    [SerializeField] private AudioSource audioSource;

    //public fields

    private void FeedAnimal(string name)
    {
        Vector3 position = transform.position + new Vector3(0, 2, 0); //Sets position 2 meters above center of Player
        GameObject foodInstance = Instantiate(food, position, Quaternion.identity);  //Adds food prefab to world
        Rigidbody foodRB = foodInstance.GetComponent<Rigidbody>();    //Set rigidbody of food
        foodRB.AddForce(Vector3.forward * maxForce, ForceMode.Impulse);  //Adds a forward impulse force to the                      
        audioSource.Play();                                                                 //food's rigidbody
    }
    //dynamic method that gets binding from player input map
    public void OnFeedInput(InputAction.CallbackContext ctx)
    {
        //Only feeds animals on start press.  Ignores ctx.proceed and ctx.cancel.
        if (ctx.started)
        {
            //Send name of button pressed to FeedAnimal
            FeedAnimal(ctx.control.name);

        }
    }

}
