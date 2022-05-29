using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float swipeSpeed;

    Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            MoveChar();
        }
    }

    private void MoveChar()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = cam.transform.localPosition.z;

        Ray ray = cam.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            GameObject firstAnimal = scStacks.instance.animals[0];

            Vector3 hitvec = hit.point;
            hitvec.y = firstAnimal.transform.localPosition.y;
            hitvec.z = firstAnimal.transform.localPosition.z;

            firstAnimal.transform.localPosition = new Vector3(Mathf.Lerp(firstAnimal.transform.localPosition.x, hitvec.x, Time.deltaTime * swipeSpeed), firstAnimal.transform.localPosition.y, firstAnimal.transform.localPosition.z);
            //Vector3.MoveTowards(firstAnimal.transform.localPosition, hitvec, Time.deltaTime * swipeSpeed);
        }

    }
}
//move oke
