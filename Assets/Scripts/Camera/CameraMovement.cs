using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
   private void Start()
   {
      transform.rotation = Quaternion.Euler(40, 0, 0);
   }
}
