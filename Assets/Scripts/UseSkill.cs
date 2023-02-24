using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class UseSkill : MonoBehaviour
{

    public static List<Transform> BlueUnitList;
    public static List<Transform> RedUnitList;

    ObjectPooler objectPooler;
    //string[] blueUnitTypes = { "BlueKnight", "BlueMage", "BlueBird", "BluePriest" };
    //string[] redUnitTypes = { "RedKnight", "RedMage", "RedBird", "RedPriest" };
    //private string _selectedUnit;

    [SerializeField] DragDrop pointerLocation;
    [SerializeField] ManaBar manaBar;

    [SerializeField] GameObject blueKnightPrefab;
    [SerializeField] GameObject blueMagePrefab;
    [SerializeField] GameObject blueBirdPrefab;
    [SerializeField] GameObject bluePriestPrefab;

    [SerializeField] GameObject redKnightPrefab;
    [SerializeField] GameObject redMagePrefab;
    [SerializeField] GameObject redBirdPrefab;
    [SerializeField] GameObject redPriestPrefab;

    void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    public void SpawnUnit()
    {
        if (DragDrop.skillIndex == 0)
        {
            if (StartMenu.cameraChoice == 2)
            {
                SpawnBlueKnight();
            }

            if (StartMenu.cameraChoice == 3)
            {
                SpawnRedKnight();
            }
        }

        if (DragDrop.skillIndex == 1)
        {
            if (StartMenu.cameraChoice == 2)
            {
                SpawnBlueMage();
            }

            if (StartMenu.cameraChoice == 3)
            {
                SpawnRedMage();
            }
        }

        if (DragDrop.skillIndex == 2)
        {
            if (StartMenu.cameraChoice == 2)
            {
                SpawnBlueBird();
            }

            if (StartMenu.cameraChoice == 3)
            {
                SpawnRedBird();
            }
        }

        if (DragDrop.skillIndex == 3)
        {
            if (StartMenu.cameraChoice == 2)
            {
                SpawnBluePriest();
            }

            if (StartMenu.cameraChoice == 3)
            {
                SpawnRedPriest();
            }
        }

    }

    void SpawnBlueKnight()
    {
        //_selectedUnit = "BlueKnight";
        //Damagable spawnedBlueUnit = objectPooler.SpawnFromPool(_selectedUnit, (pointerLocation.pointerLocation), Quaternion.identity).GetComponent<Damagable>();
        var spawnedRedUnit = BoltNetwork.Instantiate(blueKnightPrefab, (pointerLocation.pointerLocation), Quaternion.identity);
        //AliveUnitHolder.BlueUnitList.Add(spawnedBlueUnit);        
        manaBar.SpendMana(1);
    }

    void SpawnBlueMage()
    {
        //_selectedUnit = "BlueMage";
        //Damagable spawnedBlueUnit = objectPooler.SpawnFromPool(_selectedUnit, (pointerLocation.pointerLocation), Quaternion.identity).GetComponent<Damagable>();
        var spawnedRedUnit = BoltNetwork.Instantiate(blueMagePrefab, (pointerLocation.pointerLocation), Quaternion.identity);
        //AliveUnitHolder.BlueUnitList.Add(spawnedBlueUnit);
        manaBar.SpendMana(2);
    }

    void SpawnBlueBird()
    {
        //_selectedUnit = "BlueBird";
        //Damagable spawnedBlueUnit = objectPooler.SpawnFromPool(_selectedUnit, (pointerLocation.pointerLocation), Quaternion.identity).GetComponent<Damagable>();
        var spawnedRedUnit = BoltNetwork.Instantiate(blueBirdPrefab, (pointerLocation.pointerLocation), Quaternion.identity);
        //AliveUnitHolder.BlueUnitList.Add(spawnedBlueUnit);
        manaBar.SpendMana(3);
    }

    void SpawnBluePriest()
    {
        //_selectedUnit = "BluePriest";
        //Damagable spawnedBlueUnit = objectPooler.SpawnFromPool(_selectedUnit, (pointerLocation.pointerLocation), Quaternion.identity).GetComponent<Damagable>();
        var spawnedRedUnit = BoltNetwork.Instantiate(bluePriestPrefab, (pointerLocation.pointerLocation), Quaternion.identity);
        //AliveUnitHolder.BlueUnitList.Add(spawnedBlueUnit);
        manaBar.SpendMana(3);
    }

    void SpawnRedKnight()
    {
        //_selectedUnit = "BlueKnight";
        //Damagable spawnedBlueUnit = objectPooler.SpawnFromPool(_selectedUnit, (pointerLocation.pointerLocation), Quaternion.identity).GetComponent<Damagable>();
        var spawnedRedUnit = BoltNetwork.Instantiate(redKnightPrefab, (pointerLocation.pointerLocation), Quaternion.identity);
        //AliveUnitHolder.BlueUnitList.Add(spawnedBlueUnit);        
        manaBar.SpendMana(1);
    }

    void SpawnRedMage()
    {
        //_selectedUnit = "BlueMage";
        //Damagable spawnedBlueUnit = objectPooler.SpawnFromPool(_selectedUnit, (pointerLocation.pointerLocation), Quaternion.identity).GetComponent<Damagable>();
        var spawnedRedUnit = BoltNetwork.Instantiate(redMagePrefab, (pointerLocation.pointerLocation), Quaternion.identity);
        //AliveUnitHolder.BlueUnitList.Add(spawnedBlueUnit);
        manaBar.SpendMana(2);
    }

    void SpawnRedBird()
    {
        //_selectedUnit = "BlueBird";
        //Damagable spawnedBlueUnit = objectPooler.SpawnFromPool(_selectedUnit, (pointerLocation.pointerLocation), Quaternion.identity).GetComponent<Damagable>();
        var spawnedRedUnit = BoltNetwork.Instantiate(redBirdPrefab, (pointerLocation.pointerLocation), Quaternion.identity);
        //AliveUnitHolder.BlueUnitList.Add(spawnedBlueUnit);
        manaBar.SpendMana(3);
    }

    void SpawnRedPriest()
    {
        //_selectedUnit = "BluePriest";
        //Damagable spawnedBlueUnit = objectPooler.SpawnFromPool(_selectedUnit, (pointerLocation.pointerLocation), Quaternion.identity).GetComponent<Damagable>();
        var spawnedRedUnit = BoltNetwork.Instantiate(redPriestPrefab, (pointerLocation.pointerLocation), Quaternion.identity);
        //AliveUnitHolder.BlueUnitList.Add(spawnedBlueUnit);
        manaBar.SpendMana(3);
    }
}