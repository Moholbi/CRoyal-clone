using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSkill : MonoBehaviour
{

    public static List<Transform> BlueUnitList;
    ObjectPooler objectPooler;
    string[] blueUnitTypes = { "BlueKnight", "BlueMage", "BlueBird", "BluePriest" };
    private string _selectedUnit;

    [SerializeField] DragDrop pointerLocation;
    [SerializeField] ManaBar manaBar;

    void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    public void SpawnBlueUnit()
    {
        if (DragDrop.skillIndex == 0)
        {
            SpawnKnight();
        }

        if (DragDrop.skillIndex == 1)
        {
            SpawnMage();
        }

        if (DragDrop.skillIndex == 2)
        {
            SpawnBird();
        }

        if (DragDrop.skillIndex == 3)
        {
            SpawnPriest();
        }
    }

    void SpawnKnight()
    {
        _selectedUnit = "BlueKnight";
        Damagable spawnedBlueUnit = objectPooler.SpawnFromPool(_selectedUnit, (pointerLocation.pointerLocation), Quaternion.identity).GetComponent<Damagable>();
        AliveUnitHolder.BlueUnitList.Add(spawnedBlueUnit);
        manaBar.SpendMana(1);
    }

    void SpawnMage()
    {
        _selectedUnit = "BlueMage";
        Damagable spawnedBlueUnit = objectPooler.SpawnFromPool(_selectedUnit, (pointerLocation.pointerLocation), Quaternion.identity).GetComponent<Damagable>();
        AliveUnitHolder.BlueUnitList.Add(spawnedBlueUnit);
        manaBar.SpendMana(2);
    }

    void SpawnBird()
    {
        _selectedUnit = "BlueBird";
        Damagable spawnedBlueUnit = objectPooler.SpawnFromPool(_selectedUnit, (pointerLocation.pointerLocation), Quaternion.identity).GetComponent<Damagable>();
        AliveUnitHolder.BlueUnitList.Add(spawnedBlueUnit);
        manaBar.SpendMana(3);
    }

    void SpawnPriest()
    {
        _selectedUnit = "BluePriest";
        Damagable spawnedBlueUnit = objectPooler.SpawnFromPool(_selectedUnit, (pointerLocation.pointerLocation), Quaternion.identity).GetComponent<Damagable>();
        AliveUnitHolder.BlueUnitList.Add(spawnedBlueUnit);
        manaBar.SpendMana(3);
    }
}