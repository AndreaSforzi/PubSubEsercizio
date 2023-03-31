using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [SerializeField] float walkSpeed = 10;

    public int expNeededToLevelUp = 1;

    int _lvl = 0;
    int _exp = 0;

    public int Lvl
    {
        get => _lvl;
        set => _lvl = value;
        
    }

    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * walkSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * walkSpeed * Time.deltaTime;

        transform.Translate(horizontal, 0, vertical);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("EXP")) return;

        _exp++;

        PubSub.Instance.SendMessage(MessageType.EXPCollected, _exp);

        if (_exp >= expNeededToLevelUp)
        {
            _exp = 0;
            Lvl++;
            expNeededToLevelUp *= 2;
            PubSub.Instance.SendMessage(MessageType.LvlUp, Lvl);
        }

         Destroy(other.gameObject);
        
    }
}
