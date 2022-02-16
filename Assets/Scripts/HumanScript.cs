using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanScript : MonoBehaviour
{
    [SerializeField] private bool _iyiInsan;
    [SerializeField] private bool _kotuInsan;
    [SerializeField] private int _gerekliBuyuPuani;
    [SerializeField] private int _oyuncuyaVerilecekPuan;

    private PlayerController _playerController;

    void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (_iyiInsan)
            {
                if (PlayerController._toplamBuyuDegeri >= _gerekliBuyuPuani)
                {
                    PlayerController._toplamBuyuDegeri -= _gerekliBuyuPuani;
                    PlayerController._iyilikPuani += _oyuncuyaVerilecekPuan;
                    Debug.Log("Iyi Insan");
                    Debug.Log("Iyilik Puani = " + PlayerController._iyilikPuani.ToString());
                    Debug.Log("Gerekli Buyu Puani = " + _gerekliBuyuPuani.ToString());
                }
                else
                {
                    Debug.Log("Buyu Puani Yetersiz!!!");
                }

            }
            else if (_kotuInsan)
            {
                if (PlayerController._toplamBuyuDegeri >= _gerekliBuyuPuani)
                {
                    PlayerController._toplamBuyuDegeri -= _gerekliBuyuPuani;
                    PlayerController._kotulukPuani += _oyuncuyaVerilecekPuan;
                    Debug.Log("Kotu Insan");
                    Debug.Log("Kotuluk Puani = " + PlayerController._kotulukPuani.ToString());
                    Debug.Log("Gerekli Buyu Puani = " + _gerekliBuyuPuani.ToString());
                }
                else
                {
                    Debug.Log("Buyu Puani Yetersiz!!!");
                }

            }
        }
    }
}
