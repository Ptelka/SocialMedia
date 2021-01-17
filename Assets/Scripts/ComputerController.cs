using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerController : MonoBehaviour
{
    [SerializeField] private Camera cam;

    public Camera GetComputerCamera()
    {
        return cam;
    }
}
