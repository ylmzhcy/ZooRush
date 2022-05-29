using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Animal")
        {
            if (!scStacks.instance.animals.Contains(other.gameObject))
            {
                other.GetComponent<BoxCollider>().isTrigger = false;
                other.gameObject.tag = "Untagged";
                other.gameObject.AddComponent<scCollision>();
                other.gameObject.AddComponent<Rigidbody>();
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;

                scStacks.instance.StackAnimals(other.gameObject, scStacks.instance.animals.Count - 1);
            }
        }
    }
}

//collision oke
