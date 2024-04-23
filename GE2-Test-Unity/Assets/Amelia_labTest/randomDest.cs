using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomDest : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(move());
    }
    IEnumerator move()
    {
        var randVec = new Vector3(Random.value, Random.value, Random.value);
        gameObject.transform.position = randVec;
        Debug.Log("Move random");

        yield return new WaitForSeconds(10f);
    }
}
