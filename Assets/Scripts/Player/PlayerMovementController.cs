using UnityEngine;
using UnityEngine.InputSystem;
/******************************************************************************  
 * Class: PlayerMovementController  
 * Purpose: Controls player movement based on input.  
 * Component Of: Player GameObject  
 * Fields: 
 *   - playerSpeed (float) → Controls movement speed.  
 *   - widthOfField (float) → Prevents movement beyond boundaries.  
 *   - moveDirection (float) → Stores input direction.    
 * Behaviors:
 *   - Start() → Initializes variables.  
 *   - Update() → Executes the PlayerMovement methods per frame.
 *   - OnMovementInput() → Handles player input events.
 *   - DeterminePlayerDirection() → Assigns player's move direction -1, 1, or 0 
 *                                  to determine the direction of motion: left, 
 *                                  right, or stationary.
 *   - PlayerMovement() → Processes movement logic.
 * Access: To enforce encapsulation only OnMovementInput() is visible
 * Author: Sufian St. Denny
 * Version: July 1, 2025 v. 1.0
 *******************************************************************************/

public class PlayerMovementController : MonoBehaviour
{

    [SerializeField] private float playerSpeed;
    private float moveDirection;
    private float centerToEdge;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        centerToEdge = 25f;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    public void OnMovementInput(InputAction.CallbackContext ctx)
    {
        DeterminesPlayerDirection(ctx.ReadValue<Vector2>());
    }



    private void DeterminesPlayerDirection(Vector2 value)
    {
        moveDirection = value.x;
    }

    //Process movement logic
    private void PlayerMovement()
    {
        transform.Translate(Vector3.right * playerSpeed * moveDirection * Time.deltaTime);

    }

}