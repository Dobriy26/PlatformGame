using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishView : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
      Debug.Log("Finish Level!!!");
   }

   private void OnCollisionEnter(Collision collision)
   {
      Debug.Log("Finish Level!!!");
   }
}
