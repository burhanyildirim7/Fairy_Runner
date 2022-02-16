using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private GameObject _karakterPaketi;

    [SerializeField] private Slider _iyilikSlider;
    [SerializeField] private Slider _kotulukSlider;

    [SerializeField] private Text _buyuPuaniText;

    [SerializeField] private GameObject _fairyPaket;
    [SerializeField] private GameObject _fairy;
    [SerializeField] private GameObject _fairyCanvas;

    [SerializeField] private GameObject _konfeti1;
    [SerializeField] private GameObject _konfeti2;

    private int _elmasSayisi;

    private GameObject _player;

    private UIController _uiController;

    private int _toplananElmasSayisi;

    public static int _toplamBuyuDegeri;

    public static int _iyilikPuani;

    public static int _kotulukPuani;

    private CameraMovement _cameraMovement;



    void Start()
    {
        LevelStart();

        _uiController = GameObject.Find("UIController").GetComponent<UIController>();

    }

    private void Update()
    {

        if (GameController._oyunAktif)
        {
            _iyilikSlider.value = _iyilikPuani;
            _kotulukSlider.value = _kotulukPuani;
            _buyuPuaniText.text = _toplamBuyuDegeri.ToString();
        }
        else
        {

        }

    }




    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Elmas")
        {
            _elmasSayisi += 1;
            _toplananElmasSayisi += 1;
            PlayerPrefs.SetInt("ElmasSayisi", _elmasSayisi);
            Destroy(other.gameObject);
        }
        else if (other.tag == "FinishLine")
        {
            GameController._oyunuBeklet = true;
            _player = GameObject.FindWithTag("Player");
            _player.transform.localPosition = new Vector3(0, 0, 0);
        }
        else if (other.tag == "FinishPoint")
        {
            GameController._oyunAktif = false;
            _fairyCanvas.SetActive(false);


            _cameraMovement = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>();
            _cameraMovement.OyunSonuKameraKonum();

            GameController._oyunSonu = true;

            if (_iyilikPuani > 0)
            {
                _uiController.LevelSonuElmasSayisi((_toplamBuyuDegeri / 10) * _iyilikPuani);
            }
            else if (_kotulukPuani > 0)
            {
                _uiController.LevelSonuElmasSayisi((_toplamBuyuDegeri / 10) * _kotulukPuani);
            }
            else
            {
                _uiController.LevelSonuElmasSayisi(_toplamBuyuDegeri);
            }


            _konfeti1.SetActive(true);
            _konfeti2.SetActive(true);

            _fairy.GetComponent<Animation>().CrossFade("fly inplace");

            _player = GameObject.FindWithTag("Player");
            _player.transform.localPosition = new Vector3(0, 0, 0);

            _fairyPaket.transform.localRotation = Quaternion.Euler(0, 180, 0);
            _fairy.transform.localPosition = new Vector3(0, 2.5f, 0);

            Invoke("WinScreenAc", 1f);
        }
        else
        {

        }
    }

    private void WinScreenAc()
    {
        _uiController.WinScreenPanelOpen();
    }

    private void LoseScreenAc()
    {
        _uiController.LoseScreenPanelOpen();
    }




    public void LevelStart()
    {
        GameController._oyunSonu = false;

        _toplananElmasSayisi = 1;
        _toplamBuyuDegeri = 0;
        _iyilikPuani = 0;
        _kotulukPuani = 0;

        _iyilikSlider.value = _iyilikPuani;
        _kotulukSlider.value = _kotulukPuani;
        _buyuPuaniText.text = _toplamBuyuDegeri.ToString();
        _fairyCanvas.SetActive(true);

        _konfeti1.SetActive(false);
        _konfeti2.SetActive(false);

        _elmasSayisi = PlayerPrefs.GetInt("ElmasSayisi");
        _karakterPaketi.transform.position = new Vector3(0, 0, 0);
        _karakterPaketi.transform.rotation = Quaternion.Euler(0, 0, 0);
        _player = GameObject.FindWithTag("Player");
        _player.transform.localPosition = new Vector3(0, 0, 0);
        _fairyPaket.transform.localRotation = Quaternion.Euler(0, 0, 0);
        _fairy.transform.localPosition = new Vector3(0, 0, 0);

        _fairy.GetComponent<Animation>().CrossFade("fly inplace");

        _cameraMovement = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>();
        _cameraMovement.KameraResetle();

    }

    public void FairyAttackAnimation()
    {

        StartCoroutine(AnimationControl());
        //_fairy.GetComponent<Animation>().CrossFade("fly attack 2");

        //_fairy.GetComponent<Animation>().CrossFade("fly forward", 1f);

        //Invoke("AnitaionIptal", 0.5f);

        //AnimationIptal();
    }

    IEnumerator AnimationControl()
    {
        _fairy.GetComponent<Animation>().CrossFade("fly attack 2");

        yield return new WaitForSeconds(0.8f);

        _fairy.GetComponent<Animation>().CrossFade("fly forward");
    }

    private void AnimationIptal()
    {
        _fairy.GetComponent<Animation>().CrossFade("fly forward");
    }

    public void UcmaAnimation()
    {
        _fairy.GetComponent<Animation>().CrossFade("fly forward");
    }



}
