using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static bool _oyunAktif;

    public static bool _oyunuBeklet;

    public static bool _oyunSonu;

    void Start()
    {
        _oyunAktif = false;

        _oyunuBeklet = false;

        _oyunSonu = false;

    }


}
