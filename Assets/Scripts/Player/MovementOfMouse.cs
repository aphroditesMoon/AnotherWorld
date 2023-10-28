using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementOfMouse : MonoBehaviour
{
    public float rotationSpeed = 10.0f; // Dönme hızı
    private bool isRotating = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Sol tık basıldığında
        {
            isRotating = true;
        }

        if (Input.GetMouseButtonUp(0)) // Sol tık bırakıldığında
        {
            isRotating = false;
            Cursor.visible = true;
        }

        if (isRotating)
        {
            float mouseX = Input.GetAxis("Mouse X"); // Fare hareketini al
            float mouseY = Input.GetAxis("Mouse Y");

            // Dönme işlemi
            transform.Rotate(Vector3.up, mouseX * rotationSpeed * Time.deltaTime);
            Cursor.visible = false;
        }
    }
}
