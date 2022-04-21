using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyunKontrol : MonoBehaviour
{
    public GameObject gokyuzu1, gokyuzu2;
    Rigidbody2D fizik1, fizik2,fizikEngel;
    float uzunluk = 0;
    float arkaplanHız = -1.5f,engelZaman = 0;
    public GameObject engel;
    public int engelSayisi = 7;
    GameObject[] engeller;
    int sayac = 0;
    bool oyunBittiMi = true;
    void Start()
    {
        fizik1 = gokyuzu1.GetComponent<Rigidbody2D>();
        fizik2 = gokyuzu2.GetComponent<Rigidbody2D>();


        uzunluk = gokyuzu1.GetComponent<BoxCollider2D>().size.x;

        fizik1.velocity = new Vector2(arkaplanHız, 0);
        fizik2.velocity = new Vector2(arkaplanHız, 0);

        engeller = new GameObject[engelSayisi];

        for (int i = 0; i <engeller.Length; i++)
        {
            engeller[i] = Instantiate(engel,new Vector2(-20,-20),Quaternion.identity);
            fizikEngel = engeller[i].GetComponent<Rigidbody2D>();
            fizikEngel.gravityScale = 0;
            fizikEngel.velocity = new Vector2(arkaplanHız, 0);
        }
    }

    void Update()
    {
        if (oyunBittiMi)
        {
            if (gokyuzu1.transform.position.x <= -uzunluk)
            {
                gokyuzu1.transform.position += new Vector3(uzunluk * 2, 0);
            }
            if (gokyuzu2.transform.position.x <= -uzunluk)
            {
                gokyuzu2.transform.position += new Vector3(uzunluk * 2, 0);
            }

            //----------------------------------------------------------------

            engelZaman += Time.deltaTime;
            if (engelZaman > 2f)
            {
                engelZaman = 0;
                float yEkseni = Random.Range(-0.5f, 1f);
                engeller[sayac].transform.position = new Vector3(9.5f, yEkseni);
                sayac++;
                if (sayac >= engeller.Length)
                {
                    sayac = 0;
                }

            }
        }
    }
    public void oyunBitti()
    {
        for (int i = 0; i < engeller.Length; i++)
        {
            engeller[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            fizik1.velocity = Vector2.zero;
            fizik2.velocity = Vector2.zero;
        }
        oyunBittiMi = false;
    }
}
