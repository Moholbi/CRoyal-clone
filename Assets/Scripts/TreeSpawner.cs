using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using TMPro;

public class TreeSpawner : MonoBehaviour
{
    [SerializeField] private AssetReferenceGameObject tree1;
    [SerializeField] private AssetReferenceGameObject tree2;
    [SerializeField] private AssetReferenceGameObject tree3;
    [SerializeField] private AssetReferenceGameObject tree4;

    private Vector3 _spawnPos1 = new Vector3(14, 1, 39);
    private Vector3 _spawnPos2 = new Vector3(-14, 1, -9);
    private Vector3 _spawnPos3 = new Vector3(14, 1, -9);
    private Vector3 _spawnPos4 = new Vector3(-14, 1, 39);

    [SerializeField] TextMeshProUGUI downloadSizeText;

    private float _sizeInMb;

    void Start()
    {
        DownloadSizeInMB();
        Addressables.InstantiateAsync(tree1, _spawnPos1, Quaternion.identity, transform).Completed += Spawn_Completed;
        Addressables.InstantiateAsync(tree2, _spawnPos2, Quaternion.identity, transform).Completed += Spawn_Completed;
        Addressables.InstantiateAsync(tree3, _spawnPos3, Quaternion.identity, transform).Completed += Spawn_Completed;
        Addressables.InstantiateAsync(tree4, _spawnPos4, Quaternion.identity, transform).Completed += Spawn_Completed;
    }

    private void Spawn_Completed(AsyncOperationHandle<GameObject> handle)
    {
        FixShaders.FixShadersForEditor(handle.Result);
    }

    public void DownloadSizeInMB()
    {
        var downloadSizeCall = Addressables.GetDownloadSizeAsync(tree1.RuntimeKey);
        downloadSizeCall.Completed += handle =>
        {
            var sizeInBytes = handle.Result;
            _sizeInMb = sizeInBytes / (1024f * 1024f);
            downloadSizeText.text = _sizeInMb + " MB";
        };
    }
}