
/*
 * Class: AnimalController
 * Purpose: Controlling Animals
 * Component of: Animals
 * Fie
 *  Behaviors
 *  -MoveForward → Moves Animal
 *  -DeleteOutOfScene → Deletes Animal out of scene
 *  - OnFeedAnimalEnter() → Instantiates food
 *  - FeedAnimal() → Runs FeedAnimal on press
 *  Author: Sufian St. Denny
 *  Version: October 27, 2025
 */
using UnityEngine;
public class AnimalControler : MonoBehaviour
{
    [SerializeField] GameObject foodItEats;
    [SerializeField] float animalSpeed;
    private float lowerBound;
    private bool isOutOfScene;
    private bool notHungry;

     // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lowerBound = -15f;
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
        DeleteOutOfScene();
    }
    
    private void MoveForward()
    {

    }

    private void DeleteOutOfScene()
    {
     
      if (transform.position.z < lowerBound)

        {
            Destroy(gameObject);
        }
    }

    private bool IsFoodItEats(string foodTriggered)
    {
        string foodItEatsName = foodItEats.name;
        //remove Clones
        int cloneIndex = foodTriggered.IndexOf("(Clone)");
        if (cloneIndex != -1)
        {
            foodTriggered = foodTriggered.Substring(0, cloneIndex).Trim();
        }
        return foodTriggered.Equals(foodItEatsName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Food")&& !notHungry)
        {
            IsFoodItEats();
          if (IsFoodItEats = true)
            {
                Debug.Log($"Is FoodItEats");
            }
              

        }
        
    }


}
