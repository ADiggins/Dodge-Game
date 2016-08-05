using UnityEngine;
using System.Collections;

//Current gameobject will automatically add this components below
[RequireComponent(typeof(PlayerController))]

public class PlayerBehaviour : MonoBehaviour {

    bool movingCurrentlty;

    void Start()
    {
        HighScoreSystem.ResetScore();
        movingCurrentlty = false;
    }


    //Moves the player in the direction given
    public void Move(Vector3 direction)
    {
        //Checks if the player has made a valid move
        bool canMove = false;

        //if the player is moving up
        if(direction == Vector3.up)
        {
            //They can move up
            canMove = true;
        //If the player is moving left
        }else if(direction == Vector3.left)
        {
            //and their x position is greater than or equal to -1
            if(transform.localPosition.x >= -1)
            {
                //They can move left
                canMove = true;
            }
        }
        //If the player is moving right
        else if (direction == Vector3.right)
        {
            //and their x position is less than or equal to 1
            if (transform.localPosition.x <= 1)
            {
                //They can move right
                canMove = true;
            }
        }

        //Moves the player to the new location
        if (canMove)
        {
            StartCoroutine(slideToNewPos(direction));
        }
    }
    
    //Moves the player to the direction specified
    IEnumerator slideToNewPos(Vector3 direction)
    {
        //If the player is not currently moving
        if (!movingCurrentlty)
        {
            movingCurrentlty = true;//The player is moving
            //If the player is moving up add a point
            if (direction == Vector3.up)
            {
                HighScoreSystem.AddPoint();
            }
            
            //Keeps track of where abouts the player pos is between the starting point and the end point
            float inter = 0;
            float speed = Time.deltaTime * 12; //How fast the player is moving

            //Player Starting point at the beginning of animation
            Vector3 startPos = transform.position;
            //Player finishing point at the end of animation
            Vector3 endPos = startPos + direction;

            //While the player hasn't reached the finishing point 
            while (inter < 1)
            {
                //Move the player
                inter += speed;
                transform.position = Vector3.Lerp(startPos, endPos, inter);
                yield return new WaitForEndOfFrame();
            }
            //Player is no longer moving
            movingCurrentlty = false;
        }
    }

    //When the player collides with an enemy they lose a life
    public void LoseLife()
    {
        //Make Player Inactive
        gameObject.SetActive(false);
    }



	
}
