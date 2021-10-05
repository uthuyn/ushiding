using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UtilityChain
{

    int seqID;

    public int SeqID
    {
        get { return seqID; }
        set { seqID = value; }
    }

   float peuts;
    public float PEUTS
    {
        get { return peuts; }
        set { peuts = value; }
    }

    float maxUtility;
    public float MaxUtility
    {
        get { return maxUtility; }
        set { maxUtility = value; }
    }

    UtilityList utilityList;
    public UtilityList UtilityList
    {
        get { return utilityList; }
        set { utilityList = value; }
    }

    public UtilityChain(int seqID, float peuts, float maxUtility, UtilityList utilityList)
    {
        this.seqID = seqID;
        this.peuts = peuts;
        this.maxUtility = maxUtility;
        this.utilityList = utilityList;
    }
}
