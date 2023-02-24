using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class HostSpace : MonoBehaviour
{
    public int _countDownTime = 60;

    void Update()
    {
        if (StartMenu.cameraChoice == 1)
        {
            StartCoroutine(CountDown());
        }
    }

    public IEnumerator CountDown()
    {
        while (_countDownTime > 0)
        {
            yield return new WaitForSeconds(1f);

            _countDownTime--;

            var evnt = CountDownTimerEvent.Create();
            evnt.CD = _countDownTime;
            evnt.Send();
        }
    }
}