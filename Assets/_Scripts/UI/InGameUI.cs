using System;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Button switchPoleButton;


    private void Start()
    {
        switchPoleButton.onClick.AddListener(() => Player.Instance.SwitchPole());
    }
}
