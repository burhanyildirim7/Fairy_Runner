using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private GameObject Player;

    Vector3 aradakiFark;

    private GameObject _karakterPaketi;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        aradakiFark = transform.position - Player.transform.position;
    }


    void Update()
    {
        if (GameController._oyunAktif)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(Player.transform.position.x, Player.transform.position.y + aradakiFark.y, Player.transform.position.z + aradakiFark.z), Time.deltaTime * 5f);
        }
        else if (GameController._oyunSonu)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, 10.5f, _karakterPaketi.transform.position.z - 9f), Time.deltaTime * 5f);
        }
        else
        {

        }


    }

    public void OyunSonuKameraKonum()
    {
        _karakterPaketi = GameObject.FindGameObjectWithTag("KarakterPaketi");
    }

    public void KameraResetle()
    {
        transform.position = new Vector3(0, 12, -15);
        aradakiFark = transform.position - Player.transform.position;
    }

}
