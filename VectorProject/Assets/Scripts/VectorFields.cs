using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VectorFields : MonoBehaviour
{
    [SerializeField] private Vector3 vectorPos;
    public Vector3 VectorPos { get => vectorPos; set => vectorPos = value; }

    [SerializeField] private List<TMP_InputField> vectorField;
    public List<TMP_InputField> VectorField { get => vectorField; set => vectorField = value; }

    public void InputVectorX()
    {
        if (vectorField[0].text != string.Empty)
        {
            vectorPos.Set(float.Parse(vectorField[0].text), vectorPos.y, vectorPos.z);
        }
    }

    public void InputVectorY()
    {
        if (vectorField[1].text != string.Empty)
        {
            vectorPos.Set(vectorPos.x, float.Parse(vectorField[1].text), vectorPos.z);
        }
    }

    public void InputVectorZ()
    {
        if (vectorField[2].text != string.Empty)
        {
            vectorPos.Set(vectorPos.x, vectorPos.y, float.Parse(vectorField[2].text));
        }
    }

}
