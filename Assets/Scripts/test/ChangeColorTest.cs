using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
public class ChangeColorTest:MonoBehaviour
{
    public GameObject go;
    public Image img;
    public void Start()
    {
        if (go.GetComponent<MeshRenderer>() != null)
            go.GetComponent<ChangeColor>().addMaterial(go.GetComponent<MeshRenderer>().material);

        if (img.material != null)
            img.GetComponent<ChangeColor>().addMaterial(img.material);
    }
}
