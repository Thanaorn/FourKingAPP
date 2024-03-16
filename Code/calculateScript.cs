using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Random = UnityEngine.Random;
using Unity.Mathematics;

public class calculateScript : MonoBehaviour
{
    public TMP_InputField N;
    public TMP_InputField nameText;
    public TMP_Text remainText;
    //House show 
    public TMP_Text textA;
    public TMP_Text textB;
    public TMP_Text textC;
    public TMP_Text textD;

    public int countRemain;

    //Name and N
    ArrayList Ahouse = new ArrayList();
    public int n_value;

    //Button
    public GameObject NNNObject;
    public GameObject NameObject;
    public GameObject sendObject;
    public GameObject showallObject;
    public GameObject enterMore;
    public GameObject plzSendName;

    //4House information
    ArrayList A = new ArrayList();
    ArrayList B = new ArrayList();
    ArrayList C = new ArrayList();
    ArrayList D = new ArrayList();

    public void ComfirmN()
    {
        n_value = Int32.Parse(N.text);
        countRemain = n_value;
        NameObject.SetActive(true);
        NNNObject.SetActive(false);
        showallObject.SetActive(true);
    }
    public void sendName()
    {

        if (nameText.text != "")
        {
            plzSendName.SetActive(false);
            Ahouse.Add(nameText.text);
            enterMore.SetActive(false);
            countRemain--;
            if (countRemain == 0)
            {
                sendObject.SetActive(false);
            }
        }
        else
        {
            plzSendName.SetActive(true);
        }

    }
    public void showName()
    {

        for (int i = 0; i < Ahouse.Count; i++)
        {
            print(Ahouse[i]);
        }
    }

    public void calcaulateMethod()//main sort method
    {
        if (countRemain != 0)
        {
            enterMore.SetActive(true);
            return;
        }
        else
        {
            enterMore.SetActive(false);
        }
        int mean = n_value / 4;
        int countA = 0;
        int countB = 0;
        int countC = 0;
        int countD = 0;
        bool Acheck = false;
        bool Bcheck = false;
        bool Ccheck = false;
        bool Dcheck = false;
        int count = 0;
        while (count < n_value)
        {
            //check if a b c d already Add
            if (Acheck && Bcheck && Ccheck && Dcheck)
            {
                Acheck = false;
                Bcheck = false;
                Ccheck = false;
                Dcheck = false;
            }

            //random number 1 - 4
            int random = Random.Range(1, 5);
            //random number get first house
            //house doesn't full and not already Add 
            if (random == 1 && countA < mean + 1)
            {
                //if house already add random again
                if (Acheck == false)
                {
                    A.Add(Ahouse[count]);
                    countA++;
                    Acheck = true;
                }
                else
                {
                    continue;
                }

            }
            //random number get second house
            //house doesn't full and not already Add 
            else if (random == 2 && countB < mean + 1)
            {
                //if house already add random again
                if (Bcheck == false)
                {
                    B.Add(Ahouse[count]);
                    countB++;
                    Bcheck = true;
                }
                else
                {
                    continue;
                }
            }
            //random number get third house
            //house doesn't full and not already Add 
            else if (random == 3 && countC < mean + 1)
            {
                //if house already add random again
                if (Ccheck == false)
                {
                    C.Add(Ahouse[count]);
                    countC++;
                    Ccheck = true;
                }
                else
                {
                    continue;
                };
            }
            //random number get fourth house
            //house doesn't full and not already Add 
            else if (random == 4 && countD < mean + 1)
            {
                //if house already add random again
                if (Dcheck == false)
                {
                    D.Add(Ahouse[count]);
                    countD++;
                    Dcheck = true;
                }
                else
                {
                    continue;
                }
            }
            else
            {
                continue;
            }
            count++;
        }
        //Show all name of first house
        for (int i = 0; i < A.Count; i++)
        {
            textA.text += (A[i].ToString()+"\n");
        }
        //Show all name of second house
        for (int i = 0; i < B.Count; i++)
        {
            textB.text += (B[i].ToString() + "\n");
        }
        //Show all name of third house
        for (int i = 0; i < C.Count; i++)
        {
            textC.text += (C[i].ToString() + "\n");
        }
        //Show all name of fourth house
        for (int i = 0; i < D.Count; i++)
        {
            textD.text += (D[i].ToString() + "\n");
        }
        showallObject.SetActive(false);
    }
    void Update()
    {
        remainText.text = countRemain.ToString();
    }
}
