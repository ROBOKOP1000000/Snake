using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<SnakeMovement>().enabled = false;
        Debug.Log("Game Over");
    }
}