
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
    
    [SerializeField] GameObject[] foods;
    //public fields
    public void OnFeedInput(InputAction.CallbackContext ctx)
    {
        Debug.Log($"ctx started");
        //Only feeds animals on start press.  Ignores ctx.proceed and ctx.cancel.
        if (ctx.started)
        {
            //Send name of button pressed to FeedAnimal
            string keyName = ctx.control.name;
            SelectFood(keyName);
            
        }
    }

    private void FeedAnimal(int index, int foodCount, bool allFood)
    {
        Vector3 position = transform.position + new Vector3(0, 2, 0); //Sets position 3 meters above center of Player

        if (allFood)
        {
            Debug.Log($"allFood started");
            //loop thru all food prefabs
                for (int i = 0; i < foodCount; i++)
        {
            Debug.Log($"For loop");
            GameObject foodsInstance = Instantiate(foods[index], position, Quaternion.identity);
            Rigidbody foodsRB = foodsInstance.GetComponent<Rigidbody>(); //Set rigidbody of food
            foodsRB.AddForce(Vector3.forward * maxForce, ForceMode.Impulse);
        }
            foreach (GameObject foodPrefab in foods)
            {
            
                for (int i = 0; i < foodCount; i++)
                {
                    GameObject foodInstance = Instantiate(foodPrefab, position, Quaternion.identity);
                    Rigidbody foodRB = foodInstance.GetComponent<Rigidbody>();
                    foodRB.AddForce(Vector3.forward * maxForce, ForceMode.Impulse);
                }
            }
        }

    }
    //dynamic method that gets binding from player input map

    public void SelectFood(string keyName)
    {   
        switch (keyName)
        {
            case "z":
                FeedAnimal(0, 1, false);
                Debug.Log($"z pressed");
                break;
            case "x":
                FeedAnimal(1, 1, false);
                Debug.Log($"x pressed");
                break;
            case "c":
                FeedAnimal(2, 15, false);
                Debug.Log($"c pressed");
                break;
            case "v":
                FeedAnimal(3, 25, false);
                Debug.Log($"v pressed");
                break;
            case "space":
                Debug.Log($"space pressed");
                FeedAnimal(3, 25, true);
                break;
        }
    }

}
