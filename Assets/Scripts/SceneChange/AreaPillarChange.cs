using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaPillarChange : MonoBehaviour
{
    public SpriteRenderer pillarA_1;
    public SpriteRenderer pillarA_M;  
    public SpriteRenderer pillarA_2;
    public SpriteRenderer pillarB_1;
    public SpriteRenderer pillarB_M;
    public SpriteRenderer pillarB_2;
    public SpriteRenderer pillarC_1;
    public SpriteRenderer pillarC_M;   
    public SpriteRenderer pillarC_2;
    public SpriteRenderer pillarD_1;
    public SpriteRenderer pillarD_M;
    public SpriteRenderer pillarD_2;
    public SpriteRenderer pillarE_1;
    public SpriteRenderer pillarE_M;  
    public SpriteRenderer pillarE_2;

    public GameObject pillarA_M_g;
    public GameObject pillarB_M_g;
    public GameObject pillarC_M_g;
    public GameObject pillarD_M_g;
    public GameObject pillarE_M_g;

    private Vector3 M_scale;
    private Vector3 M_scale_original;
    private Color PillarColor;
    private Color PillarColor_original;

    private bool isA;
    private bool isB;
    private bool isC;
    private bool isD;
    private bool isE;


    // Start is called before the first frame update
    void Start()
    {
        M_scale = new Vector3(0.65f, 0.65f, 0.65f);
        M_scale_original = new Vector3(0.6f, 0.6f, 0.6f);
        PillarColor = new Color(0.612f, 0.569f, 0.431f, 0);
        PillarColor_original = new Color(0.612f, 0.569f, 0.431f, 1);

        pillarA_1.color = PillarColor;
        pillarA_M.color = PillarColor;
        pillarA_2.color = PillarColor;
        pillarB_1.color = PillarColor;
        pillarB_M.color = PillarColor;
        pillarB_2.color = PillarColor;
        pillarC_1.color = PillarColor;
        pillarC_M.color = PillarColor;
        pillarC_2.color = PillarColor;
        pillarD_1.color = PillarColor;
        pillarD_M.color = PillarColor;
        pillarD_2.color = PillarColor;
        pillarE_1.color = PillarColor;
        pillarE_M.color = PillarColor;
        pillarE_2.color = PillarColor;

        isA = false;
        isB = false;
        isC = false;
        isD = false;
        isE = false;
      
    }

    void FixedUpdate()
    {
        AreaChange();
    }

    void AreaChange()
    {
        if (AreaCheck.A)
        {
            if (!isA)
            {
                StartCoroutine(areaA());
            }
            pillarA_M_g.transform.localScale = Vector3.Lerp(pillarA_M_g.transform.localScale, M_scale, 0.03f);
            pillarB_M_g.transform.localScale = Vector3.Lerp(pillarB_M_g.transform.localScale, M_scale_original, 0.03f);
        }
        else if (AreaCheck.B)
        {
            if (!isB)
            {
                StartCoroutine(areaB());
            }
            pillarA_M_g.transform.localScale = Vector3.Lerp(pillarA_M_g.transform.localScale, M_scale_original, 0.03f);
            pillarB_M_g.transform.localScale = Vector3.Lerp(pillarB_M_g.transform.localScale, M_scale, 0.03f);
            pillarC_M_g.transform.localScale = Vector3.Lerp(pillarC_M_g.transform.localScale, M_scale_original, 0.03f);
        }
        else if (AreaCheck.C)
        {
            if (!isC)
            {
                StartCoroutine(areaC());
            }
            pillarB_M_g.transform.localScale = Vector3.Lerp(pillarB_M_g.transform.localScale, M_scale_original, 0.03f);
            pillarC_M_g.transform.localScale = Vector3.Lerp(pillarC_M_g.transform.localScale, M_scale, 0.03f);
            pillarD_M_g.transform.localScale = Vector3.Lerp(pillarD_M_g.transform.localScale, M_scale_original, 0.03f);
        }
        else if (AreaCheck.D)
        {
            if (!isD)
            {
                StartCoroutine(areaD());
            }
            pillarC_M_g.transform.localScale = Vector3.Lerp(pillarC_M_g.transform.localScale, M_scale_original, 0.03f);
            pillarD_M_g.transform.localScale = Vector3.Lerp(pillarD_M_g.transform.localScale, M_scale, 0.03f);
            pillarE_M_g.transform.localScale = Vector3.Lerp(pillarE_M_g.transform.localScale, M_scale_original, 0.03f);
        }
        else if (AreaCheck.E)
        {
            if (!isE)
            {
                StartCoroutine(areaE());
            }
            pillarD_M_g.transform.localScale = Vector3.Lerp(pillarD_M_g.transform.localScale, M_scale_original, 0.03f);
            pillarE_M_g.transform.localScale = Vector3.Lerp(pillarE_M_g.transform.localScale, M_scale, 0.03f);
        }
    }

    private IEnumerator areaA()
    {
        pillarA_1.color = Color.Lerp(pillarA_1.color, PillarColor_original, 0.2f);
        pillarA_M.color = Color.Lerp(pillarA_M.color, PillarColor_original, 0.2f);
        pillarA_2.color = Color.Lerp(pillarA_2.color, PillarColor_original, 0.2f);
        pillarB_1.color = Color.Lerp(pillarB_1.color, PillarColor_original, 0.2f);
        pillarB_M.color = Color.Lerp(pillarB_M.color, PillarColor_original, 0.2f);
        pillarB_2.color = Color.Lerp(pillarB_2.color, PillarColor_original, 0.2f);
        yield return new WaitForSeconds(0.5f);
        pillarA_1.color = Color.Lerp(pillarA_1.color, PillarColor, 0.2f);
        pillarA_M.color = Color.Lerp(pillarA_M.color, PillarColor, 0.2f);
        pillarA_2.color = Color.Lerp(pillarA_2.color, PillarColor, 0.2f);
        pillarB_1.color = Color.Lerp(pillarB_1.color, PillarColor, 0.2f);
        pillarB_M.color = Color.Lerp(pillarB_M.color, PillarColor, 0.2f);
        pillarB_2.color = Color.Lerp(pillarB_2.color, PillarColor, 0.2f);

        isA = true;
        isB = false;
        isC = false;
        isD = false;
        isE = false;
    }

    private IEnumerator areaB()
    {
        pillarA_1.color = Color.Lerp(pillarA_1.color, PillarColor_original, 0.2f);
        pillarA_M.color = Color.Lerp(pillarA_M.color, PillarColor_original, 0.2f);
        pillarA_2.color = Color.Lerp(pillarA_2.color, PillarColor_original, 0.2f);
        pillarB_1.color = Color.Lerp(pillarB_1.color, PillarColor_original, 0.2f);
        pillarB_M.color = Color.Lerp(pillarB_M.color, PillarColor_original, 0.2f);
        pillarB_2.color = Color.Lerp(pillarB_2.color, PillarColor_original, 0.2f);
        pillarC_1.color = Color.Lerp(pillarC_1.color, PillarColor_original, 0.2f);
        pillarC_M.color = Color.Lerp(pillarC_M.color, PillarColor_original, 0.2f);
        pillarC_2.color = Color.Lerp(pillarC_2.color, PillarColor_original, 0.2f);
        yield return new WaitForSeconds(0.5f);
        pillarA_1.color = Color.Lerp(pillarA_1.color, PillarColor, 0.2f);
        pillarA_M.color = Color.Lerp(pillarA_M.color, PillarColor, 0.2f);
        pillarA_2.color = Color.Lerp(pillarA_2.color, PillarColor, 0.2f);
        pillarB_1.color = Color.Lerp(pillarB_1.color, PillarColor, 0.2f);
        pillarB_M.color = Color.Lerp(pillarB_M.color, PillarColor, 0.2f);
        pillarB_2.color = Color.Lerp(pillarB_2.color, PillarColor, 0.2f);
        pillarC_1.color = Color.Lerp(pillarC_1.color, PillarColor, 0.2f);
        pillarC_M.color = Color.Lerp(pillarC_M.color, PillarColor, 0.2f);
        pillarC_2.color = Color.Lerp(pillarC_2.color, PillarColor, 0.2f);

        isA = false;
        isB = true;
        isC = false;
        isD = false;
        isE = false;
    }

    private IEnumerator areaC()
    {
        pillarB_1.color = Color.Lerp(pillarB_1.color, PillarColor_original, 0.2f);
        pillarB_M.color = Color.Lerp(pillarB_M.color, PillarColor_original, 0.2f);
        pillarB_2.color = Color.Lerp(pillarB_2.color, PillarColor_original, 0.2f);
        pillarC_1.color = Color.Lerp(pillarC_1.color, PillarColor_original, 0.2f);
        pillarC_M.color = Color.Lerp(pillarC_M.color, PillarColor_original, 0.2f);
        pillarC_2.color = Color.Lerp(pillarC_2.color, PillarColor_original, 0.2f);
        pillarD_1.color = Color.Lerp(pillarD_1.color, PillarColor_original, 0.2f);
        pillarD_M.color = Color.Lerp(pillarD_M.color, PillarColor_original, 0.2f);
        pillarD_2.color = Color.Lerp(pillarD_2.color, PillarColor_original, 0.2f);
        yield return new WaitForSeconds(0.5f);
        pillarB_1.color = Color.Lerp(pillarB_1.color, PillarColor, 0.2f);
        pillarB_M.color = Color.Lerp(pillarB_M.color, PillarColor, 0.2f);
        pillarB_2.color = Color.Lerp(pillarB_2.color, PillarColor, 0.2f);
        pillarC_1.color = Color.Lerp(pillarC_1.color, PillarColor, 0.2f);
        pillarC_M.color = Color.Lerp(pillarC_M.color, PillarColor, 0.2f);
        pillarC_2.color = Color.Lerp(pillarC_2.color, PillarColor, 0.2f);
        pillarD_1.color = Color.Lerp(pillarD_1.color, PillarColor, 0.2f);
        pillarD_M.color = Color.Lerp(pillarD_M.color, PillarColor, 0.2f);
        pillarD_2.color = Color.Lerp(pillarD_2.color, PillarColor, 0.2f);

        isA = false;
        isB = false;
        isC = true;
        isD = false;
        isE = false;
    }

    private IEnumerator areaD()
    {
        pillarC_1.color = Color.Lerp(pillarC_1.color, PillarColor_original, 0.2f);
        pillarC_M.color = Color.Lerp(pillarC_M.color, PillarColor_original, 0.2f);
        pillarC_2.color = Color.Lerp(pillarC_2.color, PillarColor_original, 0.2f);
        pillarD_1.color = Color.Lerp(pillarD_1.color, PillarColor_original, 0.2f);
        pillarD_M.color = Color.Lerp(pillarD_M.color, PillarColor_original, 0.2f);
        pillarD_2.color = Color.Lerp(pillarD_2.color, PillarColor_original, 0.2f);
        pillarE_1.color = Color.Lerp(pillarE_1.color, PillarColor_original, 0.2f);
        pillarE_M.color = Color.Lerp(pillarE_M.color, PillarColor_original, 0.2f);
        pillarE_2.color = Color.Lerp(pillarE_2.color, PillarColor_original, 0.2f);
        yield return new WaitForSeconds(0.5f);
        pillarC_1.color = Color.Lerp(pillarC_1.color, PillarColor, 0.2f);
        pillarC_M.color = Color.Lerp(pillarC_M.color, PillarColor, 0.2f);
        pillarC_2.color = Color.Lerp(pillarC_2.color, PillarColor, 0.2f);
        pillarD_1.color = Color.Lerp(pillarD_1.color, PillarColor, 0.2f);
        pillarD_M.color = Color.Lerp(pillarD_M.color, PillarColor, 0.2f);
        pillarD_2.color = Color.Lerp(pillarD_2.color, PillarColor, 0.2f);
        pillarE_1.color = Color.Lerp(pillarE_1.color, PillarColor, 0.2f);
        pillarE_M.color = Color.Lerp(pillarE_M.color, PillarColor, 0.2f);
        pillarE_2.color = Color.Lerp(pillarE_2.color, PillarColor, 0.2f);

        isA = false;
        isB = false;
        isC = false;
        isD = true;
        isE = false;
    }

    private IEnumerator areaE()
    {
        pillarD_1.color = Color.Lerp(pillarD_1.color, PillarColor_original, 0.2f);
        pillarD_M.color = Color.Lerp(pillarD_M.color, PillarColor_original, 0.2f);
        pillarD_2.color = Color.Lerp(pillarD_2.color, PillarColor_original, 0.2f);
        pillarE_1.color = Color.Lerp(pillarE_1.color, PillarColor_original, 0.2f);
        pillarE_M.color = Color.Lerp(pillarE_M.color, PillarColor_original, 0.2f);
        pillarE_2.color = Color.Lerp(pillarE_2.color, PillarColor_original, 0.2f);
        yield return new WaitForSeconds(0.5f);
        pillarD_1.color = Color.Lerp(pillarD_1.color, PillarColor, 0.2f);
        pillarD_M.color = Color.Lerp(pillarD_M.color, PillarColor, 0.2f);
        pillarD_2.color = Color.Lerp(pillarD_2.color, PillarColor, 0.2f);
        pillarE_1.color = Color.Lerp(pillarE_1.color, PillarColor, 0.2f);
        pillarE_M.color = Color.Lerp(pillarE_M.color, PillarColor, 0.2f);
        pillarE_2.color = Color.Lerp(pillarE_2.color, PillarColor, 0.2f);

        isA = false;
        isB = false;
        isC = false;
        isD = false;
        isE = true;
    }
}
