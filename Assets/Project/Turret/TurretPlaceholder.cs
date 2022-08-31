using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurretPlaceholder : MonoBehaviour
{
    public Turret turret;
    [SerializeField]
    private float minTurretHeight;
    [SerializeField]
    private float maxTurretHeight;
    [SerializeField]
    private float blockedRadius;

    public void Setup(Turret turretToPlacehold)
    {
        turret = turretToPlacehold;
        GetComponent<SpriteRenderer>().sprite = turret.GetComponent<SpriteRenderer>().sprite;

        var rangeIndicator = GetComponentInChildren<TurretRangeIndicator>();
        rangeIndicator.transform.localScale *= turretToPlacehold.attackRange;
        rangeIndicator.Show();
    }

    private void Update()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var newPosition = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        transform.position = newPosition;

        var canPlace = CanPlace();

        if (!canPlace) gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0f);
        else gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);

        if (Input.GetMouseButtonDown(0) && canPlace)
        {
            GameManager.Instance.TurretManager.SpawnTurret();
        }
        if (Input.GetMouseButtonDown(1)) GameManager.Instance.TurretManager.DropPlaceholder();
    }

    private bool CanPlace()
    {
        var position = transform.position;
        if (Physics2D.OverlapCircleAll(position, blockedRadius).
            Where(c=>c.GetComponent<Turret>() || c.GetComponent<EnemyGoal>()).
            Any()) return false;

        if (position.y < minTurretHeight || position.y > maxTurretHeight) return false;
        return true;
    }
}
