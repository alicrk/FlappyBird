using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class hareketKontrol : MonoBehaviour
{
    public Sprite[] kusSprite;
    SpriteRenderer spriteRenderer;
    Rigidbody2D fizik;
    bool ileriGeriKontrol = true;
    int kusSayac = 0,puan = 0,enYuksekPuan = 0;
    float kusAnimasyonZaman = 0;
    public Text puanText;
    bool oyunBitti = true;
    oyunKontrol oyunKontrol;
    AudioSource [] sesler;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        fizik = GetComponent<Rigidbody2D>();

        oyunKontrol = GameObject.FindGameObjectWithTag("oyunKontrol").GetComponent<oyunKontrol>();

        sesler = GetComponents<AudioSource>();

        enYuksekPuan = PlayerPrefs.GetInt("kayit");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && oyunBitti)
        {
            fizik.velocity = new Vector2(0, 0);//hızı sıfırlar sonra kuvvet uygular...
            fizik.AddForce(new Vector2(0,200));
            sesler[0].Play();
        }
        if(fizik.velocity.y > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 45);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, -45);
        }

        ucmaAnimasyonu();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "puan")
        {
            puan++;
            puanText.text = "PUAN = "+puan;
            sesler[1].Play();
        }
        if (collision.gameObject.tag == "engel")
        {
        
            oyunBitti = false;
            oyunKontrol.oyunBitti();
            sesler[2].Play();
            GetComponent<CircleCollider2D>().enabled = false;

            if (puan > enYuksekPuan)
            {
                enYuksekPuan = puan;
                PlayerPrefs.SetInt("kayit", enYuksekPuan);
            }
            Invoke("anaMenuyeDon", 2);
        }
    }
    void anaMenuyeDon()
    {
        PlayerPrefs.SetInt("puanKayit",puan);
        SceneManager.LoadScene("anaEkran");
    }
    void ucmaAnimasyonu()
    {
        kusAnimasyonZaman += Time.deltaTime;
        if (kusAnimasyonZaman > 0.2f)
        {
            kusAnimasyonZaman = 0;

            if (ileriGeriKontrol)
            {
                spriteRenderer.sprite = kusSprite[kusSayac];
                kusSayac++;
                if (kusSayac == kusSprite.Length)
                {
                    kusSayac--;
                    ileriGeriKontrol = false;
                }
            }
            else
            {
                kusSayac--;
                spriteRenderer.sprite = kusSprite[kusSayac];
                if (kusSayac == 0)
                {
                    kusSayac++;
                    ileriGeriKontrol = true;
                }
            }
        }
    }
}
