using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _tapToStartPanel;
    [SerializeField] private GameObject _gameScreenPanel;
    [SerializeField] private GameObject _winScreenPanel;
    [SerializeField] private GameObject _winScreenIyiPanel;
    [SerializeField] private GameObject _winScreenKotuPanel;
    [SerializeField] private GameObject _loseScreenPanel;

    [SerializeField] private Text _levelText;
    [SerializeField] private Text _elmasText;
    [SerializeField] private Text _winElmasIyiText;
    [SerializeField] private Text _winElmasKotuText;
    [SerializeField] private Text _loseElmasText;
    [SerializeField] private Text _tapToStartElmasText;

    private int _levelNumber;

    private int _elmasSayisi;

    private PlayerController _playerController;

    private LevelController _levelController;

    private int _levelSonuElmasSayisi;

    private int _oyunBasladi;

    void Start()
    {

        //PlayerPrefs.DeleteAll();

        _tapToStartPanel.SetActive(true);

        _levelNumber = PlayerPrefs.GetInt("LevelNumber");

        _oyunBasladi = PlayerPrefs.GetInt("OyunBasladi");
        if (_oyunBasladi == 0)
        {
            PlayerPrefs.SetInt("LevelNumber", 1);
            _oyunBasladi = 1;
            PlayerPrefs.SetInt("OyunBasladi", _oyunBasladi);
        }
        else
        {

        }

        _elmasSayisi = PlayerPrefs.GetInt("ElmasSayisi");

        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        _levelController = GameObject.Find("LevelController").GetComponent<LevelController>();

        _tapToStartElmasText.text = _elmasSayisi.ToString();


    }


    void Update()
    {
        _levelNumber = PlayerPrefs.GetInt("LevelNumber");

        _elmasSayisi = PlayerPrefs.GetInt("ElmasSayisi");


        _levelText.text = "LEVEL " + (_levelNumber);


        _elmasText.text = _elmasSayisi.ToString();
    }

    public void TaptoStartPanelClose()
    {
        GameController._oyunAktif = true;
        GameController._oyunuBeklet = false;
        _tapToStartPanel.SetActive(false);
        _gameScreenPanel.SetActive(true); _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        _playerController.UcmaAnimation();
    }

    public void WinScreenPanelOpen()
    {
        _gameScreenPanel.SetActive(false);
        _winScreenPanel.SetActive(true);

        if (PlayerController._iyilikPuani > 0)
        {
            _winScreenIyiPanel.SetActive(true);
            _winElmasIyiText.text = _levelSonuElmasSayisi.ToString();
        }
        else if (PlayerController._kotulukPuani > 0)
        {
            _winScreenKotuPanel.SetActive(true);
            _winElmasKotuText.text = _levelSonuElmasSayisi.ToString();
        }
        else
        {
            _winScreenIyiPanel.SetActive(true);
            _winElmasIyiText.text = _levelSonuElmasSayisi.ToString();
        }


    }

    public void LoseScreenPanelOpen()
    {
        _gameScreenPanel.SetActive(false);
        _loseScreenPanel.SetActive(true);
        _loseElmasText.text = _levelSonuElmasSayisi.ToString();
    }

    public void NextLevelButton()
    {
        GameController._oyunAktif = false;
        _winScreenPanel.SetActive(false);
        _winScreenIyiPanel.SetActive(false);
        _winScreenKotuPanel.SetActive(false);
        _loseScreenPanel.SetActive(false);
        _tapToStartPanel.SetActive(true);
        _elmasSayisi = _elmasSayisi + _levelSonuElmasSayisi;
        PlayerPrefs.SetInt("ElmasSayisi", _elmasSayisi);
        _tapToStartElmasText.text = _elmasSayisi.ToString();
        _levelController.LevelDegistir();
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        _playerController.LevelStart();
    }

    public void LevelSonuElmasSayisi(int deger)
    {
        _levelSonuElmasSayisi = deger;
    }

    public void LevelRestartButton()
    {
        GameController._oyunAktif = false;
        _winScreenPanel.SetActive(false);
        _loseScreenPanel.SetActive(false);
        _tapToStartPanel.SetActive(true);
        _elmasSayisi = _elmasSayisi + _levelSonuElmasSayisi;
        PlayerPrefs.SetInt("ElmasSayisi", _elmasSayisi);
        _tapToStartElmasText.text = _elmasSayisi.ToString();
        _levelController.LevelRestart();
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        _playerController.LevelStart();
    }

}
