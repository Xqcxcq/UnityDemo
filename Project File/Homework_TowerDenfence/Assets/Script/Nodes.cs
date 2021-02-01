using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodes : MonoBehaviour {

    public Color hoverColor = Color.gray;
    private Color initColor;
    private Renderer render;
    private GameObject turret;
    public Vector3 uiOffset = new Vector3(0, 0, 0);
//    public TurretDesign selectedTurretDesign;
    public bool isUpgraded = false;//是否已经升级过了
    public GameObject turretPrefab;
    void Start () {
        render = GetComponent<MeshRenderer>();
        initColor = render.material.color;
	}
	
	
	void Update () {
		
	}

    private void OnMouseEnter()
    {
        if (BuildManager.Instance.SelectedTurret == null)
            return;
        if (!BuildManager.Instance.CanBuild)
            return;
        render.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        render.material.color = initColor;
    }
    private void OnMouseDown()
    {
        if (BuildManager.Instance.SelectedTurret == null)
            return;
        if (!BuildManager.Instance.CanBuild)
            return;
        BuildTurret();
        
    }
    public void BuildTurret()
    {
        //金钱数量减少
        PlayerStatus.Money -= BuildManager.Instance.SelectedTurret.cost;
        Debug.Log("创建炮塔");
        Instantiate(BuildManager.Instance.SelectedTurret.prefab, transform.position, Quaternion.identity);
    }
}
