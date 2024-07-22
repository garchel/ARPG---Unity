using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelManager : MonoBehaviour
{
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] GameObject questsPanel;
    [SerializeField] GameObject statsPanel;
    [SerializeField] GameObject defeatedPanel;

    private void Awake()
    {
        inventoryPanel.SetActive(false);
        questsPanel.SetActive(false);
        statsPanel.SetActive(false);
        defeatedPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            OpenInventory();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            OpenQuests();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            OpenStats();
        }
    }

    public void OpenInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeInHierarchy);

    }

    public void OpenQuests()
    {
        questsPanel.SetActive(!questsPanel.activeInHierarchy);
        statsPanel.SetActive(false);

    }

    public void OpenStats()
    {
        statsPanel.SetActive(!statsPanel.activeInHierarchy);
        questsPanel.SetActive(false);

    }
}
