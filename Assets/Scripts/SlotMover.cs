using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SlotMover : MonoBehaviour
{
    private int randomValue;
    private float timeInterval;                 //Use for rotation speed.

    private bool rowStopped;
    // Start is called before the first frame update
    void Start()
    {
        rowStopped = true;
    }

    public void StartRotating()
    {
        StartCoroutine(RotateSlot());
    }

    IEnumerator RotateSlot()
    {
        rowStopped = false;
        timeInterval = 0.025f;

        randomValue = Random.RandomRange(60, 100);

        switch (randomValue % 3)            //to calculate if the values are divisible by 3.
        {
            case 1:
                randomValue += 2;           //increase 2 steps if the reminder is 1.
                break;
            case 2:
                randomValue += 1;          //increase 1 step if the reminder is 2.
                break;
        }

        for (int i = 0; i < randomValue; i++)
        {
            // Rotation of slot.
            if (transform.position.y <= -2)
            {
                transform.position = new Vector2(transform.position.x, 3);  //Looping of slot to initial position.
            }

            transform.position = new Vector2(transform.position.x, transform.position.y - 0.75f); //Moving of slot in y axis.

            //Decreasing of slot speed due to time period.
            if (i > Mathf.RoundToInt(randomValue * 0.25f))
            {
                timeInterval = 0.05f;
            }
            if (i > Mathf.RoundToInt(randomValue * 0.5f))
            {
                timeInterval = 0.1f;
            }
            if (i > Mathf.RoundToInt(randomValue * 0.75f))
            {
                timeInterval = 0.15f;
            }
            if (i > Mathf.RoundToInt(randomValue * 0.95f))
            {
                timeInterval = 0.2f;
            }

            yield return new WaitForSeconds(timeInterval);
        }


        // Setting final position after each spin.
        if (transform.position.y == -1.5f)
        {
            transform.position = new Vector2(transform.position.x, -2.3f);
        }
        if (transform.position.y == -0.75f || transform.position.y == 0f)
        {
            transform.position = new Vector2(transform.position.x, -0.5f);
        }
        if (transform.position.y == 2.5f)
        {
            transform.position = new Vector2(transform.position.x, 3);
        }
        if (transform.position.y == 2.25f || transform.position.y == 0.75f)
        {
            transform.position = new Vector2(transform.position.x, 1.5f);
        }

    }
}
