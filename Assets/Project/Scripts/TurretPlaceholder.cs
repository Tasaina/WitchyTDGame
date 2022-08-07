using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlaceholder : MonoBehaviour
{
    private Turret turret;

    public void Setup(Turret turretToPlacehold)
    {
        turret = turretToPlacehold;
        GetComponent<SpriteRenderer>().sprite = turret.GetComponent<SpriteRenderer>().sprite;
    }
    private void Update()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var newPosition = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        transform.position = newPosition;
    }
}
