using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEnabler : MonoBehaviour
{
    BetterPlayerController playerController;

    private void Start()
    {
        playerController = GetComponent<BetterPlayerController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            playerController.modifyDashState(true);
        }
        else if (Input.GetKeyUp(KeyCode.L))
        {
            playerController.modifyDashState(false);
        }
    }
}
