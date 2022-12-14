using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
   Vector3 mousePos;
   bool isMove = false;

   // Update is called once per frame
   void Update()
   {
       if (!isMove && Input.GetMouseButton(0))
       {
           mousePos = Input.mousePosition;
           this.gameObject.transform.position = mousePos;
           isMove = true;
       }
   }
}