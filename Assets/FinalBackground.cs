using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBackground : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * 0.7f);
    }
}
