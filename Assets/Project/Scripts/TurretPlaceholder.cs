using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlaceholder : MonoBehaviour
{
    public Turret turret;

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
        if (Input.GetMouseButtonDown(0)) GameManager.Instance.LevelManager.SpawnTurret();
        if (Input.GetMouseButtonDown(1)) GameManager.Instance.LevelManager.DropPlaceholder();
    }
}
