using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {
    public static BuildManager Instance;
    private TurretDesign selectedTurret;
    public TurretDesign SelectedTurret
    {
        get
        {
            return selectedTurret;
        }
        set
        {
            selectedTurret = value;
        }
    }
    //是否可以创建炮塔
    public bool CanBuild
    {
        get
        {
            return selectedTurret != null && selectedTurret.prefab != null;
        }
    }
    public void Awake()
    {
        Instance = this;
    }
    
}
