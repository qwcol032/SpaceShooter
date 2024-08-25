using System.Collections;
using UnityEngine;

public class GameMangerController : MonoBehaviour
{
    GameObject backGroundPrefep;

    void Start()
    {
        StartCoroutine(CoMakeBackGrounds());
    }


    IEnumerator CoMakeBackGrounds()
    {
        while (true)
        {

            GameObject backGroundGo = Instantiate(backGroundPrefep);
            backGroundGo.transform.position = new Vector3(0, (float)11.13, 1);
            yield return null;
        }
    }
}
