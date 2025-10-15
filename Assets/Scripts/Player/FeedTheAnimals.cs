
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

    [SerializeField] private float maxForce;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] GameObject[] foods;
    //public fields

    private void FeedAnimal(int index, int foodCount, bool allFood)
    {
        Vector3 position = transform.position + new Vector3(0, 3, 0); //Sets position 2 meters above center of Player
        GameObject foodInstance = Instantiate(foods[index], position, Quaternion.identity);  //Adds food prefab to world
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
            string keyName = ctx.control.name;
            SelectFood(keyName);
        }
    }

        public void SelectFood(string keyName)
    {   
        switch (keyName)
        {
            case "Z":
                FeedAnimal(0, 1, false);
                break;
            case "X":
                FeedAnimal(1, 1, false);
                break;
            case "C":
                FeedAnimal(2, 15, false);
                break;
            case "V":
                FeedAnimal(3, 25, false);
                break;
            case " ":
                FeedAnimal(3, 24, true);
                break;
        }
    }

}
