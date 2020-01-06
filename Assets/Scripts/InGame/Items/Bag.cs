using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : Item, IUsable
{

    private int slots;

    [SerializeField]
    private GameObject bagPrefab;

    public BagScript MyBagScript { get; set; }
    public int Slots { get => slots; }

    public void Initialize(int slots)
    {
        this.slots = slots;
    }

    public void Use()
    {
        MyBagScript = Instantiate(bagPrefab);
    }

}
