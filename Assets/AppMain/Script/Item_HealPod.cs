using UnityEngine;

public class Item_HealPod : ItemBase
{
    [Header("Item Param")]
    // 回復量
    [SerializeField] int healPoint = 10;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void ItemAction(Collider col)
    {
        base.ItemAction(col);
        var player = col.gameObject.GetComponent<PlayerController>();
        player.OnHeal(healPoint);
    }
}
