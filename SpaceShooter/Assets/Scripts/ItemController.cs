using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public GameObject boomUIPrefab;
    public float itemSpeed;

    private void Start()
    {
        StartCoroutine(this.CoMove());
    }

    IEnumerator CoMove()
    {
        while (true)
        {
            this.transform.Translate(Vector3.down * itemSpeed * Time.deltaTime);
            if (this.transform.position.y < -5.68f)
            {
                Object.Destroy(this.gameObject);
            }
            yield return null;
        }
    }

    //�÷��̾�� ������� ȿ���� �����ϰ� ��������Ѵ�.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Shooter")
        {
            //�����ۺз�

            string itemName = this.gameObject.name;

            switch (itemName)
            {
                case "Coin(Clone)":
                    break;
                case "Boom(Clone)":
                    GameObject boomUIGo = Object.Instantiate(this.boomUIPrefab);
                    boomUIGo.transform.position = new Vector3(2.39f, 4.69f, 0);
                    break;
                case "Power(Clone)":
                    break;

            }

            Object.Destroy (this.gameObject);
        }
    }
}
