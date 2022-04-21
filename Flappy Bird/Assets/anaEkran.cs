using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class anaEkran : MonoBehaviour
{
    public Text puanText;
    public Text puan;

    private void Start()
    {
        puan.text = " ";
        int enYuksekPuan = PlayerPrefs.GetInt("kayit");
        int puanGelen = PlayerPrefs.GetInt("puanKayit");
        puanText.text = "EN YÜKSEK PUAN = " + enYuksekPuan;
        puan.text = "PUAN = " + puanGelen;
            
    }
    public void oyunaBasla()
    {
        SceneManager.LoadScene("oyunEkrani");
    }
    public void oyundanÇik()
    {
        Application.Quit();
    }
}
