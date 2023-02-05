using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreedingSingleAction : MonoBehaviour
{
    public int characteId;
    public RootBreedingCenter rootBreedingCenter;
    void OnMouseUp()
    {
        rootBreedingCenter.OnClickSingleBreeding(characteId);
    }
}
