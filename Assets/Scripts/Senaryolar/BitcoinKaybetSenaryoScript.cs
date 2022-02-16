using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitcoinKaybetSenaryoScript : MonoBehaviour
{
    [SerializeField] private int _gerekliBuyuPuani;
    [SerializeField] private int _oyuncuyaVerilecekPuan;

    [SerializeField] private Animator _humanAnimator;

    [SerializeField] private List<GameObject> _acilacakObjeler = new List<GameObject>();
    [SerializeField] private List<GameObject> _kapanacakObjeler = new List<GameObject>();

    //[SerializeField] private GameObject _canvas;

    private int _levelNumber;

    private PlayerController _playerController;

    void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        _levelNumber = PlayerPrefs.GetInt("LevelNumber");


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);

            if (PlayerController._toplamBuyuDegeri >= _gerekliBuyuPuani)
            {
                other.GetComponent<PlayerController>().FairyAttackAnimation();

                PlayerController._toplamBuyuDegeri -= _gerekliBuyuPuani;

                if (PlayerController._iyilikPuani > 0)
                {
                    PlayerController._iyilikPuani -= _oyuncuyaVerilecekPuan;
                }
                else
                {
                    PlayerController._kotulukPuani += _oyuncuyaVerilecekPuan;
                }


                _kapanacakObjeler[0].SetActive(false);
                _kapanacakObjeler[1].SetActive(false);
                _kapanacakObjeler[2].SetActive(false);

                _acilacakObjeler[0].SetActive(true);
                _acilacakObjeler[1].SetActive(true);
                _acilacakObjeler[2].SetActive(true);
                _acilacakObjeler[3].SetActive(true);

                _humanAnimator.SetBool("Defeat", true);

                // _canvas.SetActive(false);

                //Debug.Log("Kotu Insan");
                //Debug.Log("Kotuluk Puani = " + PlayerController._kotulukPuani.ToString());
                //Debug.Log("Gerekli Buyu Puani = " + _gerekliBuyuPuani.ToString());
            }
            else
            {
                //Debug.Log("Buyu Puani Yetersiz!!!");
            }


        }
    }
}
