using UnityEngine;
using System.Collections;

//Current gameobject will automatically add this components below
[RequireComponent(typeof(PlayerBehaviour))]

public class PlayerController : MonoBehaviour
{
    /*
     *  Controls how the Character Interacts with the avatar  
     *  
     *  Contributors :
     *      -   Harrison Campbell
     **/
    
    //Controls the playerActions
    private PlayerBehaviour playerActions;

    // Use this for initialization
    void Start()
    {
        playerActions = GetComponent<PlayerBehaviour>();
    }


    // Update is called once per frame
    void Update()
    {
        //Handles the touchScreen controls
        TouchControls();
        //Handles the Keyboard controls
        KeyboardControls();
    }

    //For Touch Controls
    private float minSwipeDistY;
    private float minSwipeDistX;
    private Vector2 startPos;
    //Handles Touch Screen Inputs !!!Hasn't been Tested!!!
    void TouchControls()
    {
        if (Input.touchCount > 0)
        {
            print("Touch registered");
            Touch touch = Input.touches[0];
            switch (touch.phase)
            {

                case TouchPhase.Began:
                    startPos = touch.position;
                    break;
                case TouchPhase.Ended:
                    float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
                    if (swipeDistVertical > minSwipeDistY)
                    {

                        float swipeValue = Mathf.Sign(touch.position.y - startPos.y);

                        //Swipe Up
                        if (swipeValue > 0)
                        {

                            playerActions.Move(Vector3.up);

                        }
                        //Swipe Down
                        else if (swipeValue < 0)
                        {

                            //Do Something
                        }
                    }

                    float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;

                    if (swipeDistHorizontal > minSwipeDistX)

                    {

                        float swipeValue = Mathf.Sign(touch.position.x - startPos.x);

                        //Swipe Right
                        if (swipeValue > 0)
                        {

                            playerActions.Move(Vector3.right);

                        }
                        //Swipe Left
                        else if (swipeValue < 0)
                        {

                            playerActions.Move(Vector3.left);
                        }
                    }
                    break;
            }
        }
    }
    //Handles Keyboard Inputs
    void KeyboardControls()
    {
        //If the player presses the left arrow key
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //The avatar will move left
            playerActions.Move(Vector3.left);
        }
        //If the player presses the right arrow key
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //The avatar will move right
            playerActions.Move(Vector3.right);
        }
        //If the player presses the up arrow key
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //The avatar will move up
            playerActions.Move(Vector3.up);
        }
    }

    //If the player collides...
    void OnCollisionEnter(Collision collision)
    {
        //With an enemy...
        if (collision.transform.tag.Equals("Enemy"))
        {
            //They will lose a life
            playerActions.LoseLife();
        //With money
        }else if (collision.transform.tag.Equals("Money"))
        {
            //They will destroy the object and collect the money
            print("Grabbed a coin");
            Destroy(collision.transform.gameObject);
        }
    }

}
