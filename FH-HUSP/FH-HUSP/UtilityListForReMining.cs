using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class UtilityListForReMining
{
    int tid;
    public int TID
    {
        get { return tid; }
        set { tid = value; }
    }

    float acu;
    public float ACU
    {
        get { return acu; }
        set { acu = value; }
    }
    float ru;
    public float RU
    {
        get { return ru; }
        set { ru = value; }
    }
    UtilityListForReMining link;
    public UtilityListForReMining Link
    {
        get { return link; }
        set { link = value; }
    }
    //Constructor
    public UtilityListForReMining() { }
    public UtilityListForReMining(int tid, float acu, float ru, UtilityListForReMining link = null)
    {
        this.tid = tid;
        this.acu = acu;
        this.ru = ru;
        this.link = link;
    }
}
