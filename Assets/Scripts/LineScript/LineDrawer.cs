using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public LineRenderer line;
    public Transform pos1;
    public Transform pos2;

    Vector3 posCorrection = new Vector3(0, 2f, 0);

    private void Start()
    {
        line.positionCount = 2;

    }

    private void Update()
    {
        line.SetPosition(0, pos1.position + posCorrection);
        line.SetPosition(1, pos2.position + posCorrection);
    }
}
