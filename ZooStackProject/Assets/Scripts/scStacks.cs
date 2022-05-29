using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class scStacks : MonoBehaviour
{
    public static scStacks instance;
    public float movementDelay = 0.05f;

    public List<GameObject> animals = new List<GameObject>();
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            MoveListElements();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            MoveOrigin();
        }

    }


    public void StackAnimals(GameObject other, int index)
    {
        other.gameObject.transform.parent = transform;
        Vector3 newPos = animals[index].transform.localPosition;
        newPos.z += 1;
        other.transform.localPosition = newPos;
        animals.Add(other);
        StartCoroutine(MakeObjectsBigger());
    }

    private IEnumerator MakeObjectsBigger()
    {
        for (int i = animals.Count - 1; i > 0; i--)
        {
            int index = i;
            Vector3 scale = new Vector3(1, 1, 1);
            scale *= 1.5f;
            animals[index].transform.DOScale(scale, 0.1f).OnComplete(() =>
            animals[index].transform.DOScale(new Vector3(1, 1, 1), 0.1f)
            );
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void MoveListElements()
    {
        for (int i = 1; i < animals.Count; i++)
        {
            Vector3 pos = animals[i].transform.localPosition;
            pos.x = animals[i - 1].transform.localPosition.x;
            animals[i].transform.DOLocalMove(pos, movementDelay);
        }
    }

    private void MoveOrigin()
    {
        for (int i = 1; i < animals.Count; i++)
        {
            Vector3 pos = animals[i].transform.localPosition;
            pos.x = animals[0].transform.localPosition.x;
            animals[i].transform.DOLocalMove(pos, 0.7f);
        }
    }
}
