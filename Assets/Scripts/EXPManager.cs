using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EXPManager : MonoBehaviour
{
    [Serializable]
    public struct EXPManagerBounds
    {
        public float minX;
        public float minY;
        public float maxX;
        public float maxY;

        public Vector3 GetRandomPosition()
        {
            return new Vector3()
            {
                x = Random.Range(minX, maxX),
                y = 0,
                z = Random.Range(minY, maxY)

            };
        }
    }

    [SerializeField] private EXPManagerBounds bounds;
    [SerializeField] private GameObject EXPPrefab;

    private void Start()
    {
        PubSub.Instance.RegisterdFunction(MessageType.EXPCollected,OnEXPCollected);
    }

    void OnEXPCollected(object exp)
    {
        GameObject newEXP = Instantiate(EXPPrefab);
        newEXP.transform.position = bounds.GetRandomPosition();
    }
}
