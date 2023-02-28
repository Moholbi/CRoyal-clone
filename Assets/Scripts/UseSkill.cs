using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class UseSkill : MonoBehaviour
{
    public static List<Transform> BlueUnitList;
    public static List<Transform> RedUnitList;

    [SerializeField] DragDrop pointerLocation;
    [SerializeField] ManaBar manaBar;

    [SerializeField] BoltEntity blueKnightPrefab;
    [SerializeField] BoltEntity blueMagePrefab;
    [SerializeField] BoltEntity blueBirdPrefab;
    [SerializeField] BoltEntity bluePriestPrefab;

    [SerializeField] BoltEntity redKnightPrefab;
    [SerializeField] BoltEntity redMagePrefab;
    [SerializeField] BoltEntity redBirdPrefab;
    [SerializeField] BoltEntity redPriestPrefab;

    public void SpawnUnit()
    {
        if (DragDrop.skillIndex == 0)
        {
            if (StartMenu.cameraChoice == 2)
            {
                SpawnBlueKnight(pointerLocation.pointerLocation, Quaternion.identity, blueBirdPrefab);
            }

            if (StartMenu.cameraChoice == 3)
            {
                SpawnRedKnight(pointerLocation.pointerLocation, Quaternion.identity, blueBirdPrefab);
            }
        }

        if (DragDrop.skillIndex == 1)
        {
            if (StartMenu.cameraChoice == 2)
            {
                SpawnBlueMage(pointerLocation.pointerLocation, Quaternion.identity, blueBirdPrefab);
            }

            if (StartMenu.cameraChoice == 3)
            {
                SpawnRedMage(pointerLocation.pointerLocation, Quaternion.identity, blueBirdPrefab);
            }
        }

        if (DragDrop.skillIndex == 2)
        {
            if (StartMenu.cameraChoice == 2)
            {
                SpawnBlueBird(pointerLocation.pointerLocation, Quaternion.identity, blueBirdPrefab);
            }

            if (StartMenu.cameraChoice == 3)
            {
                SpawnRedBird(pointerLocation.pointerLocation, Quaternion.identity, blueBirdPrefab);
            }
        }

        if (DragDrop.skillIndex == 3)
        {
            if (StartMenu.cameraChoice == 2)
            {
                SpawnBluePriest(pointerLocation.pointerLocation, Quaternion.identity, blueBirdPrefab);
            }

            if (StartMenu.cameraChoice == 3)
            {
                SpawnRedPriest(pointerLocation.pointerLocation, Quaternion.identity, blueBirdPrefab);
            }
        }
    }

    public void SpawnBlueKnight(Vector3 position, Quaternion rotation, BoltEntity boltEntity)
    {
        var evnt = SpawnUnitEvent.Create();
        evnt.PrefabID = blueKnightPrefab.PrefabId;
        evnt.PrefabPosition = pointerLocation.pointerLocation;
        evnt.PrefabRotation = Quaternion.identity;
        evnt.Send();
        manaBar.SpendMana(1);
    }

    public void SpawnBlueMage(Vector3 position, Quaternion rotation, BoltEntity boltEntity)
    {
        var evnt = SpawnUnitEvent.Create();
        evnt.PrefabID = blueMagePrefab.PrefabId;
        evnt.PrefabPosition = pointerLocation.pointerLocation;
        evnt.PrefabRotation = Quaternion.identity;
        evnt.Send();
        manaBar.SpendMana(1);
    }

        public void SpawnBlueBird(Vector3 position, Quaternion rotation, BoltEntity boltEntity)
    {
        var evnt = SpawnUnitEvent.Create();
        evnt.PrefabID = blueBirdPrefab.PrefabId;
        evnt.PrefabPosition = pointerLocation.pointerLocation;
        evnt.PrefabRotation = Quaternion.identity;
        evnt.Send();
        manaBar.SpendMana(1);
    }

        public void SpawnBluePriest(Vector3 position, Quaternion rotation, BoltEntity boltEntity)
    {
        var evnt = SpawnUnitEvent.Create();
        evnt.PrefabID = bluePriestPrefab.PrefabId;
        evnt.PrefabPosition = pointerLocation.pointerLocation;
        evnt.PrefabRotation = Quaternion.identity;
        evnt.Send();
        manaBar.SpendMana(1);
    }

        public void SpawnRedKnight(Vector3 position, Quaternion rotation, BoltEntity boltEntity)
    {
        var evnt = SpawnUnitEvent.Create();
        evnt.PrefabID = redKnightPrefab.PrefabId;
        evnt.PrefabPosition = pointerLocation.pointerLocation;
        evnt.PrefabRotation = Quaternion.identity;
        evnt.Send();
        manaBar.SpendMana(1);
    }

        public void SpawnRedMage(Vector3 position, Quaternion rotation, BoltEntity boltEntity)
    {
        var evnt = SpawnUnitEvent.Create();
        evnt.PrefabID = redMagePrefab.PrefabId;
        evnt.PrefabPosition = pointerLocation.pointerLocation;
        evnt.PrefabRotation = Quaternion.identity;
        evnt.Send();
        manaBar.SpendMana(1);
    }

        public void SpawnRedBird(Vector3 position, Quaternion rotation, BoltEntity boltEntity)
    {
        var evnt = SpawnUnitEvent.Create();
        evnt.PrefabID = redBirdPrefab.PrefabId;
        evnt.PrefabPosition = pointerLocation.pointerLocation;
        evnt.PrefabRotation = Quaternion.identity;
        evnt.Send();
        manaBar.SpendMana(1);
    }

        public void SpawnRedPriest(Vector3 position, Quaternion rotation, BoltEntity boltEntity)
    {
        var evnt = SpawnUnitEvent.Create();
        evnt.PrefabID = redPriestPrefab.PrefabId;
        evnt.PrefabPosition = pointerLocation.pointerLocation;
        evnt.PrefabRotation = Quaternion.identity;
        evnt.Send();
        manaBar.SpendMana(1);
    }
}