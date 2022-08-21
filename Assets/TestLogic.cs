using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLogic : MonoBehaviour
{
    public Inventory inventory = new Inventory();
    public List<ItemBlueprint> blueprints = new List<ItemBlueprint>();

    public ItemBoxWrapper prefabBoxWrapper;

    void Start()
    {
        blueprints.Add(new ItemBlueprint
        {
            typeId = 1,
            baseName = "Sword",
            maxStack = 1,
            stackable = false
        });

        blueprints.Add(new ItemBlueprint
        {
            typeId = 2,
            baseName = "Healing Potion",
            maxStack = 25,
            stackable = true
        });
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            CreateNewItem();
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            LootAnItem();
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            inventory.Print();
        }
    }

    private void CreateNewItem()
    {
        Vector3 randomPos = Random.insideUnitSphere * 5f;

        var boxWrapper = Instantiate(prefabBoxWrapper, randomPos, Quaternion.identity);

        boxWrapper.gameObject.SetActive(true);

        bool createSword = Random.Range(0, 2) == 0;

        Item item = null;

        if (createSword)
        {
            item = new Item
            {
                customName = "Of Fire",
                blueprint = blueprints[0],
                curStack = 1,
            };
        }
        else
        {
            item = new Item
            {
                blueprint = blueprints[1],
                curStack = Random.Range(2, 10),
            };
        }


        boxWrapper.InsertItem(item);
    }

    private void LootAnItem()
    {
        var boxWrapper = FindObjectOfType<ItemBoxWrapper>();
        if (boxWrapper != null)
        {
            inventory.AddItem(boxWrapper.item);
            Destroy(boxWrapper.gameObject);
        }
    }



    [ContextMenu("test")]
    private void Test()
    {
        Inventory inv = new Inventory();

        ItemBlueprint swordBlueprint = new ItemBlueprint
        {
            baseName = "Sword",
            maxStack = 1,
            stackable = false
        };

        ItemBlueprint hpBlueprint = new ItemBlueprint
        {
            baseName = "Healing Potion",
            maxStack = 25,
            stackable = true
        };

        Item sword = new Item
        {
            customName = "Of Fire",
            blueprint = swordBlueprint,
            curStack = 1,
        };

        Item sword2 = new Item
        {
            customName = "Of Ice",
            blueprint = swordBlueprint,
            curStack = 1,
        };

        Item potion = new Item
        {
            blueprint = hpBlueprint,
            curStack = 20,
        };

        Item potion2 = new Item
        {
            blueprint = hpBlueprint,
            curStack = 10
        };

        inv.AddItem(sword);
        inv.AddItem(sword2);
        inv.AddItem(potion);
        inv.AddItem(potion2);

        inv.Print();
    }
}
