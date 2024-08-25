using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(CoEnd());
    }

    IEnumerator CoEnd()
    {
        yield return new WaitForSeconds(0.2f);
        Object.Destroy(this.gameObject);
    }
}
