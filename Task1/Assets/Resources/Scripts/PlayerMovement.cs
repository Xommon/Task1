using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public bool selected;
    public Color startingColour;
    public Vector3 startingPosition;
    public Renderer renderer; 
    public Rigidbody rb;
    public float speed;
    public float timer;
    public bool onGround;

    // Start is called before the first frame update
    void Start()
    {
        // Get references
        renderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();

        // Define starting variables
        startingColour = renderer.material.color;
        startingPosition = rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            // Move the selected player
            rb.position += new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);
        }

        if (!onGround)
        {
            // Decrease the timer is the player has fallen off
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 7.0f;
        }

        if (timer <= 0)
        {
            // Return the player to the starting position
            rb.position = startingPosition;
            rb.rotation = Quaternion.identity;
        }

        if (selected)
        {
            // Change player colour if selected
            renderer.material.color = Color.red;
        }
        else
        {
            renderer.material.color = startingColour;
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            // Select all objects
            foreach (PlayerMovement player in FindObjectsOfType<PlayerMovement>())
            {
                player.selected = true;
            }
        }
    }

    private void OnMouseDown()
    {
        foreach (PlayerMovement player in FindObjectsOfType<PlayerMovement>())
        {
            // Unselect other players
            player.selected = false;
        }

        selected = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            // The player is on the ground as long as it touches the ground object
            onGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            // The player has fallen off of the edge of the map
            onGround = false;
        }
    }
}
