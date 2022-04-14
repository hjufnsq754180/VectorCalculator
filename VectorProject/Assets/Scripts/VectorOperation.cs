using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VectorOperation : MonoBehaviour
{
    [SerializeField] private Vector3 v1Pos;
    [SerializeField] private Vector3 v2Pos;
    [SerializeField] private Vector3 v3Pos;

    [SerializeField] private List<VectorFields> vectors;

    [SerializeField] private TextMeshProUGUI resultText;

    public GameObject startVectorObj;
    public GameObject endVectorObj;

    private void Start()
    {
        resultText.text = " ";
    }

    private void CreateVectorObject(Vector3 vectorPos)
    {
        GameObject a = Instantiate(startVectorObj, Vector3.zero, Quaternion.identity);
        a.transform.localScale = new Vector3(1, 1, vectorPos.magnitude - 0.5f);
        GameObject b = Instantiate(endVectorObj, vectorPos, Quaternion.identity);

        a.transform.forward = vectorPos.normalized;
        b.transform.forward = vectorPos.normalized;
    }

    private void DeleteAllVectorObject()
    {
        foreach (GameObject vector in GameObject.FindGameObjectsWithTag("VectorObject"))
        {
            Destroy(vector);
        }
    }

    public void SumButton()
    {
        if (CheckFillVectorPos(vectors[0]) & CheckFillVectorPos(vectors[1]))
        {
            DeleteAllVectorObject();
            InputVector();
            Vector3 res = VectorSum(new Vector3(v1Pos.x, v1Pos.y, v1Pos.z), new Vector3(v2Pos.x, v2Pos.y, v2Pos.z));
            resultText.text = res.ToString();
            CreateVectorObject(v1Pos);
            CreateVectorObject(v2Pos);
        }
        else
        {
            resultText.text = "Ошибка заполнения";
        }

    }

    public void MinusButton()
    {
        if (CheckFillVectorPos(vectors[0]) & CheckFillVectorPos(vectors[1]))
        {
            DeleteAllVectorObject();
            InputVector();
            Vector3 res = VectorMinus(new Vector3(v1Pos.x, v1Pos.y, v1Pos.z), new Vector3(v2Pos.x, v2Pos.y, v2Pos.z));
            resultText.text = res.ToString();
            CreateVectorObject(v1Pos);
            CreateVectorObject(v2Pos);
        }
        else
        {
            resultText.text = "Ошибка заполнения";
        }
    }

    public void ScalarMultiButton()
    {
        if (CheckFillVectorPos(vectors[0]) & CheckFillVectorPos(vectors[1]))
        {
            DeleteAllVectorObject();
            InputVector();
            float res = VectorScalarMulti(new Vector3(v1Pos.x, v1Pos.y, v1Pos.z), new Vector3(v2Pos.x, v2Pos.y, v2Pos.z));
            resultText.text = res.ToString();
            CreateVectorObject(v1Pos);
            CreateVectorObject(v2Pos);
        }
        else
        {
            resultText.text = "Ошибка заполнения";
        }
    }

    public void MixedMultiButton()
    {
        if (CheckFillVectorPos(vectors[0]) & CheckFillVectorPos(vectors[1]) & CheckFillVectorPos(vectors[2]))
        {
            DeleteAllVectorObject();
            InputVector();
            float res = VectorMixedMulti(new Vector3(v1Pos.x, v1Pos.y, v1Pos.z), new Vector3(v2Pos.x, v2Pos.y, v2Pos.z), new Vector3(v3Pos.x, v3Pos.y, v3Pos.z));
            resultText.text = res.ToString();
            CreateVectorObject(v1Pos);
            CreateVectorObject(v2Pos);
            CreateVectorObject(v3Pos);
        }
        else
        {
            resultText.text = "Ошибка заполнения";
        }
    }

    public void AngleButton()
    {
        if (CheckFillVectorPos(vectors[0]) & CheckFillVectorPos(vectors[1]))
        {
            DeleteAllVectorObject();
            InputVector();
            float res = VectorAngle(new Vector3(v1Pos.x, v1Pos.y, v1Pos.z), new Vector3(v2Pos.x, v2Pos.y, v2Pos.z));
            resultText.text = res.ToString();
            CreateVectorObject(v1Pos);
            CreateVectorObject(v2Pos);
        }
        else
        {
            resultText.text = "Ошибка заполнения";
        }
    }

    // Сумма векторов
    public Vector3 VectorSum(Vector3 a, Vector3 b)
    {
        if (CheckFillVectorPos(vectors[0]) & CheckFillVectorPos(vectors[1]))
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }
        else
        {
            return Vector3.zero;
        }
    }

    // Разность векторов
    public Vector3 VectorMinus(Vector3 a, Vector3 b)
    {
        return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
    }

    // Скалярное произведение векторов
    public float VectorScalarMulti(Vector3 a, Vector3 b)
    {
        return (a.x * b.x + a.y * b.y + a.z * b.z);
    }

    // Смешанное произведение векторов
    public float VectorMixedMulti(Vector3 a, Vector3 b, Vector3 d)
    {
        return a.x * b.y * d.z + a.y * b.z * d.x + a.z * b.x * d.y - a.z * b.y * d.x - a.y * b.x * d.z - a.x * b.z * d.y;
    }

    // Угол между векторами
    public float VectorAngle(Vector3 a, Vector3 b)
    {
        float scalarMulti = VectorScalarMulti(a, b);
        print(scalarMulti);
        float lengthA = Mathf.Sqrt(Mathf.Pow(a.x, 2) + Mathf.Pow(a.y, 2) + Mathf.Pow(a.z, 2));
        print(lengthA);
        float lengthB = Mathf.Sqrt(Mathf.Pow(b.x, 2) + Mathf.Pow(b.y, 2) + Mathf.Pow(b.z, 2));
        print(lengthB);
        float alpha = scalarMulti / (lengthA * lengthB);
        print(alpha);
        return Mathf.Acos(alpha) * Mathf.Rad2Deg;
    }

    private bool CheckFillVectorPos(VectorFields vector)
    {
        foreach (var item in vector.VectorField)
        {
            if (item.text != string.Empty)
            {
                continue;
            }
            else
            {
                return false;
            }
        }
        return true;
    }

    public void ClearButton()
    {
        DeleteAllVectorObject();
        resultText.text = "Очищено";

        for (int i = 0; i < 3; i++)
        {
            for (int k = 0; k < 3; k++)
            {
                vectors[i].VectorField[k].text = "";
            }
        }
    }

    private void InputVector()
    {
        v1Pos = vectors[0].VectorPos;
        v2Pos = vectors[1].VectorPos;
        v3Pos = vectors[2].VectorPos;
    }
}
