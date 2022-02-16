using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToplanabilirBuyuScript : MonoBehaviour
{

    [SerializeField] private int _toplanabilirBuyuDeger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Peri")
        {
            MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);

            PlayerController._toplamBuyuDegeri += _toplanabilirBuyuDeger;
            //Debug.Log("Toplam Buyu Degeri = " + PlayerController._toplamBuyuDegeri.ToString());
            Destroy(gameObject);
        }
    }
}
