using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {
    public TurretDesign girl1;
    public TurretDesign girl2;
    public TurretDesign girl3;
    //public TurretDesign laserBeamer;
    public void OnPurseStandardTurret()
    {
        Debug.Log("选择少女1");
        BuildManager.Instance.SelectedTurret = girl1;
    }
    public void OnPurseMissileLauncher()
    {
        Debug.Log("选择少女2");
        BuildManager.Instance.SelectedTurret = girl2;
    }
    public void OnPurseLaserBeamer()
    {
        Debug.Log("选择少女3");
        BuildManager.Instance.SelectedTurret = girl3;
    }
}
