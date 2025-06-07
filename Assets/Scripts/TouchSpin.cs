using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSpin : MonoBehaviour
{
    private Vector2 touchStartPos;
    private float rotationSpeed = 5f; // Increased sensitivity (from 1f to 5f)

    void Update()
    {
        // Check if there's one touch or mouse input
        if (Input.touchCount == 1) // For touch input
        {
            Touch touch = Input.GetTouch(0); // Get the first touch
            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position; // Record the start position
            }

            if (touch.phase == TouchPhase.Moved)
            {
                // Calculate how much the touch has moved horizontally
                float deltaX = touch.position.x - touchStartPos.x;

                // Rotate the object around its Y-axis based on the swipe distance
                transform.Rotate(0, deltaX * rotationSpeed * Time.deltaTime, 0);
                touchStartPos = touch.position; // Update the touch position
            }
        }
        else if (Input.GetMouseButtonDown(0)) // For mouse input (if you need desktop testing)
        {
            touchStartPos = Input.mousePosition; // Record mouse start position
        }
        else if (Input.GetMouseButton(0))
        {
            float deltaX = Input.mousePosition.x - touchStartPos.x;
            transform.Rotate(0, deltaX * rotationSpeed * Time.deltaTime, 0);
            touchStartPos = Input.mousePosition; // Update mouse position
        }
    }
}