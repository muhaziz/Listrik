using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHeal : MonoBehaviour
{
    public GameObject ObjectHeal;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }

    public void getHeal()
    {

    }
}
